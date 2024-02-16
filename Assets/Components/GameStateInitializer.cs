using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backend

public class GameStateInitializer : MonoBehaviour
{   
    void Awake() {
        Household player = new(5000, "Test", 2, 2, 10);

        GameState.Initialize(player);
        GameState.s_Player = player;
        GameState.s_Households = new Household[] { player };
        GameState.s_Year = 1;
        GameState.s_Phase = 2;
        GameState.s_WeatherIndex = 3;
    }
}
