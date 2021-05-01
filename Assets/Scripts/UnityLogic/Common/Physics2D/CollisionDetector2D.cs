using UnityEngine;

namespace Klyukay.UnityLogic.Common.Physics2D
{
    public sealed class CollisionDetector2D : BaseCollisionDetector2D
    {
        
        private void OnCollisionEnter2D(Collision2D other) => CollisionEnterInvoke();
        private void OnCollisionExit2D(Collision2D other) => CollisionExitInvoke();

    }
}