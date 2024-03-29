using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Makes a text component display how many of a given product you have in your inventory based on a format string.
/// </summary>
public class ProductAmountDisplayer : MonoBehaviour
{
    [SerializeField] string productName;
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;

    void Update()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Format(formatString, GameState.s_Player.Inventory.GetAmount(productName));
    }
}
