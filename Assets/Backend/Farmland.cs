using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Bill Guo
 */
namespace Backend
{
    public class Farmland
    {
        public List<FarmPlot> Plots;
        public bool canBeHarvested { get; set; }

        // Initializes empty list to store FarmPlot objects 
        public Farmland(int numPlots)
        {
            Plots = new List<FarmPlot>();
            canBeHarvested = false;

            for (var i = 0; i < numPlots; i++)
            {
                Plots.Add(new FarmPlot(0, FertilizerType.NO_FERTILIZER));
            }
        }

        // Gets the combined yield of every plot currently on this farmland
        public int GetTotalYield() {
            int totalYield = 0;

            foreach (FarmPlot plot in Plots) {
                totalYield += plot.GetYield();
            }

            return totalYield;

        }   

        // Add a plot to this land
        public void AddPlot() {
            Plots.Add(new FarmPlot(0, FertilizerType.NO_FERTILIZER));
        }
    }
}
