using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Kevin
public class ClosePopUpOnClick : MonoBehaviour
{
    [SerializeField] private GameObject PopUpWindow;

    void Start() {
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(OnClick);
        }
    }

    public void OnClick() {
        PopUpWindow.SetActive(false);
    }
}
