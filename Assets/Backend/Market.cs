using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Author: Kevin Wu
// This class represents the market where the player can buy products on phase 3.
namespace Backend
{
    // a struct for all products in the market
    public struct Product {
        public string name;
        public int price;
        public bool buyable;
        public string type;
        public string description;
    }
    public class Market
    {
        private Dictionary<string, Product> _items;
        public Market()
        {
            _items = new Dictionary<string, Product>();
        }

        // add one product to the market
        // the function hasn't implemented exception check yet(prodcut already exists, price not a positve int)
        public void AddProduct(string name, int price, string type, string description = "")
        {
            _items[name] = new Product();
            _items[name].name = name;
            _items[name].price = price;
            _items[name].buyable = true;
            _items[name].type = type;
            _items[name].description = description;
        }

        // remove one product from the market
        // this function is not expected to use in the simulation, just in case it is needed
        // the function hasn't implemented exception check yet(product doesn't exist)
        public void RemoveProduct(string name)
        {
            _items.Remove(name);
        }

        // get the price based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist)
        public int GetPrice(string name)
        {
            return _items[name].price;
        }

        // set the price based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist, price not a positve int)
        public void SetPrice(string name, int price)
        {
            _items[name].price = price;
        }

        // make the product able to be bought on the market
        // the function hasn't implemented exception check yet(product doesn't exist)
        public void ActivateProduct(string name)
        {
            _items[name].buyable = true;
        }

        // disable the product to be bought on the market
        // the function hasn't implemented exception check yet(product doesn't exist)
        public void DeactivateProduct(string name)
        {
            _items[name].buyable = false;
        }

        // check if the product is able to be bought
        // the function hasn't implemented exception check yet(product doesn't exist)
        public bool IsBuyable(string name)
        {
            return _items[name].buyable;
        }

        // get the product description based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist)
        public string GetDescription(string name)
        {
            return _items[name].description;
        }

        // buy products based on the product name, quantity and the type of the product
        // return 0 if the transaction succeeds
        // return -1 if the player doesn't have enough money
        // the function hasn't implemented exception check yet(product doesn't exist, type doesn't exist, quantity not a positve int)
        public int Buy(string name, int quantity, string type)
        {
            if (Household.Money < GetPrice(name) * quantity)
            {
                return -1;
            }
            else
            {
                if (type == "seed")
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.AddItem(name);
                    }
                }
                if (type == "fertilizer")
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.AddItem(name);
                    }
                }
                if (type == "tubewell")
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.AddItem(name);
                    }
                }
                if (type == "labour")
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.AddItem(name);
                    }
                }
                if (type == "ox")
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.AddItem(name);
                    }
                }
                if (type == "land")
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Land.Plots.Add(new FarmPlot(0, FertilizerType.NO_FERTILIZER));
                    }
                }
                if (type == "Wheat")
                {
                    Household.Wheat += quantity;
                }
                Household.Money -= GetPrice(name) * quantity;
                return 0;
            }
        }

        // sell products based on the product name, quantity and the type of the product
        // return 0 if the transaction succeeds
        // return -1 if the player doesn't have enough products to sell
        // the function hasn't implemented exception check yet(product doesn't exist, type doesn't exist, quantity not a positve int)
        public int Sell(string name, int quantity, string type)
        {
            if (type == "seed")
            {
                if (Household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "fertilizer")
            {
                if (Household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "tubewell")
            {
                if (Household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "labour")
            {
                if (Household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "ox")
            {
                if (Household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "land")
            {
                if (Household.Land.Plots.Count < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity, i++)
                    {
                        Household.Land.Plots.RemoveAt(Household.Land.Plots.Count - 1);
                    }
                }
            }
            if (type == "Wheat")
            {
                if (Household.Wheat < quantity)
                {
                    return -1;
                }
                else
                {
                    Household.Wheat -= quantity;
                }
            }
            Household.Money += GetPrice(name) * quantity;
            return 0;
        }
    }
}
