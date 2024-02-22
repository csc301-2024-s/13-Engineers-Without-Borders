using UnityEngine;
using TMPro;
using Backend;
public class ShowWheatPrice : MonoBehaviour
{
    public TextMeshProUGUI wheatPriceText;
    [SerializeField] string text;

    // Update is called once per frame
    void Update()
    {
        wheatPriceText.text = "Wheat Price: " + Market.GetPrice("Wheat");
    }
}
