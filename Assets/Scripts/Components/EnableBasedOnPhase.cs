using System.Collections.Generic;
using UnityEngine;
using Backend;

// Original Author: Bill Guo
/// <summary>
/// Place this on any object and set its fields to make it be active only during the specified phases.
/// </summary>
public class EnableBasedOnPhase : MonoBehaviour
{
    [SerializeField] List<int> phases;

    void Start()
    {       
        bool inPhase = phases.Contains(GameState.s_Phase);
        gameObject.SetActive(inPhase);
    }
}
