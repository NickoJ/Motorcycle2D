using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.TrickDetectors
{
    
    public abstract class TrickDetector : MonoBehaviour
    {
        
        private ICarTrickProcessor processor;

        public void Init(ICarTrickProcessor processor)
        {
            this.processor = processor;
        }

        protected void OnTrickDetected()
        {
            if (processor is null) return;
            ApplyTrickTo(processor);
        }

        protected abstract void ApplyTrickTo(in ICarTrickProcessor processor);

    }
    
}
