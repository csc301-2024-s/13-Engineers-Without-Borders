using Backend;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
// Enable/disable a toggle based on if you have some of an inventory item
public class ToggleIfHasProduct : MonoBehaviour
{
    [SerializeField] string productName;
    private Toggle _toggle;

    // Start is called before the first frame update
    void Start()
    {
        _toggle = GetComponent<Toggle>();
    }

    // Disable only if not on + no product
    void Update()
    {
        if (_toggle.isOn) return;
        _toggle.interactable = GameState.s_Player.Inventory.GetAmount(productName) > 0;
    }
}
