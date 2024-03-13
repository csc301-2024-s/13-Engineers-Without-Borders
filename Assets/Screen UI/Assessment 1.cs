using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AnswerCorrect1 : MonoBehaviour
{
    UIDocument document;
    Button A;
    Button B;
    Button C;
    Button D;
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
        B.clicked += () => OnCorrectClick();
        A.clicked += () => OnWrongClick();
        C.clicked += () => OnWrongClick();
        D.clicked += () => OnWrongClick();

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
