using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
/*
 * Author: Hoa Nguyen, Bill Guo
 * This class represents a household 
 */

namespace Backend
{
    public class Household
    {
        public Farmland Land { get; }
        public int Money { get; set; }
        public Family Family { get; }
        public Inventory Inventory { get; }
        public int Wheat { get; set; }

        public static Household[] s_Households = new Household[]
        {
            new Household(500, "Madhar", 3, 2, 3),
            new Household(500, "Barlch", 4, 2, 3),
            new Household(500, "Rama", 4, 3, 4),
            new Household(500, "Dulai", 4, 5, 4),
            new Household(500, "Grewal", 4, 6, 5),
            new Household(500, "Kahlon", 3, 2, 4),
            new Household(500, "Aujla", 4, 2, 2),
            new Household(500, "Sandha", 4, 3, 6),
            new Household(500, "Kohli", 0, 2, 1),
            new Household(500, "Gill", 2, 4, 7),
            new Household(500, "Dhillon", 1, 2, 2),
            new Household(500, "Singh", 2, 3, 3),
            new Household(500, "Kapoor", 3, 5, 5),
            new Household(500, "Bhatia", 2, 2, 2),
            new Household(500, "Gupta", 3, 5, 7)
        };


        //Constructor for this class
        public Household(int startMoney, string familyName, int numChildren, int numAdults, int numPlots)
        {
            Money = startMoney;
            Inventory = new Inventory();
            Family = new Family(familyName, numChildren, numAdults);
            Land = new Farmland(numPlots);
            Wheat = 0;
        } 

        /*
         * Calculates the net wheat yield of the household after consumption and updates the wheat value accordingly
         * Note that the wheat value can be negative, which will indicate starvation in phase 3
         */
        public void CalculateRemainingYield() {
            int totalYield = Land.GetTotalYield();
            int totalConsumption = Family.GetTotalConsumption();
            Wheat = totalYield - totalConsumption;
        }

        // Sells all the wheat in the househould and updates money 
        public void SellWheat() {
            if (Wheat > 0) {
                int income = Wheat * Market.GetPrices(); //Change if market is implemented differently
                Money = Money + income;
                Wheat = 0;
            }
        }

        // If the farmland is harvestable, calculate net wheat yield and set canBeHarvested to false;
        public void HarvestCrops() {
            if (Land.canBeHarvested) {
                CalculateRemainingYield();
                Land.canBeHarvested = false;
            }
        }
    }
}
