using UnityEngine; 

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Triggered
{
    public abstract class ReactiveComponent : MonoBehaviour, IReactive
    {
        public abstract void OnEnter(GameObject anObject);

        public abstract void OnExit(GameObject anObject);

        public abstract void OnStay(GameObject anObject);
    }
}