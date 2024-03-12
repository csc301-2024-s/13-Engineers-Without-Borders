using Backend;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
// Used to make a button advance phase on click
public class AdvancePhaseOnClick : MonoBehaviour
{
    [SerializeField] [Range(1, 3)] int phase;  // should be from 1 to 3, but it's zero-indexed


    void Start() {
        // If on an object with a button component, assign it automatically
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(OnClick);
        }
    }

    public void OnClick() {
        switch (GameState.s_Phase) {
            case 0:
                GameState.AdvanceToPhaseOne();
                break;
            case 1:
                GameState.AdvanceToPhaseTwo();
                break;
            case 2:
                GameState.AdvanceToPhaseThree();
                break;
            default:
                GameState.AdvanceToPhaseOne();
                break;
        }
        
        FarmManager.ClearSelectedCells();
        FarmManager.SelectedTool = null;
    }

}
