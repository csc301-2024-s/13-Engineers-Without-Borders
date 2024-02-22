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
        // hide the show yield table button so the close yield table button appears
        btn.gameObject.SetActive(false);
        // show the yield table image
        yieldTable.enabled = true;

    }
}
