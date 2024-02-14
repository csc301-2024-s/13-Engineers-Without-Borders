using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        static void Initalize(Household Player)
        {

        }

        static void AdvanceToPhaseOne()
        {

        }

        static void AdvanceToPhaseTwo()
        {
            foreach (Household household in s_Households) {
                household.CalculateRemainingYield();
                household.SellWheat();
            }

            s_Player.CalculateRemainingYield();
            s_Player.SellWheat();
        }

        static void AdvanceToPhaseThree()
        {

        }
    }
}
