using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
// Displays how many of a certain product you have in your inventory
public class NumFamilyMembersDisplayer : MonoBehaviour
{
    [SerializeField] string formatString;
    [SerializeField] bool countAdults;  // if true, show adults, else show children
    private TextMeshProUGUI _text;

    void Update()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = string.Format(formatString,
            countAdults ? GameState.s_Player.Family.GetAdultAmount() + GameState.s_Player.Family.GetHiredWorkerAmount() :
            GameState.s_Player.Family.GetChildrenAmount());
    }
}
