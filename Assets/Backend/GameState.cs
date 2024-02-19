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

        // Initialize the game
        public static void Initialize(Household Player)
        {
            s_Player = Player;
            s_Year = 1;
            s_Phase = 0;
            System.Random rand = new Random();
            s_WeatherIndex = rand.Next(1, 6);
            s_Households = new Household[] { Player };

        }

        public static void AdvanceToPhaseOne()
        {
            System.Random rand = new Random();
            s_WeatherIndex = rand.Next(1, 6);
            s_Phase = 1;
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

        }
    }
}
