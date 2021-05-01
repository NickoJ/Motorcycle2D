using System;
using UnityEngine;

namespace Klyukay.UnityLogic.Common
{
    
    public sealed class Timer : MonoBehaviour
    {

        [SerializeField] private float time = 1f;

        private float timer;

        public event Action TimeOver;

        public void Restart()
        {
            timer = time;
        }
        
        private void OnEnable() => Restart();

        private void LateUpdate()
        {
            if (timer <= 0) return;
            
            timer -= Time.deltaTime;
            if (timer > 0) return;
            
            TimeOver?.Invoke();
        }
        
    }
    
}