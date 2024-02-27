using Backend;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// Original Author: Andy Wang
// Generate grid of farm plot cells
public class FarmPlotCellPopulator : MonoBehaviour
{
    [SerializeField] GameObject farmPlotCellPrefab;  // the button to instantiate
    [SerializeField] GameObject farmGrid;  // grid container for the buttons

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = farmGrid.GetComponent<RectTransform>();
        farmGrid.transform.SetParent(farmGrid.transform.parent, false);

        for (var i = 0; i < GameState.s_Player.Land.Plots.Count; i++)
        {
            FarmPlot plot = GameState.s_Player.Land.Plots[i];
            GameObject cellClone = Instantiate(farmPlotCellPrefab);
            SetUpFarmPlotManager(cellClone, plot);
            cellClone.transform.SetParent(farmGrid.transform, false);  // do this so scaling works??
        }
    }

    void SetUpFarmPlotManager(GameObject cell, FarmPlot plot)
    {
        FarmPlotCell cellScript = cell.GetComponent<FarmPlotCell>();
        cellScript.Plot = plot;
    }
}
