using Backend;
using TMPro;
using UnityEngine;

// author: Jacqueline Zhu
/// <summary>
/// Makes a text component show a summary of your family members.
/// </summary>
public class ShowFamilyMembers : MonoBehaviour
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
        _text.text = "Family Members: " + string.Format(text, GameState.s_Player.Family.GetChildrenAmount() + GameState.s_Player.Family.GetAdultAmount());
    }
}
