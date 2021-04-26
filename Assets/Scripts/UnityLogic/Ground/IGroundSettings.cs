using Klyukay.UnityLogic.Ground;
using UnityEngine;

namespace Klyukay.UnityLogic
{
    public interface IGroundSettings
    {
        
        Vector3 StartPoint { get; }
        GenerationData GenerationData { get; }
        
        float RegenerateDistance { get; }
        
    }
}