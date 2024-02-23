using System.Collections.Generic;
using Backend;

/*
 * Author: Hoa Nguyen
 * This class represents an adult in a family
 */

public class Adult : FamilyMember
{
    public const int Consumption = 10;
    public int MaxAssignedPlots { get; private set; } = 2;
    public List<FarmPlot> AssignedPlots { get; } = new();
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
        //modify maxAssignedPlot here

    }

    //Handle the event that an adult must stay at home to look after the children
    public void LookAfterChild()
    {
        _isAvailable = false;
    }

    // Check if the adult can be assigned to a farm plot
    public bool CanBeAssignedTo()
    {
        return AssignedPlots.Count < MaxAssignedPlots;
    }

}
