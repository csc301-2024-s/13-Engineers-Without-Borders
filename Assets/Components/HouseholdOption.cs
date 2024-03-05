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

        // TODO: assign a function to <_btn.onClick> so that when this button gets clicked, set the global player variable to the given Household
        // also invoke SceneUtils.LoadScene to load the ManageHousehold scene
    }
}
