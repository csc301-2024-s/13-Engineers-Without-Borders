using UnityEngine;
using Backend;

/*
 * Original Author: Hoa Nguyen
 * This scence is used to display the information of the selected household
 */

public class DisplayInformation : MonoBehaviour
{
    public TMPro.TextMeshProUGUI informationText;
    // Start is called before the first frame update
    void Start()
    {
        string selectedHousehold = PlayerPrefs.GetString("SelectedHousehold", "DefaultHousehold");

        DisplayHouseholdInformation(selectedHousehold);
    }

    // Display the household information
    void DisplayHouseholdInformation(string householdData)
    {
        informationText.text = $"Weather Index: {GameState.s_WeatherIndex}\n{householdData}\nWheat Price: {Market.GetPrice("Wheat")}\n";
    }
}
