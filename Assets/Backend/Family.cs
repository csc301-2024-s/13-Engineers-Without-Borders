using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Author: Hoa Nguyen
 * This class represents a family in the game.
 */

public class Family
{
    public string FamilyName;
    List<FamilyMember> FamilyMembers = new List<FamilyMember> ();
    int numFarmPlots;
    private int _numChildren;
    private int _numAdults;
    
    //Constructor of the class
    public Family(string familyName, int numChildren, int numAdults, int numFarmPlots)
    {
        this.FamilyName = familyName;
        for(int i = 0; i < numChildren; i++)
        {
            //Temporary name
            Child child = new Child("A", familyName);
            FamilyMembers.Add(child);
        }
        for (int i = 0; i < numAdults; i++)
        {
            //Temporary name
            Adult adult = new Adult("B", familyName);
            FamilyMembers.Add(adult);
        }
        this._numAdults = numAdults;
        this._numChildren = numChildren;
        this.numFarmPlots = numFarmPlots;
    }

    //Add a new child to the family
    public void CreateChild()
    {
        //Temporary name
        Child child = new Child("A", FamilyName);
        FamilyMembers.Add(child);
        this._numChildren++;
    }

    //Calculate family's total consumption after each year
    public int GetTotalConsumption()
    {
        return this._numChildren * 5 + this._numAdults * 10;
    }

    //Grow a child up 
    public void ChildGrowUp()
    {
        List<Child> children = this.FamilyMembers.OfType<Child>().ToList();

        Child GrowingUpKid = children[0];
        Adult newAdult = GrowingUpKid.GrowUp();
        FamilyMembers.Remove(GrowingUpKid);
        FamilyMembers.Add(newAdult);
    }

    // Count the amount of adults
    public int GetAdultAmount()
    {
        List<Adult> adult = this.FamilyMembers.OfType<Adult>().ToList();
        return adult.Count();
    }

    // Count the amount of children
    public int GetChildrenAmount()
    {
        List<Child> children = this.FamilyMembers.OfType<Child>().ToList();
        return children.Count();
    }

}
