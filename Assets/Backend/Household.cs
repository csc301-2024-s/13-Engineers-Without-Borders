using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
 * This class represents a household 
 */

namespace Backend
{
    public class Household
    {
        int Money;
        Family Family;
        Farmland Land;

        // TODO: this needs more parameters, follow the UML diagram please
        //Constructor for this class
        public Household(Family Family, Farmland Land)
        {
            this.Money = 500;
            this.Family = Family;
            this.Land = Land;
        }
    }
}
