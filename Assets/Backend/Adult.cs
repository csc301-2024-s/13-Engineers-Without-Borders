using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
 * This class represents an adult in a family
 */

public class Adult : FamilyMember
{
    const int s_AdultConsumption = 10;
    int MaxAssignedPlots;
    private bool _HasOx;
    private bool _IsAvailable;

    //Constructor of the class
    public Adult(string first, string last)
    {
        this.FirstName = first;
        this.LastName = last;
        this._IsAvailable = true;
        this._HasOx = false;
    }

    //Assign an ox to the adult
    public void BuyOx()
    {
        this._HasOx = true;
        //modify maxLabour here

    }

    //Handle the event that an adult must stay at home to look after the children
    public void LookAtferChild()
    {
        this._IsAvailable = false;
    }

    //Assign a farm plot to this adult
    public bool AssignPlot(FarmPlot Plot)
    {
        //placeholder, will add the proper code after FarmPlot is implemented
        return true;
    }

}
