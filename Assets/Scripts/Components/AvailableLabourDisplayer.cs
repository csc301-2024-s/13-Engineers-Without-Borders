using Backend;
using TMPro;
using UnityEngine;

public class AvailableLabourDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;
    private int _availableLabour;

    void Update()
    {   
        _availableLabour = GameState.s_Player.Family.GetLabourPoints();

        if (GameState.s_Phase == 1) {
            _availableLabour -= (FarmManager.SelectedCells.Count * FarmManager.IrrigationLabour);
        } else if (GameState.s_Phase == 2) {
            _availableLabour -= FarmManager.SelectedCells.Count;
        }
        
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Format(formatString, _availableLabour);
    }
}
