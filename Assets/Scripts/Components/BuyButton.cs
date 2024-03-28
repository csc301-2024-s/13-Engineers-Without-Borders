using Backend;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
/// <summary>
/// Makes a button buy a product from the market on click. Product name is a serialized field.
/// Place on an object with a Button component.
/// </summary>
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

    /// <summary>
    /// Click handler.
    /// </summary>
    public void OnClick() {
        Market.Buy(productName, GameState.s_Player);
        // we probably don't need error message handling because the buy button can only be clicked if you can buy it
    }
}
