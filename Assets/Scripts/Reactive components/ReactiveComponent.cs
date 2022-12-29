using UnityEngine; 

namespace Domain.Interactions.Triggered
{
    public abstract class ReactiveComponent : MonoBehaviour, IReactive
    {
        public abstract void OnEnter(GameObject anObject);

        public abstract void OnExit(GameObject anObject);

        public abstract void OnStay(GameObject anObject);
    }
}