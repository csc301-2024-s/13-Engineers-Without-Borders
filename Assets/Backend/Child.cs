using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : FamilyMember
{
    private const int consumption = 5;
    public Child(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public Adult GrowUp()
    {
        // Create a new Adult instance and copy attributes
        Adult adult = new Adult(firstName, lastName);

        return adult;
    }
}
