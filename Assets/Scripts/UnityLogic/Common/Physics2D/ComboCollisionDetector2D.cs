using System;
using System.Collections.Generic;
using UnityEngine;

namespace Klyukay.UnityLogic.Common.Physics2D
{
    
    public sealed class ComboCollisionDetector2D : BaseCollisionDetector2D
    {

        [SerializeField] private BaseCollisionDetector2D[] detectors = default;

        private DetectorWithState[] detectorsWithState;

        private bool wasEntered;
        private bool wasExit;
        
        private void Start()
        {
            detectorsWithState = new DetectorWithState[detectors?.Length ?? 0];

            for (int i = 0; i < detectorsWithState.Length; i++)
            {
                // ReSharper disable once PossibleNullReferenceException
                detectorsWithState[i] = new DetectorWithState(this, detectors[i], false);
            }
        }

        protected override void ProcessDestroy()
        {
            base.ProcessDestroy();

            if (detectorsWithState is null) return;
            
            for (int i = 0; i < detectorsWithState.Length; i++)
            {
                detectorsWithState[i].Dispose();
                detectorsWithState[i] = null;
            }

            detectorsWithState = null;
        }

        private void OnCollisionEnterHandled()
        {
            if (wasEntered) return;
            
            bool isEntered = true;
            
            for (int i = 0; i < detectorsWithState.Length; ++i)
            {
                if (!detectorsWithState[i].IsEntered)
                {
                    isEntered = false;
                    break;
                }
            }

            if (isEntered)
            {
                wasEntered = true;
                wasExit = false;
                CollisionEnterInvoke();
            }
        }

        private void OnCollisionExitHandled()
        {
            if (wasExit) return;
            
            bool isExit = true;
            
            for (int i = 0; i < detectorsWithState.Length; ++i)
            {
                if (!detectorsWithState[i].IsEntered) continue;
                
                isExit = false;
                break;
            }

            if (isExit)
            {
                wasExit = true;
                wasEntered = false;
                CollisionExitInvoke();
            }
        }

        [ContextMenu(nameof(FindAllDetectors))]
        private void FindAllDetectors()
        {
            var newDetectors = new List<BaseCollisionDetector2D>(GetComponentsInChildren<BaseCollisionDetector2D>());
            newDetectors.Remove(this);
            detectors = newDetectors.ToArray();
        }
        
        private class DetectorWithState : IDisposable
        {

            private readonly ComboCollisionDetector2D owner;
            private readonly BaseCollisionDetector2D detector;
            
            public DetectorWithState(ComboCollisionDetector2D owner, BaseCollisionDetector2D detector, bool isEntered)
            {
                this.owner = owner ? owner : throw new ArgumentNullException(nameof(owner));
                this.detector = detector ? detector : throw new ArgumentNullException(nameof(detector));
                IsEntered = isEntered;

                this.detector.CollisionEnter += HandleCollisionEnter;
                this.detector.CollisionExit += HandleCollisionExit;
            }
            
            public bool IsEntered { get; private set; }

            public void Dispose()
            {
                detector.CollisionEnter -= HandleCollisionEnter;
                detector.CollisionExit -= HandleCollisionExit;
            }

            private void HandleCollisionEnter()
            {
                IsEntered = true;
                owner.OnCollisionEnterHandled();
            }

            private void HandleCollisionExit()
            {
                IsEntered = false;
                owner.OnCollisionExitHandled();
            }
            
        }
        
    }
    
}