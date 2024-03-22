/*
 * Original Author: Hoa Nguyen
 * This class represents a child in a family
 */
namespace Backend
{
    public class Child : FamilyMember
    {
        public const int Consumption = 5;
        public int Age { get; private set; }


        // Constructor of the class
        public Child(string FirstName, string LastName, int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }


        // Transform the child into an adult
        public Adult ToAdult()
        {
            // Create a new Adult instance and copy attributes
            Adult adult = new Adult(FirstName, LastName);

            return adult;
        }

        // Increment the age of child
        public void IncrementAge()
        {
            Age++;
        }
    }
}