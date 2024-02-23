using System.Collections.Generic;

/*
 * Author: Bill Guo
 */
namespace Backend
{
    public class Farmland
    {
        public List<FarmPlot> Plots;
        public bool CanBeHarvested { get; set; }

        // Initializes empty list to store FarmPlot objects 
        public Farmland(int numPlots)
        {
            Plots = new List<FarmPlot>();
            CanBeHarvested = false;

            for (var i = 0; i < numPlots; i++)
            {
                Plots.Add(new FarmPlot(0, FertilizerType.None));
            }
        }

        // Gets the combined yield of every plot currently on this farmland
        public int GetTotalYield() {
            int totalYield = 0;

            foreach (FarmPlot plot in Plots) {
                totalYield += plot.GetYield();

                // once collected, reset seed type and fertilizer
                plot.SeedType = 0;
                plot.FertilizerType = FertilizerType.None;
            }

            return totalYield;

        }   

        // Add a plot to this land
        public void AddPlot() {
            Plots.Add(new FarmPlot(0, FertilizerType.None));
        }
    }
}
