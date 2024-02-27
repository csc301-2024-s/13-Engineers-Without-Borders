using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
// Display a product's price as it is registered in the shop
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
