using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
// Display a product's description as it is registered in the shop
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
