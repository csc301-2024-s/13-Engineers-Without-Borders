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


        public FarmPlot(int seedType, int fertilizerType, Adult worker = null)
        {
            this.seedType = seedType;
            this.fertilizerType = fertilizerType;
            this.worker = worker;
        }


        /// <summary>
        /// Returns true if the seed planted on this farmplot is HYC, 1 if HYC, 0 if Land
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

        public Adult GetWorker()
        {
            return this.worker;

        }

        /// <summary>
        /// Update the type of seed planted on this farm plot. 1 if HYC, 0 for land seed
        /// </summary>
        /// <param name="isHYC"></param>
        public void UpdateSeedType(int newSeedType)
        {
            this.seedType = newSeedType;

        }

        /// <summary>
        /// Update the type of fertilizer used for this plot of land.
        /// </summary>
        /// <param name="newFertilizerType"></param>
        public void UpdateFertilizerType(FertilizerType newFertilizerType)
        {
            this.fertilizerType = newFertilizerType;

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

        public int GetYield()
        {
            return YieldPerformanceTable.GetYield(this);
        }

    }
}
