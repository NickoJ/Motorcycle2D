using System;
using Klyukay.UnityLogic.Cars;
using UnityEngine;

namespace Klyukay.UnityLogic.Ground
{
    
    [RequireComponent(typeof(GroundBuilder))]
    public sealed class GroundController : MonoBehaviour
    {

        private GroundBuilder builder;

        private ICarController car;

        private bool isInitialized = false;
        
        public void Init(IGroundSettings settings, ICarController car)
        {
            if (isInitialized) return;

            builder = GetComponent<GroundBuilder>();
            builder.Init(settings);

            this.car = car;
            
            isInitialized = true;
        }

        public void ResetGround() => builder.GenerateStartPath();

        private void FixedUpdate()
        {
            var pos = car.CurrentPosition;
            if (builder.IsTooCloseToEnd(pos))
            {
                builder.GenerateNextPathPart();
            }
        }
        
    }
    
}