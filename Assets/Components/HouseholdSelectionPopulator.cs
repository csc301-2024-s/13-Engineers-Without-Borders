using Backend;
using TMPro;
using UnityEngine;

// Original Authors: Andy Wang & TODO: FILL IN YOUR NAME HERE
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
        // TODO: Use GetComponent on the btn to retrieve the attached HouseholdOption script, and set its Household property accordingly

        TextMeshProUGUI name = btn.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI description = btn.transform.Find("Description").GetComponent<TextMeshProUGUI>();

        // TODO: Set <name.text> to the household's name and <name.description> to "X adults<br>Y children<br>Z plots of land"
    }
}
