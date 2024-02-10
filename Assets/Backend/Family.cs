using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Family
{
    public string familyName;
    List<FamilyMember> FamilyMembers = new List<FamilyMember> ();
    int numFarmPlots;
    private int numChildren;
    private int numAdults;

    public Family(string familyName, int numChildren, int numAdults, int numFarmPlots)
    {
        this.familyName = familyName;
        for(int i = 0; i < numChildren; i++)
        {
            //Temporary name
            Child child = new Child("A", familyName);
            FamilyMembers.Add(child);
        }
        for (int i = 0; i < numAdults; i++)
        {
            //Temporary name
            Child child = new Child("B", familyName);
            FamilyMembers.Add(child);
        }
        this.numAdults = numAdults;
        this.numChildren = numChildren;
        this.numFarmPlots = numFarmPlots;
    }

    public void CreateChild()
    {
        //Temporary name
        Child child = new Child("A", familyName);
        FamilyMembers.Add(child);
        this.numChildren++;
    }

    public int CalculateConsumption()
    {
        return this.numChildren * 5 + this.numAdults * 10;
    }

    public void ChildGrowUp()
    {
        List<Child> children = this.FamilyMembers.OfType<Child>().ToList();

        // Select a random Child object
        Child GrowingUpKid = children[0];
        Adult newAdult = GrowingUpKid.GrowUp();
        FamilyMembers.Remove(GrowingUpKid);
        FamilyMembers.Add(newAdult);
    }
}
