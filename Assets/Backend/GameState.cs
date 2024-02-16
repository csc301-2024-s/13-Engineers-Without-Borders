using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

/*
 * This class represents the States of the game
 */
namespace Backend
{
    public static class GameState
    {
        public static int s_Year;
        public static int s_Phase;
        public static int s_WeatherIndex;
        public static Household s_Player;
        public static Household[] s_Households;
        public static Household[] s_PredefinedHouseholds = new Household[]
        {
            new Household(500, "Madhar", 3, 2, 3),
            new Household(500, "Barlch", 4, 2, 3),
            new Household(500, "Rama", 4, 3, 4),
            new Household(500, "Dulai", 4, 5, 4),
            new Household(500, "Grewal", 4, 6, 5),
            new Household(500, "Kahlon", 3, 2, 4),
            new Household(500, "Aujla", 4, 2, 2),
            new Household(500, "Sandha", 4, 3, 6),
            new Household(500, "Kohli", 0, 2, 1),
            new Household(500, "Gill", 2, 4, 7),
            new Household(500, "Dhillon", 1, 2, 2),
            new Household(500, "Singh", 2, 3, 3),
            new Household(500, "Kapoor", 3, 5, 5),
            new Household(500, "Bhatia", 2, 2, 2),
            new Household(500, "Gupta", 3, 5, 7)
        };

        // Initialize the game
        public static void Initialize(Household Player)
        {
            s_Player = Player;
            s_Year = 1;
            s_Phase = 0;
            System.Random rand = new Random();
            s_WeatherIndex = rand.Next(1, 6);
            s_Households = new Household[] { Player };

            Market.Initialize();
        }

        // (Year 2+ only) Choose random village event and household event for each household
        //Read WorkshopSheets/Fate Seeds and Tools Cards.pdf
        //These can be implemented however you think makes sense; make sure it's scalable (easy to add new events), can affect GameState and other important variables, and Household events should be able to affect specific households
        //Possible for there to be no village event, or for a household to have no event
        public static void AdvanceToPhaseOne()
        {
            System.Random rand = new Random();
            s_WeatherIndex = rand.Next(1, 6);
            s_Phase = 1;
            Market.UpdateWheatPrice();
            //Village event

            foreach (Household household in s_Households)
            {
                
                //Household event
            }
        }

        public static void AdvanceToPhaseTwo()
        {
            foreach (Household household in s_Households) {
                household.Land.canBeHarvested = true;
            }
        }

        public static void AdvanceToPhaseThree()
        {
            SceneUtils.LoadScene("Market");
            // TODO: if player's wheat is negative, alert them
        }
    }
}
