using System.Collections.Generic;

/*
 * Original Author: Bill Guo
 */
namespace Backend
{
    public class Farmland : HouseholdAsset
    {
        public const int MaxPlots = 25;

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

        // Set owner of this farm land and all plots
        public override void SetOwner(Household owner)
        {
            base.SetOwner(owner);
            foreach (FarmPlot plot in Plots)
            {
                plot.SetOwner(owner);
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
            if (Plots.Count >= MaxPlots)
            {
                return;
            }

            FarmPlot newPlot = new(0, FertilizerType.None);
            newPlot.SetOwner(Owner);
            Plots.Add(newPlot);
        }

        // Resets irrigation status for every plot
        public void ResetIrrigation() {
            foreach (FarmPlot plot in Plots) {
                if (plot.Irrigated) {
                    plot.Irrigated = false;
                }
            }
        }

    }
}
