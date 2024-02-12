using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Backend
{
    // Author: Jacqueline Zhu
    public class FarmPlot : MonoBehaviour
    {
        int seedType;
        FertilizerType fertilizerType;
        Adult worker;


        public FarmPlot(int seedType, FertilizerType fertilizerType, Adult worker = null)
        {
            this.seedType = seedType;
            this.fertilizerType = fertilizerType;
            this.worker = worker;
        }


        /// <summary>
        /// Returns 1 if HYC, 0 if Land
        /// </summary>
        /// <returns></returns>
        public int GetSeedType()
        {
            return this.seedType;
        }

        public int GetFertilizerType()
        {
            return this.fertilizerType;
        }

        // Returns either game's weather index or, if irrigated (implemented later), best weather
        public int GetWeatherEffect()
        {
            return GameState.s_WeatherIndex;
        }

        public Adult GetWorker()
        {
            return this.worker;

        }

        /// <summary>
        /// Update the type of seed planted on this farm plot. 1 for HYC, 0 for land seed
        /// </summary>
        /// <param name="isHYC"></param>
        public void UpdateSeedType(int seedType)
        {
            this.seedType = seedType;

        }

        /// <summary>
        /// Update the type of fertilizer used for this plot of land.
        /// </summary>
        /// <param name="newFertilizerType"></param>
        public void UpdateFertilizerType(FertilizerType fertilizerType)
        {
            this.fertilizerType = fertilizerType;

        }

        /// <summary>
        /// Set a new worker for this plot of land
        /// </summary>
        /// <param name="worker"></param>
        public void UpdateWorker(Adult worker)
        {
            this.worker = worker;

        }

        public void RemoveWorker()
        {
            this.worker = null;

        }

        /// <summary>
        /// Returns the yield of this plot. Returns 0 if there is no worker assigned to this plot.
        /// </summary>
        /// <returns></returns>
        public int GetYield()
        {
            if (this.worker != null)
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
