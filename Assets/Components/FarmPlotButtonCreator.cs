using System;
using System.Collections;
using System.Collections.Generic;
using Backend;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// Author: Andy Wang
// Generate grid of farm plot buttons and set up their buttons/toggles so you can manage them
public class FarmPlotButtonCreator : MonoBehaviour
{
    [SerializeField] GameObject farmPlotBtnPrefab;  // the button to instantiate
    [SerializeField] GameObject farmGrid;  // grid container for the buttons

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = farmGrid.GetComponent<RectTransform>();

        for (var i = 0; i < GameState.s_Player.Land.Plots.Count; i++)
        {
            FarmPlot plot = GameState.s_Player.Land.Plots[i];
            GameObject btnClone = Instantiate(farmPlotBtnPrefab);
            SetUpFarmPlotManager(btnClone, plot);
            btnClone.transform.SetParent(farmGrid.transform);

            // Adjust grid size, but only every even loop since there are two rows
            if (i % 2 == 0)
                rt.sizeDelta = new Vector2((i / 2 + 1) * 400, 0);
        }
    }

    void SetUpFarmPlotManager(GameObject manager, FarmPlot plot)
    {
        Toggle seedToggle = manager.transform.Find("SeedLabel/Toggle").GetComponent<Toggle>();
        Toggle lowFertilizerToggle = manager.transform.Find("FertilizerLabel/LowToggle").GetComponent<Toggle>();
        Toggle highFertilizerToggle = manager.transform.Find("FertilizerLabel/HighToggle").GetComponent<Toggle>();

        // Initial toggle values
        seedToggle.isOn = plot.SeedType == 1;
        lowFertilizerToggle.isOn = plot.FertilizerType == FertilizerType.LOW_FERTILIZER;
        highFertilizerToggle.isOn = plot.FertilizerType == FertilizerType.HIGH_FERTILIZER;

        // When you want to add or remove HYC seed...
        seedToggle.onValueChanged.AddListener((bool value) =>
        {
            // Add HYC seed
            // Precondition: toggle is only interactable if you have HYC seeds
            if (value)
            {
                GameState.s_Player.Inventory.RemoveItem("HYC Seed");
                plot.SeedType = 1;
                return;
            }

            // else; take away HYC seed
            plot.SeedType = 0;
            GameState.s_Player.Inventory.AddItem("HYC Seed");
        });

        // Adding/removing fertilizer...
        lowFertilizerToggle.onValueChanged.AddListener(CreateFertilizerAction(plot, "Low Fertilizer"));
        highFertilizerToggle.onValueChanged.AddListener(CreateFertilizerAction(plot, "High Fertilizer"));
    }

    // Return the proper toggle handler for the given fertilizer type
    private UnityAction<bool> CreateFertilizerAction(FarmPlot plot, string fertilizerName)
    {
        return (bool value) =>
        {
            // Add fertilizer
            // Precondition: toggle is only interactable if you have HYC seeds
            if (value)
            {
                GameState.s_Player.Inventory.RemoveItem(fertilizerName);
                plot.FertilizerType = fertilizerName == "Low Fertilizer" ? FertilizerType.LOW_FERTILIZER : FertilizerType.HIGH_FERTILIZER;
                return;
            }

            // else; take away fertilizer
            // Precondition: the fertilizer toggles are in a group, so only one may be active at a time
            // This means if you disable a toggle, then both are off, so there is no fertilizer
            plot.FertilizerType = FertilizerType.NO_FERTILIZER;
            GameState.s_Player.Inventory.AddItem(fertilizerName);
        };
    }
}
