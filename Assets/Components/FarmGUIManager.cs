using System.Collections.Generic;
using UnityEngine;

public class FarmGUIManager : MonoBehaviour
{
    [SerializeField] private List<int> activePhases;

    void Start()
    {
        UpdateVisibility();
    }

    public void UpdateVisibility()
    {
        bool isActive = activePhases.Contains(Backend.GameState.s_Phase);
        this.gameObject.SetActive(isActive);
    }
}
