using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Assessment2 : MonoBehaviour
{
    UIDocument document;
    Button A;
    Button B;
    Button C;
    Button D;
    Button E;
    Button F;
    public UIDocument correct;
    public UIDocument wrong;
    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        VisualElement root = document.rootVisualElement;
        A = root.Q<Button>("ButtonA");
        B = root.Q<Button>("ButtonB");
        C = root.Q<Button>("ButtonC");
        D = root.Q<Button>("ButtonD");
        E = root.Q<Button>("ButtonE");
        F = root.Q<Button>("ButtonF");
        E.clicked += () => OnCorrectClick();
        A.clicked += () => OnWrongClick();
        B.clicked += () => OnWrongClick();
        C.clicked += () => OnWrongClick();
        D.clicked += () => OnWrongClick();
        F.clicked += () => OnWrongClick();

    }
    public void OnCorrectClick()
    {
        correct.gameObject.SetActive(true);
    }
    public void OnWrongClick()
    {
        wrong.gameObject.SetActive(true);
    }
}
