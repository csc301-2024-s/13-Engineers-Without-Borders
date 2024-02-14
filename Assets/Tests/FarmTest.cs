using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Bill Guo
public class FarmTest 
{   
    // Tests the GetYield function in the FarmPlot Class
    [Test]
    public void TestGetYield()
    {
        int seedType = 1; 
        FertilizerType fertilizerType = FertilizerType.HIGH_FERTILIZER;
        Adult worker = new Adult();
        FarmPlot plot = new FarmPlot(seedType, fertilizerType, worker);
        
        GameState.s_WeatherIndex = 3;


        int expectedYield = 45; 
        int actualYield = plot.GetYield();

        Assert.AreEqual(expectedYield, actualYield);
    }

    // Tests the GetTotalYield function in the Farmland class
    [Test]
    public void TestGetTotalYield
    {
        Farmland farmland = new Farmland();

        FarmPlot plot1 = new FarmPlot(1, FertilizerType.NO_FERTILIZER); 
        FarmPlot plot2 = new FarmPlot(1, FertilizerType.LOW_FERTILIZER); 
        FarmPlot plot3 = new FarmPlot(1, FertilizerType.HIGH_FERTILIZER); 

        farmland.Plots.Add(plot1);
        farmland.Plots.Add(plot2);
        farmland.Plots.Add(plot3);

        int expectedTotalYield = 60; //10 + 20 + 30
        int actualTotalYield = farmland.GetTotalYield();

        Assert.AreEqual(expectedTotalYield, actualTotalYield);
    }

}
