using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Make a text component show how many farm plots you can irrigate depending on your owned number of tubewells.
/// </summary>
public class MaxIrrigationDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Format(formatString, GameState.s_Player.Inventory.GetAmount("Tubewell") * Market.PlotsPerTubewell);
    }
}
