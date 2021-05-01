using System;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.Wheels
{
    
    [RequireComponent(typeof(WheelJoint2D))]
    internal sealed class WheelController : MonoBehaviour
    {

        [SerializeField] private WheelSettingsContainer settingsContainer;
        
        private WheelJoint2D joint;

        public void Init()
        {
            if (settingsContainer is null) throw new ArgumentNullException(nameof(settingsContainer));
            
            joint = GetComponent<WheelJoint2D>();
        }

        public void Accelerate() => ApplySettings(settingsContainer.Acceleration);
        public void DeAccelerate() => ApplySettings(settingsContainer.DeAcceleration);
        public void StopMoving() => ApplySettings(settingsContainer.NoMoving);

        private void ApplySettings(in WheelSettings settings)
        {
            if (settings.useMotor) joint.motor = settings.motorData.ToMotor();

            joint.useMotor = settings.useMotor;
        }
        
    }
}