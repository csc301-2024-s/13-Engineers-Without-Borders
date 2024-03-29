using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Make a text component dislay the description of a given product in the market.
/// </summary>
public class ProductDescriptionDisplayer : MonoBehaviour
{
    [SerializeField] string productName;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = Market.GetDescription(productName);
    }
}
