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

        // Initializes empty list to store FarmPlot objects 
        public Farmland()
        {
            Plots = new List<FarmPlot>();
        }

        // Gets the combined yield of every plot currently on this farmland
        public int GetTotalYield() {
            int totalYield = 0;

            foreach (FarmPlot plot in Plots) {
                totalYield += plot.GetYield();
            }
            return totalYield;

        }
    }
}
