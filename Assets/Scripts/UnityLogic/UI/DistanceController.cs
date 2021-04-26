using System;
using Klyukay.CoreLogic;
using TMPro;
using UnityEngine;

namespace Klyukay.UnityLogic.UI
{
    
    public sealed class DistanceController : MonoBehaviour
    {

        [SerializeField] private TMP_Text text = default;
        
        private Car car;
        
        private int roundedDistance;
        
        public void SetCar(Car car)
        {
            this.car = car;
            
            UpdateView(true);
        }

        private void LateUpdate() => UpdateView(false);

        private void UpdateView(bool force)
        {
            int newDistance = (int) (car?.TotalDistance ?? 0f);
            if (!force && newDistance == roundedDistance)
            {
                return;
            }

            roundedDistance = newDistance;
            text.text = roundedDistance.ToString();
        }

        private void Reset()
        {
            text = GetComponent<TMP_Text>();
        }
        
    }
    
}