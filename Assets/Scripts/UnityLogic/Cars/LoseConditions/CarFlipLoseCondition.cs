using System;
using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.LoseConditions
{
    
    public sealed class CarFlipLoseCondition : LoseCondition
    {

        private ICarLoseProcessor processor;
        
        public override void Init(ICarLoseProcessor processor, ICarSettings settings)
        {
            this.processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        private void OnTriggerEnter2D(Collider2D other) => processor.Flip();
        
    }
    
}
