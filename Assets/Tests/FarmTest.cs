using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using Backend;
using NUnit.Framework;

// Author: Bill Guo
public class FarmTest 
{   
    // Tests the GetYield function in the FarmPlot Class
    [Test]
    public void TestGetYield()
    {
        int seedType = 1; 
        FertilizerType fertilizerType = FertilizerType.HIGH_FERTILIZER;
        Adult worker = new Adult("Test", "Name");
        FarmPlot plot = new FarmPlot(seedType, fertilizerType, worker);
        
        GameState.s_WeatherIndex = 3;

        int expectedYield = 28; 
        int actualYield = plot.GetYield();

        Assert.AreEqual(expectedYield, actualYield);
    }

    // Tests the GetTotalYield function in the Farmland class
    [Test]
    public void TestGetTotalYield()
    {
        Farmland farmland = new Farmland(0);

        Adult worker = new Adult("Test", "Name");
        FarmPlot plot1 = new FarmPlot(1, FertilizerType.NO_FERTILIZER, worker); 
        FarmPlot plot2 = new FarmPlot(1, FertilizerType.LOW_FERTILIZER, worker); 
        FarmPlot plot3 = new FarmPlot(1, FertilizerType.HIGH_FERTILIZER, worker); 

        GameState.s_WeatherIndex = 1;

        farmland.Plots.Add(plot1);
        farmland.Plots.Add(plot2);
        farmland.Plots.Add(plot3);

        int expectedTotalYield = 147; // 27 + 40 + 80
        int actualTotalYield = farmland.GetTotalYield();

        Assert.AreEqual(expectedTotalYield, actualTotalYield);
    }

}
