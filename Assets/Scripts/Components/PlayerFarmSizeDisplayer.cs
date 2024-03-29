using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Makes a text component show how many farm plots you own.
/// </summary>
public class PlayerFarmSizeDisplayer : MonoBehaviour
{
    private TextMeshProUGUI _text;

    void Update()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = $"{GameState.s_Player.Land.Plots.Count} plots";
    }
}
