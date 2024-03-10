using UnityEngine;
using UnityEngine.UI;

public class HarvestWheat : MonoBehaviour
{
    void Start() 
    {
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(OnClick);
        }
    }

    public void OnClick() 
    {
        FarmManager.HarvestSelectedCells();
    }
}
