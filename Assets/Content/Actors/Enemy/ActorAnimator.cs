using System;
using UnityEngine;

namespace Content.Actors.Enemy
{
    public class ActorAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Actor _actor;
        [SerializeField] private bool _syncMovement;
        [SerializeField] private bool _syncAttacking;
        private static readonly int _isMoving = Animator.StringToHash("IsMoving");
        private static readonly int _isAttacking = Animator.StringToHash("IsAttacking");

        private void Start()
        {
            if (!_actor)
                _actor = GetComponentInParent<Actor>();
        }

        private void LateUpdate()
        {
            if(_syncMovement)
                _animator.SetBool(_isMoving, _actor.State == EActorState.Moving);
            if(_syncAttacking)
                _animator.SetBool(_isAttacking, _actor.State == EActorState.Attacking);
        }
    }
}