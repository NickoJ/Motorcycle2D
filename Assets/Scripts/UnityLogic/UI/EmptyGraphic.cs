using UnityEngine.UI;

namespace Klyukay.UnityLogic.UI
{
    
    public sealed class EmptyGraphic : Graphic
    {
        
        protected override void OnPopulateMesh(VertexHelper vh) => vh.Clear();
        
    }
    
}
