using Klyukay.CoreLogic;
using UnityEngine;

namespace Klyukay.UnityLogic.Cars.LoseConditions
{
    
    public abstract class LoseCondition : MonoBehaviour
    {

        public abstract void Init(ICarLoseProcessor processor, ICarSettings settings);

    }
    
}