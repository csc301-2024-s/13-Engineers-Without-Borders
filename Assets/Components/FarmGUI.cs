using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backend;

// Author: Bill Guo
public class FarmGUI : MonoBehaviour
{
    [SerializeField] private List<int> activePhases;

    void Start()
    {   
        FarmGUIManager.Instance?.RegisterFarmGUI(this);
        UpdateVisibility();
    }

    void OnEnable()
    {
        UpdateVisibility();
    
    }

    public void UpdateVisibility() {
        // Double checks if this GUI element is registered, needed for phase 2 and 3 elements because they start off inactive 
        if (!FarmGUIManager.Instance.IsRegistered(this))
        {
            FarmGUIManager.Instance.RegisterFarmGUI(this);
        }

        bool isActive = activePhases.Contains(GameState.s_Phase);
        this.gameObject.SetActive(isActive);
    }
}
