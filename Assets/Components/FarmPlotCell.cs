using UnityEngine;
using Backend;
using UnityEngine.UI;
using TMPro;

// Original Author: Andy Wang
public class FarmPlotCell : MonoBehaviour
{
    [SerializeField] Color irrigatedColor;
    [SerializeField] Color irrigatedPressedColor;

    private Color _origColor;
    private Color _origPressedColor;
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

        _hycLabel = transform.Find("HYC").GetComponent<TextMeshProUGUI>();
        _fertilizerLabel = transform.Find("Fertilizer").GetComponent<TextMeshProUGUI>();
    }

    // Update this cell visually based on the attributes of the assigned farm plot
    void Update()
    {
        if (Plot == null)
        {
            return;
        }

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

        // change colour to blue if irrigated
        var colors = _btn.colors;
        if (Plot.Irrigated)
        {
            colors.normalColor = irrigatedColor;
            colors.pressedColor = irrigatedPressedColor;
        }
        else
        {
            colors.normalColor = _origColor;
            colors.pressedColor = _origPressedColor;
        }
    }

    // Select or deselect this farm cell on click
    // Also handle planting/harvesting/irrigating depending on phase (read FarmManager fields)
    // Precondition: if the player has a tool selected, that means they can use it in the first place
    void HandleClick()
    {
        Household owner = Plot.Owner;
        Inventory inventory = owner.Inventory;

        // Add or remove HYC Seed
        if (FarmManager.SelectedTool == "HYC Seed")
        {
            if (Plot.SeedType == SeedType.Regular && inventory.Contains("HYC Seed"))
            {
                Plot.SeedType = SeedType.HYC;
                inventory.RemoveItem("HYC Seed");
            }
            else
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
            } else if (inventory.Contains(selectedFertilizerName))
            {  // the plot has the other fertilizer type, so replace it
                Plot.FertilizerType = selectedFertilizer;
                inventory.RemoveItem(selectedFertilizerName);
                inventory.AddItem(otherFertilizerName);
            }
        }
    }
}
