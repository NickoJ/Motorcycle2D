using UnityEngine;

namespace Klyukay.UnityLogic.Cars
{
    
    [CreateAssetMenu]
    public sealed class CarSettings : ScriptableObject, ICarSettings
    {

        [SerializeField] private Vector2 startPosition = new Vector2(0, 3);
        [SerializeField] private float loseYPoint = -50;

        public Vector2 StartPosition => startPosition;
        public float LostYPoint => loseYPoint;

    }
    
}