using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.LoseConditions
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class OutOfBoundsLoseCondition : LoseCondition
    {

        private Rigidbody2D body;

        private Car car;
        private ICarSettings settings;
        
        public override void Init(Car car, ICarSettings settings)
        {
            this.car = car;
            this.settings = settings;

            body = GetComponent<Rigidbody2D>();
        }

        private void LateUpdate()
        {
            if (body.position.y >= settings.LostYPoint) return;
            
            car.OutOfBounds();
        }
        
    }
    
}