using System.Collections;
using System.Collections.Generic;
using Backend;
using UnityEngine;

// Author: Andy Wang
// For this build only, initialize the game state at the build's beginning since this is separate from Phase 1
public class GameStateInitializer : MonoBehaviour
{
    void Awake() {
        DontDestroyOnLoad(gameObject);  // for this deliverable, initializer should persist so it doesn't re-initialize when re-entering the shop

        // For now, create a placeholder household
        Household player = new(10000, "Test", 2, 2, 4)
        {
            Wheat = 100
        };

        // TODO: one the initialize method has been implemented, uncomment below
        // GameState.Initialize(player);
        GameState.s_Player = player;
        GameState.s_Households = new Household[] { player };
        GameState.s_Year = 1;
        GameState.s_Phase = 3;
        GameState.s_WeatherIndex = 1;
    }
}
