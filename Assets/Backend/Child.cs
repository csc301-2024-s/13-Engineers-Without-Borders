using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
 * This class represents a child in a family
 */

public class Child : FamilyMember
{
    private const int consumption = 5;

    //Constructor of the class
    public Child(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }


    //Transform the child into an adult
    public Adult GrowUp()
    {
        // Create a new Adult instance and copy attributes
        Adult adult = new Adult(firstName, lastName);

        return adult;
    }
}
