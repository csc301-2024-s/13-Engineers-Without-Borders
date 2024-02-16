using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Backend;

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
}
