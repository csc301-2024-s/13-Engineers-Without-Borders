using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static Backend.GameState;

public class Result : MonoBehaviour
{
    Dictionary<string, int> results;
    UIDocument document;
    Label congratulations;
    Label endOfYear;
    Label startingSavings;
    Label startingAcresOfLand;
    Label tubewell;
    Label ox;
    Label acresOfLand;
    Label totalSavings;
    Label totalAssets;
    Label startingAssets;
    Label totalEarnings;
    Label score;


    void OnEnable()
    {
        results = ResultReport();
        
        document = GetComponent<UIDocument>();
        VisualElement root = document.rootVisualElement;

        congratulations = root.Q<Label>("congratulations");
        endOfYear = root.Q<Label>("end-of-year");
        startingSavings = root.Q<Label>("starting-savings");
        startingAcresOfLand = root.Q<Label>("starting-acres-of-land");
        tubewell = root.Q<Label>("tubewell");
        ox = root.Q<Label>("ox");
        acresOfLand = root.Q<Label>("acres-of-land");
        totalSavings = root.Q<Label>("total-savings");
        totalAssets = root.Q<Label>("total-assets");
        startingAssets = root.Q<Label>("starting-assets");
        totalEarnings = root.Q<Label>("total-earnings");
        score = root.Q<Label>("score");

        congratulations.text = congratulations.text.Replace("?", results["end-of-year"].ToString());
        endOfYear.text = endOfYear.text.Replace("?", results["end-of-year"].ToString());
        startingSavings.text = startingSavings.text.Replace("?", results["starting-savings"].ToString());
        startingAcresOfLand.text = startingAcresOfLand.text.Replace("?", results["starting-acres-of-land"].ToString());
        tubewell.text = tubewell.text.Replace("?", results["tubewell"].ToString());
        ox.text = ox.text.Replace("?", results["ox"].ToString());
        acresOfLand.text = acresOfLand.text.Replace("?", results["acres-of-land"].ToString());
        totalSavings.text = totalSavings.text.Replace("?", results["total-savings"].ToString());
        totalAssets.text = totalAssets.text.Replace("?", results["total-assets"].ToString());
        totalSavings.text = totalSavings.text.Replace("?", results["total-savings"].ToString());
        startingAssets.text = startingAssets.text.Replace("?", results["starting-assets"].ToString());
        totalEarnings.text = totalEarnings.text.Replace("?", results["total-earnings"].ToString());
        score.text = score.text.Replace("?", results["total-earnings"].ToString());
        score.text = score.text.Replace("#", results["adults-number"].ToString());
        score.text = score.text.Replace("*", results["children-number"].ToString());
    }
}
