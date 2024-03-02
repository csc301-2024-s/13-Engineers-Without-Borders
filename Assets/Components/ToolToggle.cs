using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
// For selecting a tool with which to click on farm cells
public class ToolToggle : MonoBehaviour
{
    [SerializeField] string toolName;
    private Toggle _toggle;

    // Start is called before the first frame update
    void Start()
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(OnChange);
    }

    void OnChange(bool value)
    {
        FarmManager.SelectedTool = value ? toolName : null;
        // if this toggle is clicked, the other selected toggle gets disabled, THEN this one gets enabled
        Debug.Log(FarmManager.SelectedTool);
    }
}
