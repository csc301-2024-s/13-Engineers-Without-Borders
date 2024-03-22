using UnityEngine;
using UnityEngine.UI;

// Original Author: Kevin
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
