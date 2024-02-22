using System.Collections;
using System.Collections.Generic;
using Backend;
using TMPro;
using UnityEngine;

// Author: Andy Wang
// Display year, phase, weather
// Mostly a placeholder class
public class GameStateInfoDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Format(formatString, GameState.s_Year, GameState.s_Phase, GameState.s_WeatherIndex);
    }
}
