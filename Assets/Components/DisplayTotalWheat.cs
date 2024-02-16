using Backend;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
