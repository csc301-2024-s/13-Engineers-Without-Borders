using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInformation : MonoBehaviour
{
    public TMPro.TextMeshProUGUI informationText;
    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the selected household data from PlayerPrefs
        string selectedHousehold = PlayerPrefs.GetString("SelectedHousehold", "DefaultHousehold");

        // Use the data to display information in your GUI
        DisplayHouseholdInformation(selectedHousehold);
    }

    // Display the household information
    void DisplayHouseholdInformation(string householdData)
    {
        informationText.text = "Weather Index: 3\n" + householdData +  "\nWheat Price: 5\n";
    }
}
