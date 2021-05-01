using Klyukay.UnityLogic.Cars.Wheels;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Klyukay.UnityLogic.Cars
{
    public sealed class CarInputController : MonoBehaviour
    {

        [SerializeField] private WheelController wheelController;
        
        private CarInput input;

        private AccelerationStatus activeStatus = AccelerationStatus.NoMoving;
        private AccelerationStatus sendStatus = AccelerationStatus.NoMoving;
        
        private bool isInitialized = false;

        public void Init()
        {
            if (isInitialized) return;

            wheelController.Init();
            
            input = new CarInput();
            input.Enable();

            input.Car.Accelerate.started += HandleAccelerate;
            input.Car.Accelerate.canceled += HandleAccelerateRelease;
            
            input.Car.DeAccelerate.started += HandleDeAccelerate;
            input.Car.DeAccelerate.canceled += HandleDeAccelerateRelease;

            isInitialized = true;
        }

        private void OnDestroy()
        {
            if (!isInitialized) return;
            
            input.Disable();
            
            input.Car.Accelerate.started -= HandleAccelerate;
            input.Car.Accelerate.canceled -= HandleAccelerateRelease;
            
            input.Car.DeAccelerate.started -= HandleDeAccelerate;
            input.Car.DeAccelerate.canceled -= HandleDeAccelerateRelease;
            
            input.Dispose();
            input = null;
            
            isInitialized = false;
        }

        private void HandleAccelerate(InputAction.CallbackContext obj)
        {
            activeStatus |= AccelerationStatus.AccelPressed;
            if (!activeStatus.IsDeAccelerationPressedFirst()) activeStatus |= AccelerationStatus.AccelPressedFirst;

            if (activeStatus.IsAccelerationPressedFirst() && !sendStatus.IsAccelerationPressed())
            {
                sendStatus = AccelerationStatus.AccelPressed;
                wheelController.Accelerate();
            }
        }

        private void HandleAccelerateRelease(InputAction.CallbackContext obj)
        {
            if (activeStatus.IsAccelerationPressedFirst()) activeStatus ^= AccelerationStatus.AccelPressedFirst;
            activeStatus ^= AccelerationStatus.AccelPressed;

            if (activeStatus.IsDeAccelerationPressedFirst() && !sendStatus.IsDeAccelerationPressed())
            {
                sendStatus = AccelerationStatus.DeAccelPressed;
                wheelController.DeAccelerate();
            }
            else if (activeStatus == AccelerationStatus.NoMoving && sendStatus != AccelerationStatus.NoMoving)
            {
                sendStatus = AccelerationStatus.NoMoving;
                wheelController.StopMoving();
            }
        }
        
        private void HandleDeAccelerate(InputAction.CallbackContext obj)
        {
            activeStatus |= AccelerationStatus.DeAccelPressed;

            if (activeStatus.IsDeAccelerationPressedFirst() && !sendStatus.IsDeAccelerationPressed())
            {
                sendStatus = AccelerationStatus.DeAccelPressed;
                wheelController.DeAccelerate();
            }
        }

        private void HandleDeAccelerateRelease(InputAction.CallbackContext obj)
        {
            activeStatus ^= AccelerationStatus.DeAccelPressed;
            if (activeStatus.IsAccelerationPressed()) activeStatus |= AccelerationStatus.AccelPressedFirst;

            if (activeStatus.IsAccelerationPressedFirst() && !sendStatus.IsAccelerationPressed())
            {
                sendStatus = AccelerationStatus.AccelPressed;
                wheelController.Accelerate();
            }
            else if (activeStatus == AccelerationStatus.NoMoving &&  sendStatus != AccelerationStatus.NoMoving)
            {
                sendStatus = AccelerationStatus.NoMoving;
                wheelController.StopMoving();
            }
        }
        
    }
}