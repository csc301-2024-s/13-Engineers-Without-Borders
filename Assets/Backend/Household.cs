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

        //Constructor for this class
        public Household(Family Family, Farmland Land)
        {
            this.Money = 500;
            this.Family = Family;
            this.Land = Land;
        }
    }
}
