using Backend;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
// Populate the adult/child view in household manager
public class FamilyMemberPopulator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject adultListContent;
    [SerializeField] GameObject childListContent;


    // Start is called before the first frame update
    void Start()
    {
        adultListContent.transform.SetParent(adultListContent.transform.parent, false); // do this so scaling works
        childListContent.transform.SetParent(childListContent.transform.parent, false); // do this so scaling works

        // set up adult list
        RectTransform adultListRect = adultListContent.GetComponent<RectTransform>();
        Vector2 adultListRectSize = adultListRect.sizeDelta;
        foreach (Adult adult in GameState.s_Player.Family.Adults)
        {
            GameObject btnClone = Instantiate(prefab);
            SetUpList(btnClone, adult);
            btnClone.transform.SetParent(adultListContent.transform, false);
            adultListRectSize.y += 400;
        }

        foreach (Adult adult in GameState.s_Player.Family.HiredWorkers)
        {
            GameObject btnClone = Instantiate(prefab);
            SetUpList(btnClone, adult);
            btnClone.transform.SetParent(adultListContent.transform, false);
            adultListRectSize.y += 400;
        }
        
        adultListRect.sizeDelta = adultListRectSize;

        // set up child list
        RectTransform childListRect = childListContent.GetComponent<RectTransform>();
        Vector2 childListRectSize = childListRect.sizeDelta;
        foreach (Child child in GameState.s_Player.Family.Children)
        {
            GameObject btnClone = Instantiate(prefab);
            SetUpList(btnClone, child);
            btnClone.transform.SetParent(childListContent.transform, false);
            childListRectSize.y += 400;
        }
        childListRect.sizeDelta = childListRectSize;
    }

    void SetUpList(GameObject obj, FamilyMember fam)
    {
        TextMeshProUGUI name = obj.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI age = obj.transform.Find("Age").GetComponent<TextMeshProUGUI>();
        GiveOxButton giveOx = obj.transform.Find("GiveOx").GetComponent<GiveOxButton>();

        name.text = $"{fam.FirstName} {fam.LastName}";

        if (fam is Adult)
        {
            giveOx.Adult = (Adult)fam;
            age.gameObject.SetActive(false);
        }
        else  // child
        {
            giveOx.gameObject.SetActive(false);
            age.text = $"Turns adult in: {13 - ((Child)fam).Age} years";
        }
    }
}
