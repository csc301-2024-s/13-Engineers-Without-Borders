using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowYieldTable : MonoBehaviour
{
    public Image yieldTable;
    public Button showYieldTableButton;
    public Button closeYieldTableButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = showYieldTableButton.GetComponent<Button>();
        btn.onClick.AddListener(ShowTable) ;
    }

    // Update is called once per frame
    void ShowTable()
    {
        Button btn = showYieldTableButton.GetComponent<Button>();
        btn.gameObject.SetActive(false);
        yieldTable.enabled = true;

    }
}
