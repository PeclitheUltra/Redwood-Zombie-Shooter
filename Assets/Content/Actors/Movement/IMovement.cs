using Content.Actors.Attack;
using UnityEngine;

namespace Content.Actors.Movement
{
    public interface IMovement : IPrototype<IMovement>
    {
        public void SetObject(GameObject gameObject);
        public void Move(in float movementInputX);
        public void WarpTo(Vector3 position);
    }
}