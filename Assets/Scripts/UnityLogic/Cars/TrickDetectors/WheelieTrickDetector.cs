using Klyukay.CoreLogic;
using Klyukay.UnityLogic.Common.Physics2D;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.TrickDetectors
{

    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class WheelieTrickDetector : TrickDetector
    {

        [SerializeField] private BaseCollisionDetector2D detector;

        private Rigidbody2D body;

        private float startAngle = 0f;

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
            
            detector.CollisionEnter += HandleCollisionEnter;
            detector.CollisionExit += HandleCollisionExit;
        }

        private void OnDestroy()
        {
            detector.CollisionEnter -= HandleCollisionEnter;
            detector.CollisionExit -= HandleCollisionExit;            
        }

        protected override void ApplyTrickTo(in ICarTrickProcessor processor) => processor.DidWheelie();

        private void HandleCollisionEnter()
        {
            var endAngle = Mathf.Round(body.rotation / 360f) * 360f;
            if (!Mathf.Approximately(endAngle, startAngle)) OnTrickDetected();
        }

        private void HandleCollisionExit()
        {
            startAngle = Mathf.Round(body.rotation / 360f) * 360f;
        }
    }
    
}