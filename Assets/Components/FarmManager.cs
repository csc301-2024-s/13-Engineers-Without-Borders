using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Backend;

// Original Author: Andy Wang
// Similar to GameState but specific to the Manage Farm scene, holding some variables used in that scene for convenience
public class FarmManager : MonoBehaviour
{
    // TODO:
    // - Need a field to keep track of selected farm cells
    // - When farm cell is pressed while selected, it should be unselected
    // - In phase 2 when you press harvest button, only selected farm cells should be harvested
    // - In phase 3, need to keep track of which tool is selected (HYC seeed or fertilizer?) which can be read statically

    public static string SelectedTool { get; set; } = null; // just make this a string for now lol
}
