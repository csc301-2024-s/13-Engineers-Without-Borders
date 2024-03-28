// Original Author: Andy Wang
// Represents someting owned by a household
namespace Backend
{
    /// <summary>
    /// Something that a household can own.
    /// </summary>
    public class HouseholdAsset
    {
        /// <summary>
        /// Owner of the asset.
        /// </summary>
        public Household Owner { get; private set; }

        /// <summary>
        /// Set the owner.
        /// </summary>
        /// <param name="owner">Owner.</param>
        public virtual void SetOwner(Household owner)
        {
            Owner = owner;
        }
    }
}