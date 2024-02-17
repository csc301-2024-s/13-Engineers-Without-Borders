using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * Author: Arick Liu
 * This class represents a fate event, in which it happens every 
 */


namespace Backend
{
    public class Fate
    {
        private Random random;

        public Fate() //fate class, this happens in the beginning of every year to ensure that the events will go through, 
        //thus other classes may be modified or inherited
        {
            random = new Random(); //the random number generator because the dice is used 2-3 times for this class according to game rules
        }

        public void TriggerYearlyEvents(Household household)
        {
            DetermineWeather();
            DetermineFamilyEvent(household);
            DetermineVillageEvent(household);
        }

        private void DetermineWeather()
        {
            int weatherState = random.Next(1, 6); //weather involves a die roll from 1-6, however its detailed functions are
            //still being completed in the other classes at this stage, so the effects of the outcome are omitted intentionally now
            Console.WriteLine($"Weather Outcome: {weatherState}");

            // Example: Set weather properties based on outcome
            if (weatherState == 1)
            {
                Console.WriteLine("Best weather for growing wheat! Use this opportunity!");
                // Implement logic for the best weather scenario
            }
            else if (weatherState == 5)
            {
                Console.WriteLine("Worst weather for growing wheat! Unlucky year!");
                // Implement logic for the worst weather scenario
            }

            else if (weatherState == 2)
            {
                Console.WriteLine("Bad weather! Better be careful!");
                // Implement logic for the worst weather scenario
            }

            else if (weatherState == 3)
            {
                Console.WriteLine("Average weather for growing wheat!");
                // Implement logic for the worst weather scenario
            }

            else if (weatherState == 4)
            {
                Console.WriteLine("Good weather for growing wheat!");
                // Implement logic for the worst weather scenario
            }
            else
            {
                Console.WriteLine("Average weather for growing wheat.");
                // Implement logic for average weather scenario
            }
        }

        private void DetermineVillageEvent(Household household)
        {
            int villageEventOutcome = random.Next(1, 7);
            Console.WriteLine($"Village Event Outcome: {villageEventOutcome}");

            switch (villageEventOutcome)
            {
                case 1:
                    Console.WriteLine("A Relief Organization is working in your community. Oxen are half price this year");
                    // Example: Update ox prices in the market
                    Market.SetPrice("Ox", Market.GetPrice("Ox") / 2);
                    break;
                case 2:
                    Console.WriteLine("A Relief Organization is working in your community. Tubewells are half price this year");
                    // Example: Update tubewell prices in the market
                    Market.SetPrice("Tubewell", Market.GetPrice("Tubewell") / 2);
                    break;
                case 3:
                    Console.WriteLine("Sold Out! (No HYC seeds are available this year)");
                    // Example: Set a flag or update seed availability
                    break;
                default:
                    Console.WriteLine("No village event this year.");
                    // Example: No specific action for no village event
                    break;
            }
        }

        private void DetermineFamilyEvent(Household household)
        {
            int familyEventOutcome = random.Next(1, 7);
            Console.WriteLine($"Family Event Outcome: {familyEventOutcome}");

            switch (familyEventOutcome)
            {
                case 1:
                    Console.WriteLine("Pest Attack! Family loses half of the year’s crop.");
                    // Outcome: Reduce the amount of harvested crops in the household
                    household.Land.HarvestCrops();
                    break;
                case 2:
                case 3:
                    Console.WriteLine("New Baby! Add one child to the family.");
                    // Outcome: a new baby! Welcome to the family!
                    household.CreateChild();
                    break;
                default:
                    Console.WriteLine("No family event this year.");
                    // Outcome: No specific action for no family event
                    break;
            }
        }
    }
}