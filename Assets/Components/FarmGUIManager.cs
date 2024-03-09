using System.Collections.Generic;
using UnityEngine;
using Backend;

// Author: Bill Guo     
public class FarmGUIManager : MonoBehaviour
{
    public static FarmGUIManager Instance { get; private set; }

    private List<FarmGUI> farmGUIs = new List<FarmGUI>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Adds a FarmGUI game object to the list
    public void RegisterFarmGUI(FarmGUI farmGUI)
    {
        if (!farmGUIs.Contains(farmGUI))
        {
            farmGUIs.Add(farmGUI);
        }
    }

    // Updates the visibility of every FarmGUI object
    public void UpdateAllGUIManagersVisibility()
    {
        foreach (FarmGUI farmGUI in farmGUIs)
        {
            farmGUI.UpdateVisibility();
        }
    }

    public bool IsRegistered(FarmGUI farmGUI)
    {
        return farmGUIs.Contains(farmGUI);
    }
}
