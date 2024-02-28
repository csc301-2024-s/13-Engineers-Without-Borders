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

    // Add or remove seed type/fertilizer/irrigation/select for harvest on click, depending on phase
    void HandleClick()
    {
        Debug.Log("You clicked me!");
        // TODO
    }
}
