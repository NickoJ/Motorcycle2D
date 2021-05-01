using System;

namespace Klyukay.CoreLogic
{
    
    public sealed class Car : ICarLoseProcessor, ICarTrickProcessor
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

        public event Action Wheelie;
        
        internal event Action CarDestroyed;

        public void OnDistanceChange(float distance)
        {
            if (!isAlive) return;
            if (distance < 0) return;

            totalDistance = Math.Max(distance, totalDistance);
        }

        internal void Reset()
        {
            if (isAlive) return;
            
            isAlive = true;
            totalDistance = 0f;
        }

        void ICarLoseProcessor.OutOfBounds() => IsAlive = false;

        void ICarLoseProcessor.Flip() => IsAlive = false;

        void ICarTrickProcessor.DidWheelie()
        {
            if (isAlive) Wheelie?.Invoke();
        }
        
    }
    
}