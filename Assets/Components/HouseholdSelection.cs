using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Backend;
using TMPro;
using UnityEngine.SceneManagement;
/*
 * Author: Hoa Nguyen
 * Handle the logic of Household selection
 */

public class LogicScript : MonoBehaviour
{

    public static Household[] s_PredefinedHouseholds = new Household[]
        {
            new Household(500, "Madhar", 3, 2, 3),
            new Household(500, "Barlch", 4, 2, 3),
            new Household(500, "Rama", 4, 3, 4),
            new Household(500, "Dulai", 4, 5, 4),
            new Household(500, "Grewal", 4, 6, 5),
            new Household(500, "Kahlon", 3, 2, 4),
            new Household(500, "Aujla", 4, 2, 2),
            new Household(500, "Sandha", 4, 3, 6),
            new Household(500, "Kohli", 0, 2, 1),
            new Household(500, "Gill", 2, 4, 7),
            new Household(500, "Dhillon", 1, 2, 2),
            new Household(500, "Singh", 2, 3, 3),
            new Household(500, "Kapoor", 3, 5, 5),
            new Household(500, "Bhatia", 2, 2, 2),
            new Household(500, "Gupta", 3, 5, 7)
        };
    [SerializeField]
    public TextMeshProUGUI HouseholdInfo;
    int index = 0;
    public void OnNextButtonClick()
    {
        index = (index + 1) % s_PredefinedHouseholds.Length;
        Household CurrentHousehold = s_PredefinedHouseholds[index];
        HouseholdInfo.text = CurrentHousehold.Family.Name + " Family\n" + CurrentHousehold.Family.GetAdultAmount() + " adults\n" +
            CurrentHousehold.Family.GetChildrenAmount() + " children\n" + CurrentHousehold.Land.Plots.Count + " arces of land";
        
    }

    public void OnBackButtonClick()
    {
        index = (index - 1 + s_PredefinedHouseholds.Length) % s_PredefinedHouseholds.Length;
        Household CurrentHousehold = s_PredefinedHouseholds[index];
        HouseholdInfo.text = CurrentHousehold.Family.Name + " Family\n" + CurrentHousehold.Family.GetAdultAmount() + " adults\n" +
            CurrentHousehold.Family.GetChildrenAmount() + " children\n" + CurrentHousehold.Land.Plots.Count + " arces of land";
    }

    public void OnStartButtonClick()
    {
        Household CurrentHousehold = s_PredefinedHouseholds[index];
        GameState.Initialize(CurrentHousehold);
        string selectedHousehold = HouseholdInfo.text;
        PlayerPrefs.SetString("SelectedHousehold", "Number of Adults: " + CurrentHousehold.Family.GetAdultAmount() + 
            "\nNumber of Children: " + CurrentHousehold.Family.GetChildrenAmount() + "\nLand: " + CurrentHousehold.Land.Plots.Count);
        SceneManager.LoadScene("DisplayInformation");
    }
}
