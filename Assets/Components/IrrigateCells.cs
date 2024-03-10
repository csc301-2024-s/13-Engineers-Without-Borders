using UnityEngine;
using UnityEngine.UI;

public class IrrigateCells : MonoBehaviour
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
        FarmManager.IrrigateSelectedCells();
    }
}
