using Backend;
using UnityEngine;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    [SerializeField] int num;
    [SerializeField] string productName;
    private Button _btn;

    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClick);
    }

    // Grey out button if you have no wheat
    void Update()
    {
        if (productName == "Wheat")
            _btn.interactable = GameState.s_Player.Wheat > 0;
        else if (productName == "Labour")
            _btn.interactable = GameState.s_Player.Family.GetHiredWorkerAmount() > 0;
        else
            _btn.interactable = GameState.s_Player.Inventory.GetAmount(productName) > 0;
    }

    public void OnClick()
    {
        Market.Sell(GameState.s_Player, num, productName);
    }
}
