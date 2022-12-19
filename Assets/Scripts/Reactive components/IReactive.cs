using UnityEngine;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Triggered
{
    public interface IReactive
    {
        public void OnEnter(GameObject anObject);
        public void OnStay(GameObject anObject);
        public void OnExit(GameObject anObject);
    }
}