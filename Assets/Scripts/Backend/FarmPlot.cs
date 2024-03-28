namespace Backend
{
    /// <summary>
    /// Type of fertilizer.
    /// </summary>
    public enum FertilizerType 
    {
        /// <summary>
        /// No fertilizer.
        /// </summary>
        None = 0,

        /// <summary>
        /// Low fertilizer.
        /// </summary>
        Low = 1,

        /// <summary>
        /// High fertilizer.
        /// </summary>
        High = 2

    }

    /// <summary>
    /// Type of seed.
    /// </summary>
    public enum SeedType
    {
        /// <summary>
        /// Regular seed. This is the default type of seed for every farm plot.
        /// </summary>
        Regular = 0,

        /// <summary>
        /// HYC seeds, which perform better in good weather but worse in bad weather.
        /// </summary>
        HYC = 1
    }

    // Original Author: Jacqueline Zhu
    /// <summary>
    /// A plot of land.
    /// </summary>
    public class FarmPlot : HouseholdAsset
    {
        /// <summary>
        /// What type of seed is planted currently.
        /// </summary>
        public SeedType SeedType { get; set; }

        /// <summary>
        /// What type of fertilizer is currently on the land.
        /// </summary>
        public FertilizerType FertilizerType { get; set; }

        /// <summary>
        /// A value that the yield of this plot is multiplied by.
        /// </summary>
        public float YieldMultiplier { get; set; } = 1;

        /// <summary>
        /// Whether the plot is irrigated.
        /// </summary>
        public bool Irrigated { get; set; }

        /// <summary>
        /// Create a new farm plot with <paramref name="seedType"/> seed type and <paramref name="fertilizerType"/> fertilizer type.
        /// </summary>
        /// <param name="seedType">Seed type.</param>
        /// <param name="fertilizerType">Fertilizer type.</param>
        public FarmPlot(SeedType seedType, FertilizerType fertilizerType)
        {
            SeedType = seedType;
            FertilizerType = fertilizerType;
        }

        /// <summary>
        /// Returns game's weather index or 1 (the best weather) if irrigated.
        /// </summary>
        /// <returns>Game's weather index or 1 (the best weather) if irrigated.</returns>
        public int GetWeatherEffect()
        {
            return Irrigated ? 1 : GameState.s_WeatherIndex;
        }

        /// <summary>
        /// Returns the yield of this plot multiplied by the yield multiplier.
        /// </summary>
        /// <returns>Plot's wheat yield.</returns>
        public int GetYield()
        {
            return (int)(YieldPerformanceTable.GetYield(this) * YieldMultiplier);
        }

        /// <summary>
        /// Sets seed type to regular and fertilizer to none.
        /// </summary>
        public void ClearPlot()
        {
            SeedType = SeedType.Regular;
            FertilizerType = FertilizerType.None;
        }
    }
}
