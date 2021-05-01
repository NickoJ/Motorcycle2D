using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.UI
{
    
    public sealed class UIController : MonoBehaviour
    {

        [SerializeField] private DistanceController distance = default;
        [SerializeField] private WheelieController wheelie = default;

        public void Init(Car car)
        {
            wheelie.Init();

            distance.SetCar(car);
            wheelie.SetCar(car);
        }

        private void Reset()
        {
            distance = GetComponentInChildren<DistanceController>(true);
            wheelie = GetComponentInChildren<WheelieController>(true);
        }
        
    }
    
}