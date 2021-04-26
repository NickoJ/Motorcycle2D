using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.UI
{
    
    public sealed class UIController : MonoBehaviour
    {

        [SerializeField] private DistanceController distance = default;

        public void Init(Car car)
        {
            distance.SetCar(car);
        }

        private void Reset()
        {
            distance = GetComponentInChildren<DistanceController>(true);
        }
        
    }
    
}