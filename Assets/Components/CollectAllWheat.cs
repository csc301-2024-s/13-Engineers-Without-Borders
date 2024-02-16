using Backend;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class CollectAllWheat : MonoBehaviour
{
    public Button collectAllButton;
    public Button nextPhaseButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = collectAllButton.GetComponent<Button>();
        btn.onClick.AddListener(CollectAll);
    }

    // On button press, collect all wheat from farmland
    void CollectAll()
    {
        Button collectButton = collectAllButton.GetComponent<Button>();
        Button nextButton = nextPhaseButton.GetComponent<Button>();

        collectButton.onClick.RemoveListener(CollectAll);
        collectButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);

        GameState.s_Player.HarvestCrops();
        Debug.Log("Crops harvested");

    }
}
