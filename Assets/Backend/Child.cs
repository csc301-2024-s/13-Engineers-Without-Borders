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
    public Child(string FirstName, string LastName, int Age)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.age = Age;
    }


    //Transform the child into an adult
    public Adult ToAdult()
    {
        // Create a new Adult instance and copy attributes
        Adult adult = new Adult(FirstName, LastName);

        return adult;
    }
}
