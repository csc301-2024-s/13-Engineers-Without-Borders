using System.Collections;
using System.Collections.Generic;
using Backend;
using TMPro;
using UnityEngine;

// Author: Andy Wang
// Displays how many of a certain product you have in your inventory
public class ProductAmountDisplayer : MonoBehaviour
{
    [SerializeField] string productName;
    private TextMeshProUGUI _text;

    void Update()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = GameState.s_Player.Inventory.GetAmount(productName).ToString();
    }
}
