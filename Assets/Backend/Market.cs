using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Author: Kevin Wu
// This class represents the market where the player can buy products on phase 3.
namespace Backend
{
    // a class for all products in the market
    public class Product {
        public string Name{get; set;}
        public int Price{get; set;}
        public float PriceMultiplier{get; set;}
        public bool Buyable{get; set;}
        public string Type{get; set;}
        public string Description{get; set;}
    }
    public static class Market
    {
        private static Dictionary<string, Product> _items;
        static Market()
        {
            _items = new Dictionary<string, Product>();
        }

        // add one product to the market
        // the function hasn't implemented exception check yet(prodcut already exists, price not a positve int)
        public static void AddProduct(string name, int price, string type, float multiplier = 1f, string description = "")
        {
            _items[name] = new Product();
            _items[name].Name = name;
            _items[name].Price = price;
            _items[name].PriceMultiplier = multiplier;
            _items[name].Buyable = true;
            _items[name].Type = type;
            _items[name].Description = description;
        }

        // remove one product from the market
        // this function is not expected to use in the simulation, just in case it is needed
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static void RemoveProduct(string name)
        {
            _items.Remove(name);
        }

        // get the price based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static int GetPrice(string name)
        {
            return (int)Math.Round(_items[name].Price * _items[name].PriceMultiplier);
        }

        // set the price based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist, price not a positve int)
        public static void SetPrice(string name, int price)
        {
            _items[name].Price = price;
        }

        // make the product able to be bought on the market
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static void ActivateProduct(string name)
        {
            _items[name].Buyable = true;
        }

        // disable the product to be bought on the market
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static void DeactivateProduct(string name)
        {
            _items[name].Buyable = false;
        }

        // check if the product is able to be bought
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static bool IsBuyable(string name)
        {
            return _items[name].Buyable;
        }

        // get the product description based on the product name
        // the function hasn't implemented exception check yet(product doesn't exist)
        public static string GetDescription(string name)
        {
            return _items[name].Description;
        }

        // buy products based on the product name, quantity, the type of the product and the player represented by household(for future need if we add AI players)
        // return 0 if the transaction succeeds
        // return -1 if the player doesn't have enough money
        // the function hasn't implemented exception check yet(product doesn't exist, type doesn't exist, quantity not a positve int)
        public static int Buy(string name, int quantity, string type, Household household)
        {
            if (household.Money < GetPrice(name) * quantity)
            {
                return -1;
            }
            else
            {
                if (type == "seed")
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.AddItem(name);
                    }
                }
                if (type == "fertilizer")
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.AddItem(name);
                    }
                }
                if (type == "tubewell")
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.AddItem(name);
                    }
                }
                if (type == "labour")
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.AddItem(name);
                    }
                }
                if (type == "ox")
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.AddItem(name);
                    }
                }
                if (type == "land")
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Land.Plots.Add(new FarmPlot(0, FertilizerType.NO_FERTILIZER));
                    }
                }
                if (type == "Wheat")
                {
                    household.Wheat += quantity;
                }
                household.Money -= GetPrice(name) * quantity;
                return 0;
            }
        }

        // sell products based on the product name, quantity, the type of the product and the player represented by household(for future need if we add AI players)
        // return 0 if the transaction succeeds
        // return -1 if the player doesn't have enough products to sell
        // the function hasn't implemented exception check yet(product doesn't exist, type doesn't exist, quantity not a positve int)
        public static int Sell(string name, int quantity, string type, Household household)
        {
            if (type == "seed")
            {
                if (household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "fertilizer")
            {
                if (household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "tubewell")
            {
                if (household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "labour")
            {
                if (household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "ox")
            {
                if (household.Inventory.GetAmount(name) < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Inventory.RemoveItem(name);
                    }
                }
            }
            if (type == "land")
            {
                if (household.Land.Plots.Count < quantity)
                {
                    return -1;
                }
                else
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        household.Land.Plots.RemoveAt(household.Land.Plots.Count - 1);
                    }
                }
            }
            if (type == "Wheat")
            {
                if (household.Wheat < quantity)
                {
                    return -1;
                }
                else
                {
                    household.Wheat -= quantity;
                }
            }
            household.Money += GetPrice(name) * quantity;
            return 0;
        }
    }
}
