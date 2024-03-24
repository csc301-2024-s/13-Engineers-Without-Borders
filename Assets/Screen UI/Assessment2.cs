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

    VisualElement wrongA;
    VisualElement wrongB;
    VisualElement wrongC;
    VisualElement wrongD;
    VisualElement correctE;
    VisualElement wrongF;
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
        correctE = root.Q<VisualElement>("correctE");
        wrongF = root.Q<VisualElement>("wrongF");
        next = root.Q<Button>("next");
        E.clicked += () => OnCorrectClick();
        A.clicked += () => OnWrongAClick();
        B.clicked += () => OnWrongBClick();
        C.clicked += () => OnWrongCClick();
        D.clicked += () => OnWrongDClick();
        F.clicked += () => OnWrongFClick();

    }
    public void OnCorrectClick()
    {
        correct.gameObject.SetActive(true);
        correctE.BringToFront();
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
    public void OnWrongFClick()
    {
        wrong.gameObject.SetActive(true);
        wrongF.BringToFront();
    }
}
