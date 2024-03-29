using Backend;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Generate grid of farm plot cells in the farm management scene.
/// </summary>
public class FarmPlotCellPopulator : MonoBehaviour
{
    [SerializeField] GameObject farmPlotCellPrefab;  // the button to instantiate
    [SerializeField] GameObject farmGrid;  // grid container for the buttons

    // Start is called before the first frame update
    void Start()
    {
        farmGrid.transform.SetParent(farmGrid.transform.parent, false); // do this so scaling works??

        for (var i = 0; i < GameState.s_Player.Land.Plots.Count; i++)
        {
            FarmPlot plot = GameState.s_Player.Land.Plots[i];
            GameObject cellClone = Instantiate(farmPlotCellPrefab);
            SetUpFarmPlotManager(cellClone, plot);
            cellClone.transform.SetParent(farmGrid.transform, false);
        }
    }

    void SetUpFarmPlotManager(GameObject cell, FarmPlot plot)
    {
        FarmPlotCell cellScript = cell.GetComponent<FarmPlotCell>();
        cellScript.Plot = plot;
    }
}
