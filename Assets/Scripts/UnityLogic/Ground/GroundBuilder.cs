using System.Collections.Generic;
using UnityEngine;

namespace Klyukay.UnityLogic.Ground
{
    
    public sealed class GroundBuilder : MonoBehaviour
    {

        [SerializeField] private Ground[] grounds;

        private IGroundSettings settings;
        
        private Vector3[] groundV3PointsCache;
        private List<Vector2> groundV2PointsCache;

        private int lastGroundIndex = -1;
        private Vector3 lastPointPosition;
        
        private bool isInitiated = false;
        
        public void Init(IGroundSettings settings)
        {
            if (isInitiated) return;

            this.settings = settings;
            
            for (int i = 0; i < grounds.Length; i++)
            {
                grounds[i].Init();
            }

            var generationData = this.settings.GenerationData;
            
            groundV3PointsCache = new Vector3[generationData.pointsCount];
            groundV2PointsCache = new List<Vector2>(generationData.pointsCount);

            ResetState();

            isInitiated = true;
        }

        public void GenerateStartPath()
        {
            ResetState();
            
            for (int i = 0; i < grounds.Length; ++i)
            {
                GenerateNextPathPart();
            }
        }

        public void GenerateNextPathPart()
        {
            int currentGroundIndex = (lastGroundIndex + 1) % grounds.Length;

            var ground = grounds[currentGroundIndex];
            lastPointPosition = ground.GenerateFromPosition(lastPointPosition, settings.GenerationData,
                groundV3PointsCache, groundV2PointsCache);

            lastGroundIndex = currentGroundIndex;
        }

        public bool IsTooCloseToEnd(in Vector2 pos)
        {
            float delta = lastPointPosition.x - pos.x;
            return delta < settings.RegenerateDistance;
        }

        private void ResetState()
        {
            lastPointPosition = settings.StartPoint;
            lastGroundIndex = -1;
        }

        private void Reset()
        {
            grounds = GetComponentsInChildren<Ground>();
        }
        
    }
    
}