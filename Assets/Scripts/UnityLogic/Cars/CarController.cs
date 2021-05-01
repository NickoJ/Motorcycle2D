using System;
using Klyukay.CoreLogic;
using Klyukay.UnityLogic.Cars.LoseConditions;
using Klyukay.UnityLogic.Cars.TrickDetectors;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars
{
    
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CarInputController))]
    public sealed class CarController : MonoBehaviour, ICarController
    {

        [SerializeField] private TrickDetector[] trickDetectors = default;
        [SerializeField] private LoseCondition[] loseConditions = default;
        
        private Rigidbody2D body;
        private CarInputController input;
        
        private ICarSettings settings;
        
        private Car car;
        
        private Vector2 startPosition;
        
        private bool isInitialized;

        public Vector2 CurrentPosition => body.position;

        public void Init(Car car, ICarSettings settings)
        {
            if (isInitialized) return;

            this.car = car ?? throw new ArgumentNullException(nameof(car));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            
            body = GetComponent<Rigidbody2D>();

            for (int i = 0; i < trickDetectors.Length; ++i)
            {
                var detector = trickDetectors[i];
                detector.Init(this.car);
            }
            
            for (int i = 0; i < loseConditions.Length; ++i)
            {
                var condition = loseConditions[i];
                condition.Init(this.car, this.settings);
            }
            
            input = GetComponent<CarInputController>();
            input.Init();
            
            isInitialized = true;
        }

        public void Enable()
        {
            startPosition = body.position;
            gameObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            float distance = body.position.x - startPosition.x;
            car.OnDistanceChange(distance);
        }

        private void Reset()
        {
            trickDetectors = GetComponentsInChildren<TrickDetector>(true);
            loseConditions = GetComponentsInChildren<LoseCondition>(true);
        }

    }
}
