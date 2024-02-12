using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.XR;

namespace Backend
{
    // Author: Jacqueline Zhu
    public class FarmPlot : MonoBehaviour
    {
        private int _seedType;
        private FertilizerType _fertilizerType;
        private Adult _worker;


        public FarmPlot(int seedType, FertilizerType fertilizerType, Adult worker = null)
        {
            this._seedType = seedType;
            this._fertilizerType = fertilizerType;
            this._worker = worker;
        }


        /// <summary>
        /// Get/update the seed type of this farm plot. 1 for HYC, 0 for Land. 
        /// </summary>
        /// <returns></returns>
        public int SeedType {
            get { return this._seedType;}
            set { this._seedType = value; }

        }

        /// <summary>
        /// Get/Update the type of fertilizer used for this plot of land.
        /// </summary>
        /// <param name="newFertilizerType"></param>
        public FertilizerType FertilizerType
        {
            get { return this._fertilizerType; }
            set { this._fertilizerType = value; }
        }

        /// <summary>
        /// Get/Update the worker assigned to this plot of land.
        /// </summary>
        /// <param name="newFertilizerType"></param>
        public Adult Worker
        {
            get { return this._worker; }
            set { this._worker = value; }
        }


        /// <summary>
        /// Remove the worker assigned to this farm plot.
        /// </summary>
        public void RemoveWorker()
        {
            this._worker = null;
        }

        /// <summary>
        /// Returns the yield of this plot. Returns 0 if there is no worker assigned to this plot.
        /// </summary>
        /// <returns></returns>
        public int GetYield()
        {
            if (this._worker != null)
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
