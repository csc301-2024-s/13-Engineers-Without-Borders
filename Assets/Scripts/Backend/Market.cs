using System.Collections.Generic;
using System;

// Original Author: Kevin Wu, Andy Wang
// This class represents the market where the player can buy products on phase 3.
namespace Backend
{
    /// <summary>
    /// Represents a product that can be sold in the market.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The product's name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// The product's base price.
        /// </summary>
        /// <value>The base price.</value>
        public int Price { get; set; }

        /// <summary>
        /// A multiplier for the price.
        /// </summary>
        /// <value>The price multiplier.</value>
        public float PriceMultiplier { get; set; }

        /// <summary>
        /// Whether the product is purchasable from the market.
        /// </summary>
        /// <value>Whether it's purchasable.</value>
        public bool Buyable { get; set; }

        /// <summary>
        /// The product's description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Some products have extra conditions that must be met aside from price before they can be bought.
        /// </summary>
        /// <value>A function that takes in a buyer and returns whether the condition is met.</value>
        public Func<Household, bool> PurchaseCondition { get; set; }  // What condition must be met BEYOND just price checking?

        /// <summary>
        /// Some products have a special action that must be performed upon purchase.
        /// </summary>
        /// <value>A function that takes in a buyer and returns void.</value>
        public Action<Household> BuyAction { get; set; }  // What happens when buying? By default (in AddProduct) it adds to buyer's inventory
    }

    /// <summary>
    /// Handles market logic so the player can buy and sell products/items.
    /// </summary>
    public static class Market
    {
        private static Dictionary<string, Product> _products;

        /// <summary>
        /// How many plots a single tubewell can irrigate.
        /// </summary>
        public const int PlotsPerTubewell = 8;

        /// <summary>
        /// Initialize the Market and set its products; should be called in GameState.Initialize
        /// </summary>
        public static void Initialize()
        {
            _products = new Dictionary<string, Product>();
            AddProduct("Wheat", 0, "Bushels of wheat that you can eat!");
            UpdateWheatPrice();
            _products["Wheat"].BuyAction = (Household buyer) =>
            {
                buyer.Wheat++;
            };  // Instead of adding to inventory, add wheat instead

            AddProduct("HYC Seed", 40, "Engineered seeds that grow more in good weather, but less in bad weather.");
            AddProduct("Low Fertilizer", 40, "Good fertilizer that boosts crop yield.");
            AddProduct("High Fertilizer", 100, "Great fertilizer that boosts your crops a lot!");

            AddProduct("Ox", 1000, "Doubles the labour output of one adult.");
            _products["Ox"].PurchaseCondition = (Household buyer) =>
            {
                return buyer.Inventory.GetAmount("Ox") < buyer.Family.GetAdultAmount();
            };  // Ox has upper limit

            AddProduct("Land", 300, "One acre of farmland that you can plant stuff on.");
            _products["Land"].BuyAction = (Household buyer) =>
            {
                buyer.Land.AddPlot();
            };  // Instead of adding to inventory, add plot of land instead (currently there is no limit)
            _products["Land"].PurchaseCondition = (Household buyer) =>
            {
                return buyer.Land.Plots.Count < 25;
            };

            // Add one year-contract adult worker as a product. Currently there is no limit on how many adult workers can be hired.
            AddProduct("Labour", 300, "Hire an extra worker for one year. They do not need to be fed.");
            _products["Labour"].BuyAction = (Household buyer) => buyer.HireLabour(); // Instead of adding to inventory, add adult worker instead)

            AddProduct("Tubewell", 1000, $"Lets you irrigate up to {PlotsPerTubewell} plots. Can buy at most 2.");
            _products["Tubewell"].PurchaseCondition = (Household buyer) => buyer.Inventory.GetAmount("Tubewell") < 2;
        }


        /// <summary>
        /// Handle when <paramref name="buyer"/> wants to buy <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the item to buy.</param>
        /// <param name="buyer">The buyer.</param>
        /// <returns>Returns a string with a message if purchase is unsuccessful, empty string otherwise.</returns>
        public static string Buy(string name, Household buyer)
        {
            if (buyer.Money < GetPrice(name))
            {
                return "Not enough money!";
            }
            else
            {
                Product product = _products[name];

                // Does buyer meet purchase condition?
                if (!product.PurchaseCondition(buyer))
                {
                    return "Purchase condition failed; did you hack the game?";
                }

                // Success
                buyer.Money -= GetPrice(name);
                product.BuyAction(buyer);
                return "";
            }
        }

        /// <summary>
        /// <paramref name="seller"/> wants to sell <paramref name="quantity"/> of <paramref name="product"/>.
        /// The actual sold amount will not exceed how much of <paramref name="product"/> the seller actually owns.
        /// Seller's money is automatically increased.
        /// </summary>
        /// <param name="seller">The seller.</param>
        /// <param name="quantity">The quantity to sell.</param>
        /// <param name="product">The product to sell.</param>
        public static void Sell(Household seller, int quantity, string product)
        {
            int toSell;

            if (product == "Wheat")
            {
                toSell = Math.Min(quantity, seller.Wheat);
                seller.Wheat -= toSell;
            }
            else if (product == "Labour")
            {
                toSell = Math.Min(quantity, seller.Family.GetHiredWorkerAmount());
                for (var i = 0; i < toSell; i++)
                {
                    Adult worker = seller.Family.HiredWorkers[0];
                    if (worker.HasOx)  // add back ox if hired worker has one
                        seller.Inventory.AddItem("Ox");
                    seller.Family.HiredWorkers.Remove(worker);
                }
            }
            else
            {
                toSell = Math.Min(quantity, seller.Inventory.GetAmount(product));
                for (var i = 0; i < toSell; i++)
                    seller.Inventory.RemoveItem(product);
            }

            seller.Money += GetPrice(product) * toSell;
        }

        /// <summary>
        /// Changes global wheat price to something between 1 and 10 (inclusive).
        /// </summary>
        public static void UpdateWheatPrice()
        {
            _products["Wheat"].Price = UnityEngine.Random.Range(1, 10);
        }

        // add one product to the market
        // the function hasn't implemented exception check yet(prodcut already exists, price not a positve int)
        private static void AddProduct(string name, int price, string description = "", float multiplier = 1f)
        {
            _products[name] = new Product
            {
                Name = name,
                Price = price,
                PriceMultiplier = multiplier,
                Buyable = true,
                Description = description,

                // Default buy actions:
                PurchaseCondition = (Household buyer) => { return true; },
                BuyAction = (Household buyer) => { buyer.Inventory.AddItem(name); }
            };
        }

        /// <summary>
        /// Test if <paramref name="buyer"/> can actually buy <paramref name="productName"/>.
        /// </summary>
        /// <param name="buyer">The buyer.</param>
        /// <param name="productName">The product to buy.</param>
        /// <returns>Whether the buyer can buy it.</returns>
        public static bool CanBuyerBuy(Household buyer, string productName)
        {
            return buyer.Money >= GetPrice(productName) &&
            _products[productName].PurchaseCondition(buyer) &&
            IsBuyable(productName);
        }

        /// <summary>
        /// Returns the actual selling price of a product, taking price multiplier into account.
        /// </summary>
        /// <param name="name">The product name.</param>
        /// <returns>The selling price.</returns>
        public static int GetPrice(string name)
        {
            return (int)Math.Round(_products[name].Price * _products[name].PriceMultiplier);
        }

        /// <summary>
        /// Set a product's price multiplier.
        /// </summary>
        /// <param name="name">Name of product.</param>
        /// <param name="mult">Desired price multiplier.</param>
        public static void SetPriceMultiplier(string name, float mult)
        {
            _products[name].PriceMultiplier = mult;
        }

        /// <summary>
        /// If a product is disabled in the market, re-enable it.
        /// </summary>
        /// <param name="name">The product to enable.</param>
        public static void ActivateProduct(string name)
        {
            _products[name].Buyable = true;
        }

        /// <summary>
        /// Disable a product from being able to be purchased.
        /// </summary>
        /// <param name="name"></param>
        public static void DeactivateProduct(string name)
        {
            _products[name].Buyable = false;
        }

        /// <summary>
        /// Checks if a product is enabled for purchase.
        /// </summary>
        /// <param name="name">The product's name.</param>
        /// <returns>If the product can be purchased.</returns>
        public static bool IsBuyable(string name)
        {
            return _products[name].Buyable;
        }

        /// <summary>
        /// Get a product's description.
        /// </summary>
        /// <param name="name">The product's name.</param>
        /// <returns>The product's description.</returns>
        public static string GetDescription(string name)
        {
            return _products[name].Description;
        }
    }
}
