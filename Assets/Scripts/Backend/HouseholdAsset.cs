// Original Author: Andy Wang
// Represents someting owned by a household
namespace Backend
{
    public class HouseholdAsset
    {
        public Household Owner { get; private set; }

        public virtual void SetOwner(Household owner)
        {
            Owner = owner;
        }
    }
}