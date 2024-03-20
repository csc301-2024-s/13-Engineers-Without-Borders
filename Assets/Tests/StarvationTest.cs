using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backend;
using NUnit.Framework;

// Original Author: Hoa Nguyen
public class StarvationTest
{
    // Test starvation
    [SetUp]
    public void Test(Household household)
    {
        if (household.Wheat < 0)
        {
            // Remove children first because they're less useful than adults
            if (household.Family.Children.Count > 0)
            {
                int amountChildrenDie = household.Wheat % 5;
                for (int i = 0; i < amountChildrenDie; i++)
                {
                    if (household.Family.Children.Count > 0)
                    {
                        Child child = household.Family.Children[0];
                        string name = child.FirstName;
                        household.Family.Children.RemoveAt(0);
                    }
                    else if (household.Family.Adults.Count > 0)
                    {
                        Adult adult = household.Family.Adults[0];
                        string name = adult.FirstName;
                        household.Family.Adults.RemoveAt(0);
                    }
                    else if (household.Family.Adults.Count == 0)
                    {
                    }
                }
            }
            else if (household.Family.Adults.Count > 0)
            {
                int amountAdultsDie = household.Wheat % 10;
                for (int i = 0; i < amountAdultsDie; i++)
                {
                    if (household.Family.Adults.Count > 0)
                    {
                        Adult adult = household.Family.Adults[0];
                        string name = adult.FirstName;
                        household.Family.Adults.RemoveAt(0);
                        
                    }
                    else if (household.Family.Adults.Count == 0)
                    {
           
                    }
                }
            }
        }
    }
    [Test]
    public void TestOneChildDied()
    {
        Household poor = new(0, "Poor", 3, 2, 0);
        poor.Wheat = -4;
        Test(poor);
        Assert.AreEqual(poor.Family.Children.Count, 2);     
    }

    [Test]
    public void TestOneAdultDied()
    {
        Household poor = new(0, "Poor", 0, 2, 0);
        poor.Wheat = -3;
        Test(poor);
        Assert.AreEqual(poor.Family.Adults.Count, 1);
    }

    [Test]
    public void TestAllChildrenDied()
    {
        Household poor = new(0, "Poor", 3, 2, 0);
        poor.Wheat = -12;
        Test(poor);
        Assert.AreEqual(poor.Family.Children.Count, 0);
    }

    [Test]
    public void TestAllAdultsDied()
    {
        Household poor = new(0, "Poor", 1, 2, 0);
        poor.Wheat = -16;
        Test(poor);
        Assert.AreEqual(poor.Family.Adults.Count, 0);
    }
}
