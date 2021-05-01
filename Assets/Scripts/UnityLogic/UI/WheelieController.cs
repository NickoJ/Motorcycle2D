using System;
using Klyukay.CoreLogic;
using Klyukay.UnityLogic.Common;
using UnityEngine;

namespace Klyukay.UnityLogic.UI
{
    
    [RequireComponent(typeof(Timer))]
    public sealed class WheelieController : MonoBehaviour
    {

        private Timer timer;
        private Car car;

        private bool isInitialized = false;
        
        public void Init()
        {
            if (isInitialized) return;

            timer = GetComponent<Timer>();
            timer.TimeOver += HandleTimeOver;
            
            isInitialized = true;
        }
        
        public void SetCar(Car car)
        {
            TryUnsubscribeFromCurrentCar();
            this.car = car;
            TrySubscribeToCurrentCar();

            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            TryUnsubscribeFromCurrentCar();
            car = null;
        }

        private void TrySubscribeToCurrentCar()
        {
            if (car is null) return;

            car.Wheelie += HandleWheelie;
        }

        private void TryUnsubscribeFromCurrentCar()
        {
            if (car is null) return;
            
            car.Wheelie -= HandleWheelie;
        }

        private void HandleTimeOver()
        {
            gameObject.SetActive(false);
        }
        
        private void HandleWheelie()
        {
            gameObject.SetActive(true);
            timer.Restart();
        }
        
    }
}