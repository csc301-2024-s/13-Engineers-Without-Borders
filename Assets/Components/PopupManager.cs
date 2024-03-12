using System; 
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Author: Bill Guo
public class PopupManager : MonoBehaviour
{
    [SerializeField] private Popup popupPrefab;
    [SerializeField] private Canvas hud;
    private Popup popupInstance;
    public static event Action OnPopupClosed; 

    private void Awake()
    {
        hud = GameObject.Find("HUD").GetComponent<Canvas>();
        if (popupInstance == null)
        {
            popupInstance = Instantiate(popupPrefab, hud.transform, false);
            popupInstance.gameObject.SetActive(false);
        }
    }

    // Sets up the popup and activates it in the scene
    public void ShowPopup(string message)
    {
        if (popupInstance != null)
        {
            TMP_Text textComponent = popupInstance.GetComponentInChildren<TMP_Text>();
            if (textComponent != null)
            {
                textComponent.text = message;
            }

            Button closeButton = popupInstance.GetComponentInChildren<Button>();
            if (closeButton != null)
            {
                closeButton.onClick.RemoveAllListeners();
                closeButton.onClick.AddListener(() => ClosePopup());
            }

            popupInstance.gameObject.SetActive(true);
        }
    }

    // Closes the popup and signals that the popup was closed
    private void ClosePopup()
    {
        if (popupInstance != null)
        {
            popupInstance.gameObject.SetActive(false);
            OnPopupClosed?.Invoke(); 
        }
    }
}