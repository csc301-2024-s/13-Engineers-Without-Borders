using UnityEngine;
using UnityEngine.UI;

// Original Author: Kevin
/// <summary>
/// On click, close a specified game object. Place on a component with a Button.
/// </summary>
public class ClosePopUpOnClick : MonoBehaviour
{
    [SerializeField] private GameObject PopUpWindow;

    void Start() {
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(OnClick);
        }
    }

    /// <summary>
    /// Set object specified by serialized field to be inactive.
    /// </summary>
    public void OnClick() {
        PopUpWindow.SetActive(false);
    }
}
