using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Hoa Nguyen
 * This class represents an adult in a family
 */

public class Adult : FamilyMember
{
    private const int consumption = 10;
    private int maxLabour;
    private bool HasOx;
    private bool isAvailable;

    //Constructor of the class
    public Adult(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.isAvailable = true;
        this.HasOx = false;
    }

    //Assign an ox to the adult
    public void BuyOx()
    {
        this.HasOx = true;
        //modify maxLabour here

    }

    //Handle the event that an adult must stay at home to look after the children
    public void LookAtferChild()
    {
        this.isAvailable = false;
    }

}
