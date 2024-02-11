using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Backend;

// Author: Andy Wang
// Testing some of the non-trivial methods of Inventory
public class InventoryTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestAddItem()
    {
        Inventory myInventory = new();
        myInventory.AddItem("Ox");
        Assert.AreEqual(myInventory.GetAmount("Ox"), 1);
        myInventory.AddItem("Ox");
        Assert.AreEqual(myInventory.GetAmount("Ox"), 2);
    }

    [Test]
    public void TestRemoveItem()
    {
        Inventory myInventory = new();
        myInventory.AddItem("Ox");
        myInventory.AddItem("Ox");
        myInventory.AddItem("Ox");
        myInventory.RemoveItem("Ox");
        Assert.AreEqual(myInventory.GetAmount("Ox"), 2);
        myInventory.RemoveItem("Ox");
        myInventory.RemoveItem("Ox");
        Assert.IsFalse(myInventory.Contains("Ox"));
    }
}
