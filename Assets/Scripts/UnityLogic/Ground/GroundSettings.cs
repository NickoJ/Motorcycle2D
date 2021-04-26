using Klyukay.UnityLogic.Ground;
using UnityEngine;

namespace Klyukay.UnityLogic
{
    
    [CreateAssetMenu]
    public sealed class GroundSettings : ScriptableObject, IGroundSettings
    {

        [SerializeField] private Vector3 startPoint = new Vector3(-10, 0, 0);
        [SerializeField] private GenerationData generationData = new GenerationData(30, 5, 0.6f, 15f);

        [SerializeField] private float regenerateDistance = 15f;

        public Vector3 StartPoint => startPoint;
        public GenerationData GenerationData => generationData;

        public float RegenerateDistance => regenerateDistance;

    }
}
