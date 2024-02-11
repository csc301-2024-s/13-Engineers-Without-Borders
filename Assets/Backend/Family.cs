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
    public string familyName;
    List<FamilyMember> FamilyMembers = new List<FamilyMember> ();
    int numFarmPlots;
    private int numChildren;
    private int numAdults;
    const int AdultConsumption = 10;
    const int ChildConsumption = 5;

    //Constructor of the class
    public Family(string familyName, int numChildren, int numAdults, int numFarmPlots)
    {
        this.familyName = familyName;
        for(int i = 0; i < numChildren; i++)
        {
            //Temporary name
            int age = Random.Range(0, 12);
            Child child = new Child("A", familyName, age);
            FamilyMembers.Add(child);
        }
        for (int i = 0; i < numAdults; i++)
        {
            //Temporary name
            int age = Random.Range(20, 71);
            Adult adult = new Adult("B", familyName, age);
            FamilyMembers.Add(adult);
        }
        this.numAdults = numAdults;
        this.numChildren = numChildren;
        this.numFarmPlots = numFarmPlots;
    }

    //Add a new child to the family
    public void CreateChild()
    {
        //Temporary name
        Child child = new Child("A", familyName, 0);
        FamilyMembers.Add(child);
        this.numChildren++;
    }

    //Calculate family's total consumption after each year
    public int CalculateConsumption()
    {
        return this.numChildren * ChildConsumption + this.numAdults * AdultConsumption;
    }

    //Grow a child up 
    public void ChildGrowUp()
    {
        List<Child> children = this.FamilyMembers.OfType<Child>().ToList();

        Child GrowingUpKid = children[0];
        Adult newAdult = GrowingUpKid.ToAdult();
        FamilyMembers.Remove(GrowingUpKid);
        FamilyMembers.Add(newAdult);
        this.numAdults++;
        this.numChildren--;
    }

    public void AddAge()
    {
        for (int i = 0; i < this.FamilyMembers.Count; i++)
        {
            this.FamilyMembers[i].IncrementAge();
        };
    }
}
