using Backend;
using TMPro;
using UnityEngine;

/// <summary>
/// Add to an object with a TextMeshPro component to make it display the player's total wheat.
/// </summary>
public class DisplayTotalWheat : MonoBehaviour
{
    [SerializeField] string text;
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Total Wheat: " + string.Format(text, GameState.s_Player.Wheat);
    }
}
