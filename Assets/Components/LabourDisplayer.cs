using Backend;
using TMPro;
using UnityEngine;

// Author: Hoa Nguyen
// Display the number of hired workers in the family
public class LabourDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    private TextMeshProUGUI _text;

    void Update()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Format(formatString, GameState.s_Player.Family.GetHiredWorkerAmount());
    }
}
