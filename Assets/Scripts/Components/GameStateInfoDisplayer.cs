using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
// Display year, phase, weather
// Mostly a placeholder class
public class GameStateInfoDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Update()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Format(formatString, GameState.s_Year, GetPhaseString(), GameState.s_WeatherIndex);
    }

    string GetPhaseString()
    {
        if (GameState.s_Phase == 1)
        {
            return "1 - Growing Season";
        }
        else if (GameState.s_Phase == 2)
        {
            return "2 - Harvest Season";
        }
        else
        {
            return "3 - Planting Season";
        }
    }
}
