using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupButton : MonoBehaviour
{
    UIDocument buttonDocument;
    Button uiButton;
    void OnEnable() 
    {
        buttonDocument = GetComponent<UIDocument>();
        uiButton = buttonDocument.rootVisualElement.Q("popup-button") as Button;
        uiButton.RegisterCallback<ClickEvent>(OnButtonClick);
    }
    public void OnButtonClick(ClickEvent evt)
    {
        buttonDocument.gameObject.SetActive(false);
    }
}
