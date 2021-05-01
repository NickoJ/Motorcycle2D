using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.TrickDetectors
{
    
    public sealed class WheelieTrickDetector : TrickDetector
    {

        private bool isTrickDetected = false;
        
        protected override void ApplyTrickTo(in ICarTrickProcessor processor) => processor.DidWheelie();

        private void FixedUpdate()
        {
            
        }

        private void LateUpdate()
        {
            if (!isTrickDetected) return;

            OnTrickDetected();
            
            isTrickDetected = false;
        }
        
    }
    
}