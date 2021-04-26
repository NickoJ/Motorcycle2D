using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.LoseConditions
{
    
    public sealed class CarFlipLoseCondition : LoseCondition
    {

        private Car car;
        
        public override void Init(Car car, ICarSettings settings)
        {
            this.car = car;
        }

        private void OnTriggerEnter2D(Collider2D other) => car.Flip();
        
    }
    
}
