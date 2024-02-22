using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Authors: Kevin, Andy
// Turn a button into a toggle for another UI element
public class TabToggler : MonoBehaviour
{
    [SerializeField] GameObject tab;
    [SerializeField] string closedText;  // text to display when closed
    [SerializeField] string openedText;  // text to display when opened
    [SerializeField] TextMeshProUGUI btnText;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Toggle);
        btnText.text = closedText;
    }

    // Toggle between showing and not showing on click
    public void Toggle()
    {
        if (tab.activeSelf)
        {  // already opened
            btnText.text = openedText;
            tab.SetActive(false);
        }
        else
        {  // already closed
            btnText.text = closedText;
            tab.SetActive(true);
        }
    }
}
