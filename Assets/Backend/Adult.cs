using System.Collections.Generic;
using Backend;

/*
 * Original Author: Hoa Nguyen
 * This class represents an adult in a family
 */
namespace Backend
{
    public class Adult : FamilyMember
    {
        public const int Consumption = 10;
        public const int BaseLabourPoints = 2;

        private bool _hasOx;
        private bool _isAvailable;

        //Constructor of the class
        public Adult(string First, string Last)
        {
            FirstName = First;
            LastName = Last;
            _isAvailable = true;
            _hasOx = false;
        }

        //Assign or de-assign an ox to the adult
        public void AssignOx(bool assigned)
        {
            _hasOx = assigned;
        }

        //Handle the event that an adult must stay at home to look after the children
        public void LookAfterChild()
        {
            _isAvailable = false;
        }

        // Calculate how many labour points this adult gives you
        public int GetLabourPoints()
        {
            return _hasOx ? BaseLabourPoints * 2 : BaseLabourPoints;
        }
    }
}
