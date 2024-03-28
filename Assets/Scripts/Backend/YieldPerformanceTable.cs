using System.Collections.Generic;

/*
 * Original Author: Bill Guo
 */
namespace Backend
{
    /// <summary>
    /// A lookup table that dictates a plot's wheat yield depending on fertilizer/seed type and weather.
    /// </summary>
    public static class YieldPerformanceTable
    {
        private static Dictionary<(int, int, int), int> _table = new Dictionary<(int, int, int), int>
            {
                {(5, 0, 0), 17}, {(4, 0, 0), 18}, {(3, 0, 0), 19}, {(2, 0, 0), 20}, {(1, 0, 0), 25}, 
                {(5, 1, 0), 18}, {(4, 1, 0), 19}, {(3, 1, 0), 20}, {(2, 1, 0), 22}, {(1, 1, 0), 30},
                {(5, 2, 0), 21}, {(4, 2, 0), 24}, {(3, 2, 0), 27}, {(2, 2, 0), 30}, {(1, 2, 0), 45},
                {(5, 0, 1), 5},  {(4, 0, 1), 7},  {(3, 0, 1), 9},  {(2, 0, 1), 12}, {(1, 0, 1), 27},
                {(5, 1, 1), 9},  {(4, 1, 1), 10}, {(3, 1, 1), 13}, {(2, 1, 1), 20}, {(1, 1, 1), 40},
                {(5, 2, 1), 15}, {(4, 2, 1), 20}, {(3, 2, 1), 28}, {(2, 2, 1), 40}, {(1, 2, 1), 80},
                  
            };

        /// <summary>
        /// Find expected wheat yield for <paramref name="plot"/>.
        /// </summary>
        /// <param name="plot">The farm plot whose wheat to calculate.</param>
        /// <returns>The expected wheat yield (before applying multiplier).</returns>
        public static int GetYield(FarmPlot plot)
        {   
            (int, int, int) key = (plot.GetWeatherEffect(), (int)plot.FertilizerType, (int)plot.SeedType);

            if (_table.TryGetValue(key, out int expectedYield)) {
                return expectedYield;
            }
            
            return 0; // returns 0 if for some reason the input values were invalid
        }
    }
}
