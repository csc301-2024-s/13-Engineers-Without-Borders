using System.Collections.Generic;
using System;

// Original Author: Kevin Wu, Andy Wang
// This class represents the market where the player can buy products on phase 3.
namespace Backend
{
    // Products can be sorted into types
    public enum ProductType
    {
        Seed,
        Fertilizer,
        Tool,
        Food,
        Land
    }

    // a class for all products in the market
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public float PriceMultiplier { get; set; }
        public bool Buyable { get; set; }
        public ProductType Type { get; set; }
        public string Description { get; set; }
        public Func<Household, bool> PurchaseCondition { get; set; }  // What condition must be met BEYOND just price checking?
        public Action<Household> BuyAction { get; set; }  // What happens when buying? By default (in AddProduct) it adds to buyer's inventory
    }
    public static class Market
    {
        private static Dictionary<string, Product> _products;

        // Initialize the Market; should be called in GameState.Initialize
        public static void Initialize()
        {
            _products = new Dictionary<string, Product>();
            AddProduct("Wheat", 0, ProductType.Food, "Bushels of wheat that you can eat!");
            UpdateWheatPrice();
            _products["Wheat"].BuyAction = (Household buyer) =>
            {
                buyer.Wheat++;
            };  // Instead of adding to inventory, add wheat instead

            AddProduct("HYC Seed", 40, ProductType.Seed, "Engineered seeds that grow more in good weather, but less in bad weather.");
            AddProduct("Low Fertilizer", 40, ProductType.Seed, "Good fertilizer that boosts crop yield.");
            AddProduct("High Fertilizer", 100, ProductType.Seed, "Great fertilizer that boosts your crops a lot!");

            AddProduct("Ox", 1000, ProductType.Tool, "Doubles the labour output of one adult.");
            _products["Ox"].PurchaseCondition = (Household buyer) =>
            {
                return buyer.Inventory.GetAmount("Ox") < buyer.Family.GetAdultAmount();
            };  // Ox has upper limit

            AddProduct("Land", 300, ProductType.Land, "One acre of farmland that you can plant stuff on.");
            _products["Land"].BuyAction = (Household buyer) =>
            {
                buyer.Land.AddPlot();
            };  // Instead of adding to inventory, add plot of land instead (currently there is no limit)
            _products["Land"].PurchaseCondition = (Household buyer) =>
            {
                return buyer.Land.Plots.Count < 25;
            };

            AddProduct("Tubewell", 500, ProductType.Tool, "Lets you irrigate up to 10 farm plots.");
        }

        // <buyer> requests to purchase one product with name <name>
        // return error message if failure, otherwise empty string
        // Precondition: The buyer SHOULD satisfy the requested product's purchase condition because the buy button is only active if they do
        // the function hasn't implemented exception check yet(product doesn't exist, type doesn't exist, quantity not a positve int)
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

        // <seller> sells <quantity> wheat
        // Sells min(<quantity>, <seller.Wheat>) wheat
        public static void SellWheat(Household seller, int quantity)
        {
            int wheatToSell = Math.Min(quantity, seller.Wheat);
            seller.Wheat -= wheatToSell;
            seller.Money += GetPrice("Wheat") * wheatToSell;
        }

        // Change wheat price to random int in 1-10
        public static void UpdateWheatPrice()
        {
            _products["Wheat"].Price = UnityEngine.Random.Range(1, 10);
        }

        // add one product to the market
        // the function hasn't implemented exception check yet(prodcut already exists, price not a positve int)
        public static void AddProduct(string name, int price, ProductType type, string description = "", float multiplier = 1f)
        {
            _products[name] = new Product
            {
                Name = name,
                Price = price,
                PriceMultiplier = multiplier,
                Buyable = true,
                Type = type,
                Description = description,

                // Default buy actions:
                PurchaseCondition = (Household buyer) => { return true; },
                BuyAction = (Household buyer) => { buyer.Inventory.AddItem(name); }
            };
        }

        // remove one product from the market
        // this function is not expected to use in the simulation, just in case it is needed
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static void RemoveProduct(string name)
        {
            _products.Remove(name);
        }

        // Test if the given buyer can actually buy the requested product
        public static bool CanBuyerBuy(Household buyer, string productName)
        {
            return buyer.Money >= GetPrice(productName) &&
            _products[productName].PurchaseCondition(buyer) &&
            IsBuyable(productName);
        }

        // get the active price based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static int GetPrice(string name)
        {
            return (int)Math.Round(_products[name].Price * _products[name].PriceMultiplier);
        }

        // set the price multiplier based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist, price not a positve int)
        public static void SetPriceMultiplier(string name, float mult)
        {
            _products[name].PriceMultiplier = mult;
        }

        // make the product able to be bought on the market
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static void ActivateProduct(string name)
        {
            _products[name].Buyable = true;
        }

        // disable the product to be bought on the market
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static void DeactivateProduct(string name)
        {
            _products[name].Buyable = false;
        }

        // check if the product is able to be bought
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static bool IsBuyable(string name)
        {
            return _products[name].Buyable;
        }

        // get the product description based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static string GetDescription(string name)
        {
            return _products[name].Description;
        }
    }
}
