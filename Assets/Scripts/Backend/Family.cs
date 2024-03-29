using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

/*
 * Original Author: Hoa Nguyen
 * This class represents a family in the game.
 */
namespace Backend
{
    /// <summary>
    /// Represents a family in the game.
    /// </summary>
    public class Family : HouseholdAsset
    {
        /// <summary>
        /// Family name. Family members have this as their last name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// List of adults in family.
        /// </summary>
        public List<Adult> Adults { get; } = new List<Adult>();

        /// <summary>
        /// List of children in family.
        /// </summary>
        public List<Child> Children { get; } = new List<Child>();

        /// <summary>
        /// List of hired workers in the family. Disappear after every year.
        /// </summary>
        public List<Adult> HiredWorkers { get; } = new List<Adult>();

        /// <summary>
        /// Create a new family with <paramref name="numAdults"/> adults and <paramref name="NumChildren"/> children.
        /// </summary>
        /// <param name="FamilyName">Family name.</param>
        /// <param name="NumChildren">Number of children.</param>
        /// <param name="numAdults">Number of adults.</param>
        public Family(string FamilyName, int NumChildren, int numAdults)
        {
            Name = FamilyName;
            for (int i = 0; i < NumChildren; i++)
            {
                CreateChild();
            }
            for (int i = 0; i < numAdults; i++)
            {
                CreateAdult();
            }
        }

        /// <summary>
        ///  Add a new child to the family.
        /// If <paramref name="age"/> is -1, then generate random age between 0 and 13 (exclusive).
        /// </summary>
        /// <param name="age">Age.</param>
        public void CreateChild(int age = -1)
        {
            age = age == -1 ? Random.Range(0, 13) : age;
            Child child = new Child(FamilyMember.GetRandomFirstName(), Name, age);
            Children.Add(child);
        }

        /// <summary>
        /// Add a new adult to the family.
        /// </summary>
        public void CreateAdult()
        {
            Adult adult = new Adult(FamilyMember.GetRandomFirstName(), Name);
            Adults.Add(adult);
        }

        /// <summary>
        /// Calculate family's total wheat consumption for the year.
        /// </summary>
        /// <returns>Family's total wheat consumption for the year.</returns>
        public int GetTotalConsumption()
        {
            return Children.Count * Child.Consumption + Adults.Count * Adult.Consumption;
        }

        /// <summary>
        /// Get the number of adults in the family.
        /// </summary>
        /// <returns>The number of adults in the family.</returns>
        public int GetAdultAmount()
        {
            return Adults.Count();
        }

        /// <summary>
        /// Get the number of children in the family.
        /// </summary>
        /// <returns>The number of children in the family.</returns>
        public int GetChildrenAmount()
        {
            return Children.Count();
        }

        /// <summary>
        /// Get the number of hired workers in the family.
        /// </summary>
        /// <returns>The number of hired workers in the family.</returns>
        public int GetHiredWorkerAmount()
        {
            return HiredWorkers.Count();
        }

        /// <summary>
        /// Get the total number of labour points that the family generates.
        /// </summary>
        /// <returns>The total number of labour points that the family generates.</returns>
        public int GetLabourPoints()
        {
            int adult_point = Adults.Aggregate(0, (sum, adult) => sum + adult.GetLabourPoints());
            int hired_worker_point = HiredWorkers.Aggregate(0, (sum, adult) => sum + adult.GetLabourPoints());
            return adult_point + hired_worker_point;
        }
    }
}
