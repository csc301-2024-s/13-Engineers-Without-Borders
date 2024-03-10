using System.Collections.Generic;
using UnityEngine;
using Backend;

// Original Author: Bill Guo
public class EnableBasedOnPhase : MonoBehaviour
{
    [SerializeField] List<int> phases;

    void Start()
    {   
        bool inPhase = phases.Contains(GameState.s_Phase);
        gameObject.SetActive(inPhase);
    }
}
