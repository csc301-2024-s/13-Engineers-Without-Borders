using System.Collections;
using System.Collections.Generic;
using Backend;
using UnityEngine;

// Author: Andy Wang
// For this build only, initialize the game state at the build's beginning since this is separate from Phase 1
public class GameStateInitializer : MonoBehaviour
{
    void Awake() {
        // do nothing if already initialized
        if (GameState.s_Player != null) {
            return;
        }

        // For now, choose a random predefined household
        Household player = GameState.s_PredefinedHouseholds[Random.Range(0, GameState.s_PredefinedHouseholds.Length - 1)];
        player.Money = 10000;  // for this deliverable, give money cheats

        GameState.Initialize(player);

        // overwrite
        GameState.s_Phase = 3;
    }
}
