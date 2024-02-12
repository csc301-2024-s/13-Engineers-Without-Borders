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
        static Dictionary<string, Household> s_Households = new Dictionary<string, Household>();;
        Farmland Land;
        int Money;
        Family Family;
        Inventory Inventory;

        // TODO: this needs more parameters, follow the UML diagram please
        //Constructor for this class
        public Household(int startMoney, string familyName, int numChildren, int numAdults, int numPlots)
        {
            Money = startMoney;
            s_Households.Add(familyName, this);
            Inventory = new Inventory();
            Family = new Family(familyName, numChildren, numAdults);
            Land = new Farmland(numPlots);
        }
    }
}
