using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
}
