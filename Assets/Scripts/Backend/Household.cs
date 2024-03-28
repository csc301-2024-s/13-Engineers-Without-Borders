/*
 * Original Author: Hoa Nguyen, Bill Guo
 * This class represents a household 
 */

namespace Backend
{
    /// <summary>
    /// A household/player in the game.
    /// </summary>
    public class Household
    {
        /// <summary>
        /// This household's land.
        /// </summary>
        public Farmland Land { get; }

        /// <summary>
        /// This household's money.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// This household's family.
        /// </summary>
        public Family Family { get; }

        /// <summary>
        /// This household's inventory of items.
        /// </summary>
        public Inventory Inventory { get; }

        /// <summary>
        /// This household's wheat.
        /// </summary>
        public int Wheat { get; set; }

        /// <summary>
        /// Create a household with the specified parameters.
        /// </summary>
        /// <param name="startMoney">Starting money.</param>
        /// <param name="familyName">Family name. Every family member has this as their last name.</param>
        /// <param name="numChildren">Number of children in family.</param>
        /// <param name="numAdults">Number of adults in family.</param>
        /// <param name="numPlots">Number of plots in farmland.</param>
        public Household(int startMoney, string familyName, int numChildren, int numAdults, int numPlots)
        {
            Money = startMoney;
            Inventory = new Inventory();
            Family = new Family(familyName, numChildren, numAdults);
            Land = new Farmland(numPlots);
            Wheat = 0;

            Inventory.SetOwner(this);
            Family.SetOwner(this);
            Land.SetOwner(this);
        }

        /// <summary>
        /// Creates an adult named "Hired Worker", to be removed from the household after a year.
        /// </summary>
        public void HireLabour()
        {
            Adult adult = new Adult("Hired", "Worker");
            Family.HiredWorkers.Add(adult);
        }

        /// <summary>
        /// Remove all hired labour from this family.
        /// </summary>
        public void RemoveLabour()
        {
            foreach (Adult worker in Family.HiredWorkers) 
            {
                if (worker.HasOx)
                {
                    Inventory.AddItem("Ox");
                }
            }
            Family.HiredWorkers.Clear();
        }
    }
}
