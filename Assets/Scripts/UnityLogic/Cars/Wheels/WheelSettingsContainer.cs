using UnityEngine;

namespace Klyukay.UnityLogic.Cars.Wheels
{
    
    [CreateAssetMenu]
    public sealed class WheelSettingsContainer : ScriptableObject
    {

        [SerializeField] private WheelSettings acceleration;
        [SerializeField] private WheelSettings deAcceleration;
        [SerializeField] private WheelSettings noMoving;

        public WheelSettings Acceleration => acceleration;
        public WheelSettings DeAcceleration => deAcceleration;
        public WheelSettings NoMoving => noMoving;

    }
    
}