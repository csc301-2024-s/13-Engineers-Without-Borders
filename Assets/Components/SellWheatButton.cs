using System.Collections;
using System.Collections.Generic;
using Backend;
using UnityEngine;
using UnityEngine.UI;

public class SellWheatButton : MonoBehaviour
{
    [SerializeField] int numWheat;
    private Button _btn;

    void Start() {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(OnClick);
    }

    // Grey out button if you have no wheat
    void Update() {
        _btn.interactable = GameState.s_Player.Wheat > 0;
    }

    public void OnClick() {
        Market.SellWheat(GameState.s_Player, numWheat);
    }
}
