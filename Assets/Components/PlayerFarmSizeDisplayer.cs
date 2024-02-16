using System.Collections;
using System.Collections.Generic;
using Backend;
using TMPro;
using UnityEngine;

// Author: Andy Wang
// Display a product's price as it is registered in the shop
public class PlayerFarmSizeDisplayer : MonoBehaviour
{
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = GameState.s_Player.Land.Plots.Count.ToString();
    }
}
