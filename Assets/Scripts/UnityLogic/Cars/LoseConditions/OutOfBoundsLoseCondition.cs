using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.LoseConditions
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class OutOfBoundsLoseCondition : LoseCondition
    {

        private Rigidbody2D body;

        private ICarLoseProcessor processor;
        private ICarSettings settings;
        
        public override void Init(ICarLoseProcessor processor, ICarSettings settings)
        {
            this.processor = processor;
            this.settings = settings;

            body = GetComponent<Rigidbody2D>();
        }

        private void LateUpdate()
        {
            if (body.position.y >= settings.LostYPoint) return;
            
            processor.OutOfBounds();
        }
        
    }
    
}