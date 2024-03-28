using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

/*
 * Original Author: Hoa Nguyen
 * This class represents a family in the game.
 */
namespace Backend
{
    public class Family : HouseholdAsset
    {
        public string Name { get; }

        public List<Adult> Adults { get; } = new List<Adult>();
        public List<Child> Children { get; } = new List<Child>();
        public List<Adult> HiredWorkers { get; } = new List<Adult>();

        //Constructor of the class
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

        // Add a new child to the family
        // If age is -1, then generate random age between 0 and 13
        public void CreateChild(int age = -1)
        {
            age = age == -1 ? Random.Range(0, 13) : age;
            Child child = new Child(FamilyMember.GetRandomFirstName(), Name, age);
            Children.Add(child);
        }

        public void CreateAdult()
        {
            Adult adult = new Adult(FamilyMember.GetRandomFirstName(), Name);
            Adults.Add(adult);
        }

        //Calculate family's total consumption after each year
        public int GetTotalConsumption()
        {
            return Children.Count * Child.Consumption + Adults.Count * Adult.Consumption;
        }

        // Count the amount of adults
        public int GetAdultAmount()
        {
            return Adults.Count();
        }

        // Count the amount of children
        public int GetChildrenAmount()
        {
            return Children.Count();
        }

        public int GetHiredWorkerAmount()
        {
            return HiredWorkers.Count();
        }

        // Get total labour points that this family can give
        public int GetLabourPoints()
        {
            int adult_point = Adults.Aggregate(0, (sum, adult) => sum + adult.GetLabourPoints());
            int hired_worker_point = HiredWorkers.Aggregate(0, (sum, adult) => sum + adult.GetLabourPoints());
            return adult_point + hired_worker_point;
        }
    }
}
