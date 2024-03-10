using Backend;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
// Button to give an adult an ox, disabled if you have no ox/adult already has an ox
public class GiveOxButton : MonoBehaviour
{
    public Adult Adult { get; set; }
    private Button _btn;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _text = _btn.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        // if adult has an ox when you click, remove it
        // o/w give ox
        _btn.onClick.AddListener(() =>
        {
            if (Adult.HasOx)
            {
                Adult.AssignOx(false);
                GameState.s_Player.Inventory.AddItem("Ox");
            }
            else
            {
                Adult.AssignOx(true);
                GameState.s_Player.Inventory.RemoveItem("Ox");
            }
        });
    }

    void Update()
    {
        if (Adult == null)
        {
            gameObject.SetActive(false);
            return;
        }

        if (Adult.HasOx)  // if has ox, you can take ox
        {
            _btn.interactable = true;
            _text.text = "Take ox";
            return;
        }
        else if (GameState.s_Player.Inventory.GetAmount("Ox") > 0)  // no ox but you have ox in inventory
        {
            _btn.interactable = true;
            _text.text = "Assign ox";
            return;
        }

        // no ox but you don't have ox in inventory
        _btn.interactable = false;
        _text.text = "No ox available!";
    }
}
