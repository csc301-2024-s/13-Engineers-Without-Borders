using System.Collections;
using System.Collections.Generic;
using Backend;
using TMPro;
using UnityEngine;

// Author: Andy Wang
// Display the player's cash in a formatted string
public class PlayerMoneyDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    // It's probably more performant to connect to an event whenever the money changes, but this is easier and simpler to write
    // and also I'm running out of time
    void Update()
    {
        _text.text = string.Format(formatString, GameState.s_Player.Money);
    }
}
