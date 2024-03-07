using Backend;
using TMPro;
using UnityEngine;

// Original Author: Andy Wang
// Populate the household selection screen with premade Households
public class HouseholdSelectionPopulator : MonoBehaviour
{
    [SerializeField] GameObject householdOptionPrefab;
    [SerializeField] GameObject gridContent;  // grid container for the buttons

    // Start is called before the first frame update
    void Start()
    {
        gridContent.transform.SetParent(gridContent.transform.parent, false); // do this so scaling works

        foreach (Household household in GameState.s_PredefinedHouseholds)
        {
            GameObject btnClone = Instantiate(householdOptionPrefab);
            SetUpHouseholdOptionManager(btnClone, household);
            btnClone.transform.SetParent(gridContent.transform, false);
        }
    }

    void SetUpHouseholdOptionManager(GameObject btn, Household household)
    {
        HouseholdOption option = btn.GetComponent<HouseholdOption>();
        option.Household = household;

        TextMeshProUGUI name = btn.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI description = btn.transform.Find("Description").GetComponent<TextMeshProUGUI>();

        name.text = $"The {household.Family.Name} Household";
        description.text = $"{household.Family.GetAdultAmount()} adults<br>" +
            $"{household.Family.GetChildrenAmount()} children<br>{household.Land.Plots.Count} plots of land";
    }
}
