using UnityEngine;
using UnityEngine.TestTools;
using Backend;
using NUnit.Framework;

// Author: Hoa Nguyen
// Basic tests for the methods of Family's methods 
public class FamilyTest
{
    // Check if a family object is created correctly
   [Test]
   public void TestCreateFamily()
    {
        Family family = new Family("Rama", 4, 3);
        Assert.AreEqual(family.GetAdultAmount(), 3);
        Assert.AreEqual(family.GetChildrenAmount(), 4);
    }

    // Test the CreateChild method
    [Test]
    public void TestCreateChild()
    {
        Family family = new Family("Rama", 4, 3);
        family.CreateChild();
        Assert.AreEqual(family.GetChildrenAmount(), 5);
    }

    //Test ChildGrowUp method
    public void TestGrowUp()
    {
        Family family = new Family("Rama", 4, 3);
        family.IncrementAge();
        Assert.AreEqual(family.GetAdultAmount(), 4);
        Assert.AreEqual(family.GetChildrenAmount(), 3);
    }

    // Test calculating the total consumption
    public void TestTotalConsumption()
    {
        Family family = new Family("Rama", 4, 3);
        Assert.AreEqual(family.GetTotalConsumption(), 50);
    }
}
