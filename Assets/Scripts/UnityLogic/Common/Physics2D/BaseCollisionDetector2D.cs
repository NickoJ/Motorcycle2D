using System;
using UnityEngine;

namespace Klyukay.UnityLogic.Common.Physics2D
{
    
    public abstract class BaseCollisionDetector2D : MonoBehaviour
    {

        public event Action CollisionEnter;
        public event Action CollisionExit;

        private void OnDestroy()
        {
            CollisionEnter = null;
            CollisionExit = null;

            ProcessDestroy();
        }

        protected void CollisionEnterInvoke() => CollisionEnter?.Invoke();
        protected void CollisionExitInvoke() => CollisionExit?.Invoke();

        protected virtual void ProcessDestroy() {}
        
    }
    
}