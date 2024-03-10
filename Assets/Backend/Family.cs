using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        public List<Adult> Hired_Worker { get; } = new List<Adult>();

        //Constructor of the class
        public Family(string FamilyName, int NumChildren, int numAdults)
        {
            Name = FamilyName;
            for (int i = 0; i < NumChildren; i++)
            {
                //Temporary name
                int Age = CalculateChildAge();
                Child child = new Child("A", FamilyName, Age);
                Children.Add(child);
            }
            for (int i = 0; i < numAdults; i++)
            {
                //Temporary name
                Adult adult = new Adult("B", FamilyName);
                Adults.Add(adult);
            }
        }

        //Calculate the age of a child
        private int CalculateChildAge()
        {
            // Use the current year and month to calculate age
            DateTime currentTime = DateTime.Now;
            int currentYear = currentTime.Year;
            int currentMonth = currentTime.Month;

            // Example: age is a function of the current year and month
            int baseAge = 5; // Base age for all children
            int age = baseAge + (currentYear % 10) - (currentMonth % 5);

            return Mathf.Clamp(age, 0, 11); // Clamp age to a reasonable range (0-11)
        }

        //Add a new child to the family
        public void CreateChild()
        {
            //Temporary name
            Child child = new Child("A", Name, 0);
            Children.Add(child);
        }

        //Calculate family's total consumption after each year
        public int GetTotalConsumption()
        {
            return Children.Count * Child.Consumption + Adults.Count * Adult.Consumption;
        }

        //Grow a child up if he or she reaches 12
        public void IncrementAge()
        {
            for (var i = Children.Count - 1; i > -1; i--)
            {
                Children[i].IncrementAge();
                if (Children[i].Age >= 12)
                {
                    Adult NewAdult = Children[i].ToAdult();
                    Adults.Add(NewAdult);
                    Children.Remove(Children[i]);
                }
            }
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
            return Hired_Worker.Count();
        }

        // Get total labour points that this family can give
        public int GetLabourPoints()
        {
            int adult_point = Adults.Aggregate(0, (sum, adult) => sum + adult.GetLabourPoints());
            int hired_worker_point = Hired_Worker.Aggregate(0, (sum, adult) => sum + adult.GetLabourPoints());
            return adult_point + hired_worker_point;
        }
    }
}
