using System;
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
            int Age = CalculateChildAge();
            Child child = new Child("A", FamilyName, Age);
            Children.Add(child);
        }
        for (int i = 0; i < numAdults; i++)
        {
            //Temporary name
            Adult adult = new Adult("B", FamilyName);
            Adults.Add(adult);
        }
        _numAdults = numAdults;
        _numChildren = NumChildren;
    }

    //Calculate the age of a child
    private int CalculateChildAge()
    {
        // Use the current year and month to calculate age
        DateTime currentTime = DateTime.Now;
        int currentYear = currentTime.Year;
        int currentMonth = currentTime.Month;

        // Example: age is a function of the current year and month
        int baseAge = 5; // Base age for all children
        int age = baseAge + (currentYear % 10) - (currentMonth % 5);

        return Mathf.Clamp(age, 0, 11); // Clamp age to a reasonable range (0-11)
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

    //Grow a child up if he or she reaches 12
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
