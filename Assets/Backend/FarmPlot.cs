namespace Backend
{
    // Author: Jacqueline Zhu
    public class FarmPlot
    {
        // 1 for HYC, 0 for normal
        public int SeedType { get; set; }

        // Type of fertilizer
        public FertilizerType FertilizerType { get; set; }

        // Adult assigned to this plot
        public Adult Worker { get; private set; }


        public FarmPlot(int seedType, FertilizerType fertilizerType, Adult worker = null)
        {
            SeedType = seedType;
            FertilizerType = fertilizerType;
            Worker = worker;
        }

         // Returns either game's weather index or, if irrigated (implemented later), best weather
        public int GetWeatherEffect()
        {
            return GameState.s_WeatherIndex;
        }

        public void AssignWorker(Adult worker)
        {
            worker.AssignedPlots.Add(this);
            Worker = worker;
        }

        /// <summary>
        /// Remove the worker assigned to this farm plot.
        /// </summary>
        public void RemoveWorker()
        {
            Worker.AssignedPlots.Remove(this);
            Worker = null;
        }

        /// <summary>
        /// Returns the yield of this plot. Returns 0 if there is no worker assigned to this plot.
        /// </summary>
        /// <returns></returns>
        public int GetYield()
        {
            if (Worker != null)
            {
                return YieldPerformanceTable.GetYield(this);
            }
            else
            {
                return 0;
            }
        }

    }
}
