using System;
using UnityEngine;

namespace Klyukay.UnityLogic.Ground
{
    
    [Serializable]
    public struct GenerationData
    {
        
        [Min(2)] public int pointsCount;
        [Min(1)] public float xDistance;
        [Range(0, 0.9f)] public float xOffset;
        [Range(0, 45)] public float maxAngle;

        public GenerationData(int pointsCount, float xDistance, float xOffset, float maxAngle)
        {
            this.pointsCount = pointsCount;
            this.xDistance = xDistance;
            this.xOffset = xOffset;
            this.maxAngle = maxAngle;
        }
        
    }
    
}