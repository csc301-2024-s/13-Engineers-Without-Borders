using System.Collections.Generic;
using UnityEngine;
using Backend;

// Original Author: Andy Wang
// Similar to GameState but specific to the Manage Farm scene, holding some variables used in that scene for convenience
public class FarmManager : MonoBehaviour
{
    public static string SelectedTool { get; set; } = null; // just make this a string for now lol

    public static List<FarmPlotCell> SelectedCells = new List<FarmPlotCell>();
    public static List<FarmPlotCell> IrrigatedCells = new List<FarmPlotCell>();
    public static PopupManager PopupManagerInstance { get; private set; }

    public const int IrrigationLabour = 2; // const for labour cost for irrigation in case we want to change later
    public const int HarvestLabour = 1;

    public static int LabourPoints { get; set; }  // upon loading the farm management screen, show how many labour points you can spend

    void Start()
    {
        LabourPoints = GameState.s_Player.Family.GetLabourPoints();
    }

    private void OnEnable()
    {
        SelectedCells.Clear();
    }

    // Harvests all currently selected Cells
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
            PopupManager.QueuePopup("Game Over", "You survived for 7 years! That's the end of the simulation.", "Hooray!");
            SceneUtils.LoadScene("Results");
        } else 
        {   
            GameState.AdvanceToPhaseThree(); // in case something broke
        }
    }

    // Irrigates all currently selected Cells
    public static void IrrigateSelectedCells()
    {
        foreach (FarmPlotCell cell in SelectedCells)
        {
            cell.Plot.Irrigated = true;
            cell.RefreshVisuals();
        }
        GameState.AdvanceToPhaseTwo();
    }

    public static void ClearSelectedCells()
    {
        SelectedCells.Clear();
    }


}
