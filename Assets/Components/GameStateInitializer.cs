using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backend;

public class GameStateInitializer : MonoBehaviour
{   
    void Awake() {
        Household player = new(5000, "Test", 1, 2, 5);

        GameState.Initialize(player);
        GameState.s_Player = player;
        GameState.s_Households = new Household[] { player };
        GameState.s_Year = 1;
        GameState.s_Phase = 2;
        GameState.s_WeatherIndex = 3;

        Adult worker = new("John", "Doe");
        GameState.s_Player.Land.Plots[0].Worker = worker;
        GameState.s_Player.Land.Plots[1].Worker = worker;
        GameState.s_Player.Land.Plots[2].Worker = worker;
        GameState.s_Player.Land.Plots[3].Worker = worker;
        GameState.s_Player.Land.Plots[4].Worker = worker;

        GameState.s_Player.Land.canBeHarvested = true;

        Market.AddProduct("Wheat", 10, "Wheat");
    }
}
