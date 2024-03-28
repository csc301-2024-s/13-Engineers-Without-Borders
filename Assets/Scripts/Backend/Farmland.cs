using System.Collections.Generic;

/*
 * Original Author: Bill Guo
 */
namespace Backend
{
    /// <summary>
    /// A player's farmland.
    /// </summary>
    public class Farmland : HouseholdAsset
    {
        /// <summary>
        /// The maximum number of plots a player can have.
        /// </summary>
        public const int MaxPlots = 16;

        /// <summary>
        /// The list of farm plots.
        /// </summary>
        public List<FarmPlot> Plots;

        /// <summary>
        /// Initializes a farmland with <paramref name="numPlots"/> plots.
        /// </summary>
        /// <param name="numPlots">Number of farm plots.</param>
        public Farmland(int numPlots)
        {
            Plots = new List<FarmPlot>();

            for (var i = 0; i < numPlots; i++)
            {
                Plots.Add(new FarmPlot(0, FertilizerType.None));
            }
        }

        /// <summary>
        /// Set the owner of this land and its plots.
        /// </summary>
        /// <param name="owner">The owner.</param>
        public override void SetOwner(Household owner)
        {
            base.SetOwner(owner);
            foreach (FarmPlot plot in Plots)
            {
                plot.SetOwner(owner);
            }
        }

        /// <summary>
        /// Gets the total wheat yield of this land.
        /// </summary>
        /// <returns>Total wheat yield.</returns>
        public int GetTotalYield()
        {
            int totalYield = 0;

            foreach (FarmPlot plot in Plots)
            {
                totalYield += plot.GetYield();
            }

            return totalYield;

        }

        /// <summary>
        /// Adds a farm plot to this land.
        /// </summary>
        public void AddPlot()
        {
            if (Plots.Count >= MaxPlots)
            {
                return;
            }

            FarmPlot newPlot = new(0, FertilizerType.None);
            newPlot.SetOwner(Owner);
            Plots.Add(newPlot);
        }

        /// <summary>
        /// Reset irrigation status for every plot.
        /// </summary>
        public void ResetIrrigation()
        {
            foreach (FarmPlot plot in Plots)
            {
                if (plot.Irrigated)
                {
                    plot.Irrigated = false;
                }
            }
        }

        /// <summary>
        /// Clear seed and fertilizer type for all plots.
        /// </summary>
        public void ClearPlots()
        {
            foreach (FarmPlot plot in Plots)
            {
                plot.ClearPlot();
            }
        }

        /// <summary>
        /// Set yield multiplier of all plots.
        /// </summary>
        /// <param name="val">The multiplier.</param>
        public void SetYieldMultiplier(float val)
        {
            foreach (FarmPlot plot in Plots)
            {
                plot.YieldMultiplier = val;
            }
        }

    }
}
