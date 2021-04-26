using UnityEngine;

namespace Klyukay.UnityLogic.Cars
{
    
    public interface ICarSettings
    {

        Vector2 StartPosition { get; }
        
        float LostYPoint { get; }
        
    }
    
}