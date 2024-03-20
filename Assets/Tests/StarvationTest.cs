using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backend;
using NUnit.Framework;

// Original Author: Hoa Nguyen
public class StarvationTest
{
    // Test starvation
    public void Test(Household household)
    {
        while (household.Wheat < 0 && household.Family.GetAdultAmount() > 0)
        {
            // Remove children first because they're less useful than adults
            if (household.Family.GetChildrenAmount() > 0)
            {
                household.Family.Children.RemoveAt(0);
                household.Wheat += Child.Consumption;
            }
            else if (household.Family.GetAdultAmount() > 0)
            {
                household.Family.Adults.RemoveAt(0);
                household.Wheat += Adult.Consumption;
            }
            household.Wheat = Mathf.Min(household.Wheat, 0);  // don't let it go over 0
        }
    }

    [Test]
    public void TestOneChildDied()
    {
        Household poor = new(0, "Poor", 3, 2, 0)
        {
            Wheat = -4
        };
        Test(poor);
        Assert.AreEqual(poor.Family.Children.Count, 2);
    }

    [Test]
    public void TestOneAdultDied()
    {
        Household poor = new(0, "Poor", 0, 2, 0)
        {
            Wheat = -3
        };
        Test(poor);
        Assert.AreEqual(poor.Family.Adults.Count, 1);
    }

    [Test]
    public void TestAllChildrenDied()
    {
        Household poor = new(0, "Poor", 3, 2, 0)
        {
            Wheat = -12
        };
        Test(poor);
        Assert.AreEqual(poor.Family.Children.Count, 0);
    }

    [Test]
    public void TestAllAdultsDied()
    {
        Household poor = new(0, "Poor", 1, 2, 0)
        {
            Wheat = -16
        };
        Test(poor);
        Assert.AreEqual(poor.Family.Adults.Count, 0);
    }
}
