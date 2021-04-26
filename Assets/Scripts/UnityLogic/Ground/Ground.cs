using System.Collections.Generic;
using UnityEngine;

namespace Klyukay.UnityLogic.Ground
{
    
    [RequireComponent(typeof(LineRenderer))]
    [RequireComponent(typeof(EdgeCollider2D))]
    public sealed class Ground : MonoBehaviour
    {

        private LineRenderer lineRenderer;
        private EdgeCollider2D edgeCollider;

        private bool isInitiated = false;
        
        public void Init()
        {
            if (isInitiated) return;

            lineRenderer = GetComponent<LineRenderer>();
            edgeCollider = GetComponent<EdgeCollider2D>();

            isInitiated = true;
        }

        public Vector3 GenerateFromPosition(in Vector3 position, in GenerationData data, 
            Vector3[] v3Cache, List<Vector2> v2Cache)
        {
            v2Cache.Clear();

            Vector3 lastPoint = position;
            v3Cache[0] = lastPoint;
            v2Cache.Add(lastPoint);
            
            for (int i = 1; i < data.pointsCount; ++i)
            {
                float x = lastPoint.x + data.xDistance + (data.xDistance * data.xOffset * Random.Range(-1f, 1f));

                float degAngle = data.maxAngle * Random.Range(-1f, 1f) * Mathf.Deg2Rad;
                float y = Mathf.Tan(degAngle) * (x - lastPoint.x);
                
                lastPoint = new Vector3(x, y, position.z);

                v3Cache[i] = lastPoint;
                v2Cache.Add(lastPoint);
            }
            
            lineRenderer.positionCount = data.pointsCount;
            lineRenderer.SetPositions(v3Cache);
            edgeCollider.SetPoints(v2Cache);

            return lastPoint;
        }
        
    }
    
}