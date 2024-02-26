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
        public void CalculateRemainingYield()
        {
            int totalYield = Land.GetTotalYield();
            int totalConsumption = Family.GetTotalConsumption();
            Wheat = totalYield - totalConsumption;
        }

        // If the farmland is harvestable, calculate net wheat yield and set canBeHarvested to false;
        public void HarvestCrops()
        {
            if (Land.CanBeHarvested)
            {
                CalculateRemainingYield();
                Land.CanBeHarvested = false;
            }
        }
    }
}
