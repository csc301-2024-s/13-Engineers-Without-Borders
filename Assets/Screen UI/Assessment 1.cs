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

    VisualElement wrongA;
    VisualElement correctB;
    VisualElement wrongC;
    VisualElement wrongD;
    Button next;
    private void OnEnable()
    {
        document = GetComponent<UIDocument>();
        VisualElement root = document.rootVisualElement;
        A = root.Q<Button>("ButtonA");
        B = root.Q<Button>("ButtonB");
        C = root.Q<Button>("ButtonC");
        D = root.Q<Button>("ButtonD");
        wrongA = root.Q<VisualElement>("wrongA");
        correctB = root.Q<VisualElement>("correctB");
        wrongC = root.Q<VisualElement>("wrongC");
        wrongD = root.Q<VisualElement>("wrongD");
        next = root.Q<Button>("next");
        B.clicked += () => OnCorrectClick();
        A.clicked += () => OnWrongAClick();
        C.clicked += () => OnWrongCClick();
        D.clicked += () => OnWrongDClick();

    }
    public void OnCorrectClick()
    {
        correct.gameObject.SetActive(true);
        correctB.BringToFront();
        next.BringToFront();
    }
    public void OnWrongAClick()
    {
        wrong.gameObject.SetActive(true);
        wrongA.BringToFront();
    }
    public void OnWrongCClick()
    {
        wrong.gameObject.SetActive(true);
        wrongC.BringToFront();
    }
    public void OnWrongDClick()
    {
        wrong.gameObject.SetActive(true);
        wrongD.BringToFront();
    }
}
