using UnityEngine;
using UnityEngine.UI;

public class CloseYieldTable : MonoBehaviour
{
    public Image yieldTable;
    public Button closeYieldTableButton;
    public Button showYieldTableButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = closeYieldTableButton.GetComponent<Button>();
        btn.onClick.AddListener(CloseTable);
    }

    // Update is called once per frame
    void CloseTable()
    {
        Button btn = showYieldTableButton.GetComponent<Button>();
        // on button click, show the Show Yield Table button
        btn.gameObject.SetActive(true);
        // hide the yield table image
        yieldTable.enabled = false;

    }
}
