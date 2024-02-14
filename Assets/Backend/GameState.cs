using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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

        public static void Initialize(Household Player)
        {

        }

        public static void AdvanceToPhaseOne()
        {

        }

        public static void AdvanceToPhaseTwo()
        {

        }

        public static void AdvanceToPhaseThree()
        {
            SceneUtils.LoadScene("Market");
            // TODO: if player's wheat is negative, alert them
        }
    }
}
