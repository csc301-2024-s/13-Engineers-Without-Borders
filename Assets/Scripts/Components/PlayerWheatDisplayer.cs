using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
/// <summary>
/// Display the player's wheat in a formatted string.
/// </summary>
public class PlayerWheatDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = string.Format(formatString, GameState.s_Player.Wheat);
    }
}
