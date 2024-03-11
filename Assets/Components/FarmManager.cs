using System.Collections.Generic;
using UnityEngine;
using Backend;

// Original Author: Andy Wang
// Similar to GameState but specific to the Manage Farm scene, holding some variables used in that scene for convenience
public class FarmManager : MonoBehaviour
{
    // TODO:
    // - Need a field to keep track of selected farm cells
    // - When farm cell is pressed while selected, it should be unselected
    // - In phase 2 when you press harvest button, only selected farm cells should be harvested
    // - In phase 3, need to keep track of which tool is selected (HYC seeed or fertilizer?) which can be read statically

    public static string SelectedTool { get; set; } = null; // just make this a string for now lol

    public static List<FarmPlotCell> SelectedCells = new List<FarmPlotCell>();
    public static List<FarmPlotCell> IrrigatedCells = new List<FarmPlotCell>();

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
        foreach (FarmPlotCell cell in SelectedCells)
        {
            cell.Plot.Owner.Wheat += cell.Plot.GetYield();
            cell.Plot.ClearPlot();
        }

        // 7th year is the last one in the game, go to results after last harvest
        if (GameState.s_Year == 7)
        {
            SceneUtils.LoadScene("Results");
        }
        else
        {
            GameState.AdvanceToPhaseThree();
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
