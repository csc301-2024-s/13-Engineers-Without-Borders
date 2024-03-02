namespace Backend
{
    public enum FertilizerType 
    {
        None = 0,
        Low = 1,
        High = 2

    }

    public enum SeedType
    {
        Regular = 0,
        HYC = 1
    }

    // Original Author: Jacqueline Zhu
    public class FarmPlot : HouseholdAsset
    {
        // 1 for HYC, 0 for normal
        public SeedType SeedType { get; set; }

        // Type of fertilizer
        public FertilizerType FertilizerType { get; set; }

        public bool Irrigated { get; set; }

        public FarmPlot(SeedType seedType, FertilizerType fertilizerType)
        {
            SeedType = seedType;
            FertilizerType = fertilizerType;
        }

         // Returns either game's weather index or, if irrigated, best weather
        public int GetWeatherEffect()
        {
            return Irrigated ? 1 : GameState.s_WeatherIndex;
        }

        /// <summary>
        /// Returns the yield of this plot. Return 0 if this plot isn't set to be harvested.
        /// </summary>
        /// <returns></returns>
        public int GetYield()
        {
            return YieldPerformanceTable.GetYield(this);
        }
    }
}
