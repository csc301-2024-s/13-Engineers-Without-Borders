using UnityEngine;
using TMPro;
using Backend;

/// <summary>
/// Make a text component show current year's wheat price.
/// </summary>
public class ShowWheatPrice : MonoBehaviour
{
    /// <summary>
    /// The text component to modify.
    /// </summary>
    public TextMeshProUGUI wheatPriceText;
    [SerializeField] string text;

    // Update is called once per frame
    void Update()
    {
        wheatPriceText.text = "Wheat Price: " + Market.GetPrice("Wheat");
    }
}
