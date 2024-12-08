using System;
using UnityEngine;

namespace Content.Actors.Movement
{
    [Serializable]
    internal class RigidbodyMovement : IMovement
    {
        [SerializeField] private float _movementSpeed;
        private Rigidbody2D _rigidbody;
        
        public IMovement Clone()
        {
            return (IMovement) this.MemberwiseClone();
        }

        public void SetObject(GameObject gameObject)
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        public void Move(in float movementInputX)
        {
            _rigidbody.velocity = movementInputX * Vector2.right * _movementSpeed;
        }

        public void WarpTo(Vector3 position)
        {
            _rigidbody.transform.position = position;
        }
    }
}