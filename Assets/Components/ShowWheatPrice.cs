using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Backend;
public class ShowWheatPrice : MonoBehaviour
{
    public TextMeshProUGUI wheatPriceText;
    [SerializeField] string text;
    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wheatPriceText.text = "Wheat Price: " + Market.GetPrice("Wheat");
    }
}
