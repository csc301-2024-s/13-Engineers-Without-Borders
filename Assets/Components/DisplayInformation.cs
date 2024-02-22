using UnityEngine;
/*
 * Author: Hoa Nguyen
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
        informationText.text = "Weather Index: 3\n" + householdData +  "\nWheat Price: 5\n";
    }
}
