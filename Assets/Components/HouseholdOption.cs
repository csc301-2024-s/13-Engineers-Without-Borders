using Backend;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang & TODO: FILL IN YOUR NAME HERE
// Code for a household selection button, so when you click on this you select your household
public class HouseholdOption : MonoBehaviour
{
    public Household Household { get; set; }
    private Button _btn;

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        GameState.Initialize(Household);
        GameState.AdvanceToPhaseOne();
    }
}
