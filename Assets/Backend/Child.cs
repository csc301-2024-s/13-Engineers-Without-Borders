using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
 * This class represents a child in a family
 */

public class Child : FamilyMember
{
    const int ChildConsumption = 5;

    //Constructor of the class
    public Child(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }


    //Transform the child into an adult
    public Adult GrowUp()
    {
        // Create a new Adult instance and copy attributes
        Adult adult = new Adult(FirstName, LastName);

        return adult;
    }
}
