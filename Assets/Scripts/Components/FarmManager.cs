using System.Collections.Generic;
using UnityEngine;
using Backend;

// Original Author: Andy Wang
/// <summary>
/// Holds the main gameplay logic during the farm management scene (phases 1, 2, 3).
/// Handles the irrigation button and harvest button logic.
/// </summary>
public class FarmManager : MonoBehaviour
{
    /// <summary>
    /// The tool currently selected during phase 3.
    /// </summary>
    public static string SelectedTool { get; set; } = null; // just make this a string for now lol

    /// <summary>
    /// Selected farm plot cells during phases 1/2.
    /// </summary>
    public static List<FarmPlotCell> SelectedCells = new List<FarmPlotCell>();

    /// <summary>
    /// Labour cost of selecting a plot cell to be irrigated.
    /// </summary>
    public const int IrrigationLabour = 2; // const for labour cost for irrigation in case we want to change later
    
    /// <summary>
    /// Labour cost of selecting a plot cell to be harvested.
    /// </summary>
    public const int HarvestLabour = 1;

    /// <summary>
    /// How many labour points you currently have in this phase.
    /// </summary>
    public static int LabourPoints { get; set; }  // upon loading the farm management screen, show how many labour points you can spend

    void Start()
    {
        LabourPoints = GameState.s_Player.Family.GetLabourPoints();
    }

    private void OnEnable()
    {
        SelectedCells.Clear();
    }

    /// <summary>
    /// Harvests all selected farm cells.
    /// </summary>
    public static void HarvestSelectedCells()
    {
        int gain = 0;
        foreach (FarmPlotCell cell in SelectedCells)
        {
            gain += cell.Plot.GetYield();
            cell.Plot.ClearPlot();
        }

        // subtract consumption
        int consumption = GameState.s_Player.Family.GetTotalConsumption();
        GameState.s_Player.Wheat = GameState.s_Player.Wheat + gain - consumption;

        if (GameState.s_Player.Wheat < 0)
            PopupManager.QueuePopup("Notice", $"You harvested: {gain} wheat<br>Your family needs: {consumption} wheat<br>Wheat left: {GameState.s_Player.Wheat}", "Okay");
        else
            PopupManager.QueuePopup("Notice", $"You harvested: {gain} wheat<br>Your family needs: {consumption} wheat<br>Wheat left: {GameState.s_Player.Wheat}<br>Total value: ${GameState.s_Player.Wheat * Market.GetPrice("Wheat")}", "Okay");

        // 7th year is the last one in the game, go to results after last harvest
        if (GameState.s_Year == 7)
        {
            // Sell the remaining wheat for extra final score
            Market.Sell(GameState.s_Player, GameState.s_Player.Wheat, "Wheat");
            PopupManager.QueuePopup("Game Over", "You survived for 7 years! That's the end of the simulation.", "Hooray!");
            SceneUtils.LoadScene("Results");
        } else 
        {   
            GameState.AdvanceToPhaseThree(); // in case something broke
        }
    }

    /// <summary>
    /// Harvests all selected farm cells.
    /// </summary>
    public static void IrrigateSelectedCells()
    {
        foreach (FarmPlotCell cell in SelectedCells)
        {
            cell.Plot.Irrigated = true;
            cell.RefreshVisuals();
        }
        GameState.AdvanceToPhaseTwo();
    }

    /// <summary>
    /// Deselect all farm plot cells.
    /// </summary>
    public static void ClearSelectedCells()
    {
        SelectedCells.Clear();
    }


}
