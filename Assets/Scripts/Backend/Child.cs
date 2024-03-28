/*
 * Original Author: Hoa Nguyen
 * This class represents a child in a family
 */
namespace Backend
{
    /// <summary>
    /// Represents a child in a family.
    /// </summary>
    public class Child : FamilyMember
    {
        /// <summary>
        /// Annual wheat consumption of a child.
        /// </summary>
        public const int Consumption = 5;

        /// <summary>
        /// Child's age.
        /// </summary>
        public int Age { get; private set; }


        /// <summary>
        /// Create a child.
        /// </summary>
        /// <param name="FirstName">First name.</param>
        /// <param name="LastName">Last name.</param>
        /// <param name="Age">Age.</param>
        public Child(string FirstName, string LastName, int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }


        /// <summary>
        /// Create an adult version of this child with the same name. Should be invoked when the child turns 13.
        /// </summary>
        /// <returns>An adult with the same name as the child.</returns>
        public Adult ToAdult()
        {
            // Create a new Adult instance and copy attributes
            Adult adult = new Adult(FirstName, LastName);

            return adult;
        }

        /// <summary>
        /// Increment age of child. This does NOT handle growing up into an adult.
        /// </summary>
        public void IncrementAge()
        {
            Age++;
        }
    }
}
