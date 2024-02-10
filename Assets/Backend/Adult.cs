using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adult : FamilyMember
{
    private const int consumption = 10;
    private int maxLabour;
    private bool HasOx;
    private bool isAvailable;

    public Adult(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.isAvailable = true;
        this.HasOx = false;
    }

    public void BuyOx()
    {
        this.HasOx = true;
        //modify maxLabour here

    }
    public void LookAtferChild()
    {
        this.isAvailable = false;
    }

}
