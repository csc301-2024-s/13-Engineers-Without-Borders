using Backend;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectAllWheat : MonoBehaviour
{
    public Button collectAllButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = collectAllButton.GetComponent<Button>();
        btn.onClick.AddListener(CollectAll);
    }

    // On button press, collect all wheat from farmland
    void CollectAll()
    {
        GameState.s_Player.HarvestCrops();
        Debug.Log("Crops harvested");
    }
}
