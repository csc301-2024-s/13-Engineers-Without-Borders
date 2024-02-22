using Backend;
using UnityEngine;
using UnityEngine.UI;

// Author: Andy Wang
// Put this component on a button to make it buy something from the market on click
public class BuyButton : MonoBehaviour
{
    [SerializeField] string productName;
    private Button _btn;

    void Start() {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClick);
    }

    // Grey out button if you can't buy it (other than money)
    void Update() {
        _btn.interactable = Market.CanBuyerBuy(GameState.s_Player, productName);
    }

    public void OnClick() {
        Market.Buy(productName, GameState.s_Player);
        // we probably don't need error message handling because the buy button can only be clicked if you can buy it
    }
}
