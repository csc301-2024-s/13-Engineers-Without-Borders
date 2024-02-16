using System.Collections;
using System.Collections.Generic;
using Backend;
using UnityEngine;
using UnityEngine.UI;

// Author: Andy Wang
// Put this component on a button to make it buy something from the market on click
public class BuyButton : MonoBehaviour
{
    [SerializeField] string _productName;
    private Button _btn;

    void Start() {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClick);
    }

    // Grey out button if you can't buy it (other than money)
    void Update() {
        //_btn.interactable
    }

    public void OnClick() {
        string result = Market.Buy(_productName, GameState.s_Player);  // TODO: error message handling
    }
}
