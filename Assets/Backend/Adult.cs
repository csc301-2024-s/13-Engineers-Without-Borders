using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
 * This class represents an adult in a family
 */

public class Adult : FamilyMember
{
    const int AdultConsumption = 10;
    int MaxAssignedPlots;
    private bool _hasOx;
    private bool _isAvailable;

    //Constructor of the class
    public Adult(string first, string last)
    {
        this.FirstName = first;
        this.LastName = last;
        this._isAvailable = true;
        this._hasOx = false;
    }

    //Assign an ox to the adult
    public void BuyOx()
    {
        this._hasOx = true;
        //modify maxLabour here

    }

    //Handle the event that an adult must stay at home to look after the children
    public void LookAtferChild()
    {
        this._isAvailable = false;
    }

    //Assign a farm plot to this adult
    public bool AssignPlot(FarmPlot Plot)
    {
        //placeholder, will add the proper code after FarmPlot is implemented
        return true;
    }

}
