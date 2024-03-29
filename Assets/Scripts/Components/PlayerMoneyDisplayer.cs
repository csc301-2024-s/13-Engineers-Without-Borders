using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Make a text component display your money with a formatted string.
/// </summary>
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
