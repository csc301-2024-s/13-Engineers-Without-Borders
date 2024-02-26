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
        SeedType seedType = SeedType.HYC; 
        FertilizerType fertilizerType = FertilizerType.High;
        FarmPlot plot = new FarmPlot(seedType, fertilizerType);
        
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

        FarmPlot plot1 = new FarmPlot(SeedType.HYC, FertilizerType.None); 
        FarmPlot plot2 = new FarmPlot(SeedType.HYC, FertilizerType.Low); 
        FarmPlot plot3 = new FarmPlot(SeedType.HYC, FertilizerType.High); 

        GameState.s_WeatherIndex = 1;

        farmland.Plots.Add(plot1);
        farmland.Plots.Add(plot2);
        farmland.Plots.Add(plot3);

        int expectedTotalYield = 147; // 27 + 40 + 80
        int actualTotalYield = farmland.GetTotalYield();

        Assert.AreEqual(expectedTotalYield, actualTotalYield);
    }

}
