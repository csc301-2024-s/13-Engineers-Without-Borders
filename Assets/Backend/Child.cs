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
    public Child(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }


    //Transform the child into an adult
    public Adult ToAdult()
    {
        // Create a new Adult instance and copy attributes
        Adult adult = new Adult(firstName, lastName, age);

        return adult;
    }
}
