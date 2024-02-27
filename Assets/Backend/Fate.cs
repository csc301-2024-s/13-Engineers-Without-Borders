using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Original Author: Arick Liu
 * This class represents a fate event, in which it happens every 
 */


namespace Backend
{
    public static class Fate
    {
        private static System.Random _random = new();

        public static void TriggerYearlyEvents()
        {
            foreach (Household plr in GameState.s_Households) {
                DetermineFamilyEvent(plr);
                DetermineVillageEvent();
            }
        }

        private static void DetermineVillageEvent()
        {
            int villageEventOutcome = _random.Next(1, 7);

            switch (villageEventOutcome)
            {
                case 1:
                    //Console.WriteLine("A Relief Organization is working in your community. Oxen are half price this year");
                    // Example: Update ox prices in the market
                    Market.SetPriceMultiplier("Ox", 0.5f);
                    break;
                case 2:
                    //Console.WriteLine("A Relief Organization is working in your community. Tubewells are half price this year");
                    // Example: Update tubewell prices in the market
                    //Market.SetPriceMultiplier("Tubewell", 0.5f); tubewells not implemented yet
                    break;
                case 3:
                    //Console.WriteLine("Sold Out! (No HYC seeds are available this year)");
                    Market.DeactivateProduct("HYC Seed");
                    break;
                default:
                    //Console.WriteLine("No village event this year.");
                    // Example: No specific action for no village event
                    break;
            }
        }

        private static void DetermineFamilyEvent(Household household)
        {
            int familyEventOutcome = _random.Next(1, 7);

            switch (familyEventOutcome)
            {
                case 1:
                    // Console.WriteLine("Pest Attack! Family loses half of the year's crop.");
                    // Outcome: Reduce the amount of harvested crops in the household
                    // TODO: this will be implemented later
                    break;
                case 2:
                case 3:
                    // Console.WriteLine("New Baby! Add one child to the family.");
                    // Outcome: a new baby! Welcome to the family!
                    household.Family.CreateChild();
                    break;
                default:
                    // Console.WriteLine("No family event this year.");
                    // Outcome: No specific action for no family event
                    break;
            }
        }
    }
}