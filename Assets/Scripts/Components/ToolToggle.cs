using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
/// <summary>
/// A toggle for selecting which tool to use during Phase 3.
/// </summary>
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
    }
}
