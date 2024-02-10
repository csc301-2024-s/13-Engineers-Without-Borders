using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Backend
{
    public class FarmPlot : MonoBehaviour
    {
        bool isHYC;
        FertilizerType fertilizerType;
        Adult worker;
        bool irrigationOrNot; 
        // private int irrigation;
        // private int ox;


        public FarmPlot(bool isHYC, int fertilizerType, Adult worker = null)
        {
            this.isHYC = isHYC;
            this.fertilizerType = fertilizerType;
            this.worker = worker;
        }


        /// <summary>
        /// Returns true if the seed planted on this farmplot is HYC, false if land seed
        /// </summary>
        /// <returns></returns>
        public bool HYCorNot()
        {
            return this.isHYC;
        }

        public int getFertilizerType()
        {
            return this.fertilizerType;
        }

        public Adult getWorker()
        {
            return this.worker;

        }

        /// <summary>
        /// Update the type of seed planted on this farm plot. True if HYC, false dor land seed
        /// </summary>
        /// <param name="isHYC"></param>
        public void updateSeedType(bool isHYC)
        {
            this.isHYC = isHYC;

        }

        /// <summary>
        /// Update the type of fertilizer used for this plot of land.
        /// </summary>
        /// <param name="newFertilizerType"></param>
        public void updateFertilizerType(FertilizerType newFertilizerType)
        {
            this.fertilizerType = newFertilizerType;

        }

        /// <summary>
        /// Set a new worker for this plot of land
        /// </summary>
        /// <param name="worker"></param>
        public void updateWorker(Adult worker)
        {
            this.worker = worker;

        }

        public void removeWorker()
        {
            this.worker = null;

        }

        public int getYield()
        {
            return 
        }

    }
}
