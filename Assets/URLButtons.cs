using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class URLButtons : MonoBehaviour
{
    UIDocument document;
    Button ewb;
    Button fb;
    Button ins;
    Button linkedin;
    Button twitter;
    Button privacy;
    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        VisualElement root = document.rootVisualElement;
        ewb = root.Q<Button>("ewb");
        fb = root.Q<Button>("fb");
        ins = root.Q<Button>("ins");
        linkedin = root.Q<Button>("linkedin");
        twitter = root.Q<Button>("twitter");
        privacy = root.Q<Button>("privacy");

        ewb.clicked += () => OnEwbClick();
        fb.clicked += () => OnFbClick();
        ins.clicked += () => OnInsClick();
        linkedin.clicked += () => OnLinkedinClick();
        twitter.clicked += () => OnTwitterClick();
        privacy.clicked += () => OnPrivacyPolicyClick();
    }
    public void OnEwbClick()
    {
        Debug.Log("ewb");
        Application.OpenURL("https://www.torontopro.ewb.ca/");
    }
    public void OnFbClick()
    {
        Debug.Log("fb");
        Application.OpenURL("https://www.facebook.com/EWBToronto/");
    }
    public void OnInsClick()
    {
        Application.OpenURL("https://www.instagram.com/ewb.to/");
    }
    public void OnLinkedinClick()
    {
        Application.OpenURL("https://www.linkedin.com/company/ewb-toronto-professional-chapter");
    }
    public void OnTwitterClick()
    {
        Application.OpenURL("https://twitter.com/EWBToronto");
    }
    public void OnPrivacyPolicyClick()
    {
        Application.OpenURL("https://www.torontopro.ewb.ca/w4tw-privacy-policy");
    }
}
