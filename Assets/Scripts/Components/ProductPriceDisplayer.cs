using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Make a text component display the price of a product in the market given a format string.
/// </summary>
public class ProductPriceDisplayer : MonoBehaviour
{
    [SerializeField] string productName;
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Format(formatString, Market.GetPrice(productName));
    }
}
