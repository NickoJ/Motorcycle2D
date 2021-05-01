using System;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.Wheels
{
    
    [Serializable]
    public struct WheelSettings
    {

        public bool useMotor;
        public MotorData motorData;
        
        [Serializable]
        public struct MotorData
        {
            public float motorSpeed;
            public float maxMotorTorque;
            
            public readonly JointMotor2D ToMotor()
            {
                var motor = new JointMotor2D
                {
                    motorSpeed = motorSpeed, 
                    maxMotorTorque = maxMotorTorque
                };
                return motor;
            }
            
        }
        
    }
    
}