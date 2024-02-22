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
    public Image wheatField;
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
        Image field = wheatField.GetComponent<Image>();

        // remove the button so that the player can only click once
        collectButton.onClick.RemoveListener(CollectAll);
        collectButton.gameObject.SetActive(false);

        // chaneg color of wheat field so it looks like its been harvested
        field.color = new Color(105f/255, 78f/255, 52f/255);

        // show the next button so the player can advance to the next phase
        nextButton.gameObject.SetActive(true);

        GameState.s_Player.HarvestCrops();
        Debug.Log("Crops harvested");

    }
}
