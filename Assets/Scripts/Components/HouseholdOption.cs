using Backend;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
/// <summary>
/// A household selection button, click it to choose the household you play as.
/// </summary>
public class HouseholdOption : MonoBehaviour
{
    /// <summary>
    /// The household that the player will play as.
    /// </summary>
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
