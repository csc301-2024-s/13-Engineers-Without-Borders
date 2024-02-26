using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Backend;
using UnityEditor.VersionControl;

// Author: Andy Wang
public class MarketTests
{
    // Test Market initializer
    [Test]
    public void TestInitialize()
    {
        Market.Initialize();
        Assert.AreEqual(Market.GetPrice("HYC Seed"), 40);
        Assert.AreEqual(Market.GetPrice("Low Fertilizer"), 40);
        Assert.AreEqual(Market.GetPrice("High Fertilizer"), 100);
        Assert.AreEqual(Market.GetPrice("Ox"), 1000);
        Assert.AreEqual(Market.GetPrice("Land"), 300);
    }

    // Test too poor to buy things
    [Test]
    public void TestBuyPoor()
    {
        Household buyer = new(0, "Poor", 99, 1, 0);
        Market.Initialize();
        Assert.AreEqual(Market.Buy("Wheat", buyer), "Not enough money!");
    }

    // Test buying various things
    [Test]
    public void TestBuyBasic()
    {
        Household buyer = new(10000, "Rich", 0, 5, Farmland.MaxPlots - 1);
        Market.Initialize();
        
        int moneyNow = buyer.Money;
        Market.Buy("Wheat", buyer);  // wheat has variable price
        Assert.Less(buyer.Money, moneyNow);
        Assert.AreEqual(buyer.Wheat, 1);

        moneyNow = buyer.Money;
        Market.Buy("High Fertilizer", buyer);
        Assert.AreEqual(buyer.Money, moneyNow - 100);
        Assert.AreEqual(buyer.Inventory.GetAmount("High Fertilizer"), 1);

        Market.Buy("Land", buyer);
        Assert.AreEqual(buyer.Land.Plots.Count, Farmland.MaxPlots);
        Market.Buy("Land", buyer);
        Assert.AreEqual(buyer.Land.Plots.Count, Farmland.MaxPlots);  // can't go past max
    }

    // Test buying ox
    [Test]
    public void TestBuyOx()
    {
        Household buyer = new(10000, "Oxiclean", 0, 1, 1);
        Market.Initialize();
        Market.Buy("Ox", buyer);
        Assert.AreEqual(buyer.Inventory.GetAmount("Ox"), 1);
        Assert.AreEqual(buyer.Money, 9000);

        Market.Buy("Ox", buyer);  // should not buy
        Assert.AreEqual(buyer.Inventory.GetAmount("Ox"), 1);
    }
}
