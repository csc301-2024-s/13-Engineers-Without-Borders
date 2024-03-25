using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
// Show how the max amount of plots you can irrigate based on your number of tubewells
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
