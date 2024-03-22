using Backend;
using TMPro;
using UnityEngine;

// author: Jacqueline Zhu
public class DisplayWeather : MonoBehaviour
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
        _text.text = "Weather: " + string.Format(text, GameState.s_WeatherIndex);
    }
}

