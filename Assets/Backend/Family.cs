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
    public string FamilyName { get; }

    List<Adult> Adults = new List<Adult> ();
    List<Child> Children = new List<Child>();
    private int _numChildren;
    private int _numAdults;
    
    //Constructor of the class
    public Family(string FamilyName, int NumChildren, int numAdults)
    {
        this.FamilyName = FamilyName;
        for(int i = 0; i < NumChildren; i++)
        {
            //Temporary name
            int Age = Random.Range(0, 12);
            Child child = new Child("A", FamilyName, Age);
            Children.Add(child);
        }
        for (int i = 0; i < numAdults; i++)
        {
            //Temporary name
            int Age = Random.Range(18, 81);
            Adult adult = new Adult("B", FamilyName);
            Adults.Add(adult);
        }
        _numAdults = numAdults;
        _numChildren = NumChildren;
    }

    //Add a new child to the family
    public void CreateChild()
    {
        //Temporary name
        Child child = new Child("A", FamilyName, 0);
        Children.Add(child);
        _numChildren++;
    }

    //Calculate family's total consumption after each year
    public int GetTotalConsumption()
    {
        return _numChildren * Child.Consumption + _numAdults * Adult.Consumption;
    }

    //Grow a child up 
    public void IncrementAge()
    {
        for (int i = 0; i < _numChildren; i++)
        {
            Children[i].IncrementAge();
            if (Children[i].Age >= 12)
            {
                Adult NewAdult = Children[i].ToAdult();
                Adults.Add(NewAdult);
                Children.Remove(Children[i]);
                this._numAdults++;
                this._numChildren--;
            }

        }
    }

    // Count the amount of adults
    public int GetAdultAmount()
    {
        return Adults.Count();
    }

    // Count the amount of children
    public int GetChildrenAmount()
    {
        return Children.Count();
    }

}
