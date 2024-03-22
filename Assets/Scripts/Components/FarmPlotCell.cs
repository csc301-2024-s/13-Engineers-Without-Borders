using UnityEngine;
using Backend;
using UnityEngine.UI;
using TMPro;
using System;

// Original Author: Andy Wang
public class FarmPlotCell : MonoBehaviour
{
    [SerializeField] Color irrigatedColor;
    [SerializeField] Color irrigatedPressedColor;
    [SerializeField] Color irrigatedSelectedColor;
    [SerializeField] Color irrigatedHighlightedColor;
    [SerializeField] Color irrigatedDisabledColor;

    private Outline _outline;
    private Color _origColor;
    private Color _origPressedColor;
    private Color _origSelectedColor;
    private Color _origHighlightedColor;
    private Color _origDisabledColor;
    private Button _btn;
    private TextMeshProUGUI _hycLabel;
    private TextMeshProUGUI _fertilizerLabel;

    public FarmPlot Plot { get; set; }

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(HandleClick);
        _origColor = _btn.colors.normalColor;
        _origPressedColor = _btn.colors.pressedColor;
        _origSelectedColor = _btn.colors.selectedColor;
        _origDisabledColor = _btn.colors.disabledColor;
        _origHighlightedColor = _btn.colors.highlightedColor;

        _hycLabel = transform.Find("HYC").GetComponent<TextMeshProUGUI>();
        _fertilizerLabel = transform.Find("Fertilizer").GetComponent<TextMeshProUGUI>();

        _outline = GetComponent<Outline>();

    }

    // Update this cell visually based on the attributes of the assigned farm plot
    void Update()
    {
        RefreshVisuals();
        RefreshStatus();
        _outline.enabled = FarmManager.SelectedCells.Contains(this);
    }

    // Refreshes visual state of the farm plot cell
    public void RefreshVisuals()
    {
        var colors = _btn.colors;
        if (Plot.Irrigated)
        {
            colors.normalColor = irrigatedColor;
            colors.pressedColor = irrigatedPressedColor;
            colors.selectedColor = irrigatedSelectedColor;
            colors.highlightedColor = irrigatedHighlightedColor;
            colors.disabledColor = irrigatedDisabledColor;
        }
        else
        {
            colors.normalColor = _origColor;
            colors.pressedColor = _origPressedColor;
            colors.selectedColor = _origSelectedColor;
            colors.highlightedColor = _origHighlightedColor;
            colors.disabledColor = _origDisabledColor;
        }
        _btn.colors = colors;
    }

    public void RefreshStatus()
    {
        if (Plot.SeedType == SeedType.HYC)
        {
            _hycLabel.text = "HYC";
        }
        else
        {
            _hycLabel.text = "";
        }

        if (Plot.FertilizerType == FertilizerType.Low)
        {
            _fertilizerLabel.text = "Low";
        }
        else if (Plot.FertilizerType == FertilizerType.High)
        {
            _fertilizerLabel.text = "High";
        }
        else
        {
            _fertilizerLabel.text = "";
        }
    }

    // Select or deselect this farm cell on click
    // Also handle planting/harvesting/irrigating depending on phase (read FarmManager fields)
    // Precondition: if the player has a tool selected, that means they can use it in the first place
    void HandleClick()
    {
        Household owner = Plot.Owner;
        Inventory inventory = owner.Inventory;

        // Phase 3 - planting phase
        if (GameState.s_Phase == 3)
        {
            // Add or remove HYC Seed
            if (FarmManager.SelectedTool == "HYC Seed")
            {
                if (Plot.SeedType == SeedType.Regular && inventory.Contains("HYC Seed"))
                {
                    Plot.SeedType = SeedType.HYC;
                    inventory.RemoveItem("HYC Seed");
                }
                else if (Plot.SeedType == SeedType.HYC)
                {
                    Plot.SeedType = SeedType.Regular;
                    inventory.AddItem("HYC Seed");
                }
            }

            // Add or remove fertilizer
            // Must replace current fertilizer type with selected one, must put it back in inventory
            // If cell already has selected fertilizer, tapping it should remove it
            if (FarmManager.SelectedTool == "Low Fertilizer" || FarmManager.SelectedTool == "High Fertilizer")
            {
                // if this becomes too cumbersome, create a static util function to convert between the two
                string selectedFertilizerName = FarmManager.SelectedTool;
                FertilizerType selectedFertilizer = selectedFertilizerName == "Low Fertilizer" ? FertilizerType.Low : FertilizerType.High;
                string otherFertilizerName = selectedFertilizerName == "High Fertilizer" ? "Low Fertilizer" : "High Fertilizer";

                // no fertilizer? simply add new fertilizer type
                if (Plot.FertilizerType == FertilizerType.None && inventory.Contains(selectedFertilizerName))
                {
                    Plot.FertilizerType = selectedFertilizer;
                    inventory.RemoveItem(selectedFertilizerName);
                }
                else if (Plot.FertilizerType == selectedFertilizer)
                {  // the plot already has the fertilizer you selected, so it should be removed
                    Plot.FertilizerType = FertilizerType.None;
                    inventory.AddItem(selectedFertilizerName);
                }
                else if (inventory.Contains(selectedFertilizerName))
                {  // the plot has the other fertilizer type, so replace it
                    Plot.FertilizerType = selectedFertilizer;
                    inventory.RemoveItem(selectedFertilizerName);
                    inventory.AddItem(otherFertilizerName);
                }
            }
            return;
        }

        // else - phase 1 - irrigation phase, or phase 2 - harvest phase
        int numTubewells = inventory.GetAmount("Tubewell");
        int maxSelectedCells = GameState.s_Phase == 1 ? Math.Min(Farmland.MaxPlots, numTubewells * 10) : Farmland.MaxPlots;
        int labourCost = GameState.s_Phase == 1 ? FarmManager.IrrigationLabour : FarmManager.HarvestLabour;

        // Updates selection status in FarmManager, only adds if there is still labour remaining
        if (!FarmManager.SelectedCells.Contains(this))
        {
            if (FarmManager.LabourPoints >= labourCost && FarmManager.SelectedCells.Count < maxSelectedCells)
            {
                FarmManager.SelectedCells.Add(this);
                FarmManager.LabourPoints -= labourCost;
            }
        }
        else
        {
            FarmManager.SelectedCells.Remove(this);
            FarmManager.LabourPoints += labourCost;
        }
    }
}
