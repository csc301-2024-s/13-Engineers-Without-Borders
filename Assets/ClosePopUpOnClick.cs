using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosePopUpOnClick : MonoBehaviour
{
    [SerializeField] private PopUp PopUpWindow;

    void Start() {
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(OnClick);
        }
    }

    public void OnClick() {
        PopUpWindow.gameObject.SetActive(false);
    }
}
