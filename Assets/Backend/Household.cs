using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
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

        //Constructor for this class
        public Household(int startMoney, string familyName, int numChildren, int numAdults, int numPlots)
        {
            Money = startMoney;
            Inventory = new Inventory();
            Family = new Family(familyName, numChildren, numAdults);
            Land = new Farmland(numPlots);
        }   

        // Returns the net wheat yield of the family after consumption, could be negative.
        public int GetRemainingYield() {
            return Land.GetTotalYield() - Family.GetTotalConsumption();
        }
    }
}
