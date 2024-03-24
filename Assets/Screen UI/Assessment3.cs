using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Assessment3 : MonoBehaviour
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

    VisualElement wrongA;
    VisualElement wrongB;
    VisualElement wrongC;
    VisualElement wrongD;
    VisualElement wrongE;
    VisualElement correctF;
    Button next;
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
        wrongA = root.Q<VisualElement>("wrongA");
        wrongB = root.Q<VisualElement>("wrongB");
        wrongC = root.Q<VisualElement>("wrongC");
        wrongD = root.Q<VisualElement>("wrongD");
        wrongE = root.Q<VisualElement>("wrongE");
        correctF = root.Q<VisualElement>("correctF");
        next = root.Q<Button>("next");
        F.clicked += () => OnCorrectClick();
        A.clicked += () => OnWrongAClick();
        B.clicked += () => OnWrongBClick();
        C.clicked += () => OnWrongCClick();
        D.clicked += () => OnWrongDClick();
        E.clicked += () => OnWrongEClick();

    }
    public void OnCorrectClick()
    {
        correct.gameObject.SetActive(true);
        correctF.BringToFront();
        next.BringToFront();
    }
    public void OnWrongAClick()
    {
        wrong.gameObject.SetActive(true);
        wrongA.BringToFront();
    }
    public void OnWrongBClick()
    {
        wrong.gameObject.SetActive(true);
        wrongB.BringToFront();
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
    public void OnWrongEClick()
    {
        wrong.gameObject.SetActive(true);
        wrongE.BringToFront();
    }
}
