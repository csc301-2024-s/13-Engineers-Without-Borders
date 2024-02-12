using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Author: Andy Wang
// Put this component on a button to make it buy something from the market on click
public class BuyButton : MonoBehaviour
{
    [SerializeField] string _itemName;

    void Start() {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    public void OnClick() {
        Debug.Log($"Invoke the market to buy {_itemName}");
    }
}
