/*
 * Original Author: Hoa Nguyen
 * This class represents an adult in a family
 */
namespace Backend
{
    /// <summary>
    /// Represents an adult worker in a family.
    /// </summary>
    public class Adult : FamilyMember
    {
        /// <summary>
        /// Wheat consumption per year.
        /// </summary>
        public const int Consumption = 10;

        /// <summary>
        /// Base labour points contributed.
        /// </summary>
        public const int BaseLabourPoints = 2;

        /// <summary>
        /// Whether the adult has an ox.
        /// </summary>
        public bool HasOx { get; private set; }

        /// <summary>
        /// Creates an adult.
        /// </summary>
        /// <param name="First">First name.</param>
        /// <param name="Last">Last name.</param>
        public Adult(string First, string Last)
        {
            FirstName = First;
            LastName = Last;
            HasOx = false;
        }

        /// <summary>
        /// Assign or unassign an ox to this adult.
        /// </summary>
        /// <param name="assigned">Whether to assign or unassign.</param>
        public void AssignOx(bool assigned)
        {
            HasOx = assigned;
        }

        /// <summary>
        /// Calculate how many labour points this adult contributes. Doubled if adult has an ox.
        /// </summary>
        /// <returns>Labour points contributed.</returns>
        public int GetLabourPoints()
        {
            return HasOx ? BaseLabourPoints * 2 : BaseLabourPoints;
        }
    }
}
