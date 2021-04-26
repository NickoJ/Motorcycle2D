using System;

namespace Klyukay.CoreLogic
{
    
    public sealed class Car
    {
    
        private bool isAlive;
        private float totalDistance;

        internal Car()
        {
            isAlive = true;
            totalDistance = 0f;
        }
        
        public bool IsAlive
        {
            get => isAlive;
            private set
            {
                if (isAlive == value) return;
                
                isAlive = value;
                if (!isAlive) CarDestroyed?.Invoke();
            }
        }

        public float TotalDistance => totalDistance;

        internal event Action CarDestroyed;

        public void OnDistanceChange(float distance)
        {
            if (!isAlive) return;
            if (distance < 0) return;

            totalDistance = Math.Max(distance, totalDistance);
        }
        
        public void OutOfBounds() => IsAlive = false;
        public void Flip() => IsAlive = false;

        internal void Reset()
        {
            if (isAlive) return;
            
            isAlive = true;
            totalDistance = 0f;
        }
        
    }
    
}