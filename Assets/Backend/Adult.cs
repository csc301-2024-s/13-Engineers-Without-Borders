using Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
 * This class represents an adult in a family
 */

public class Adult : FamilyMember
{
    public const int Consumption = 10;
    public int MaxAssignedPlots { get; private set; }
    private bool _hasOx;
    private bool _isAvailable;

    //Constructor of the class
    public Adult(string First, string Last)
    {
        this.FirstName = First;
        this.LastName = Last;
        this._isAvailable = true;
        this._hasOx = false;
    }

    //Assign or de-assign an ox to the adult
    public void AssignOx(bool assigned)
    {
        this._hasOx = assigned;
        //modify maxAssignedPlot here

    }

    //Handle the event that an adult must stay at home to look after the children
    public void LookAfterChild()
    {
        this._isAvailable = false;
    }

    //Assign a farm plot to this adult. Return true if success. Otherwise, return false
    public bool AssignPlot(FarmPlot Plot)
    {
        if (Plot.Worker != null)
        {
            return false;
        }
        else
        {
            Plot.Worker = this;
            return true;
        }
    }

}
