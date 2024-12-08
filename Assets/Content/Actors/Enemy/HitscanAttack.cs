using System;
using Content.Actors.Attack;
using Content.Actors.Player;
using Content.Sounds;
using UnityEngine;

namespace Content.Actors.Enemy
{
    [Serializable]
    internal class HitscanAttack : IAttack
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private Vector2 _hitBoxSize;
        [SerializeField] private float _damage;
        [SerializeField] private float _attackInterval;
        [SerializeField] private ESoundType _shootSound;
        private GameObject _gameObject;
        private float _lastAttackTime;

        public IAttack Clone()
        {
            return (HitscanAttack) this.MemberwiseClone();
        }
        public void SetObject(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void TryAttack()
        {
            if (Time.time - _lastAttackTime < _attackInterval)
                return;
            _lastAttackTime = Time.time;
            var hit = Physics2D.OverlapBox(_gameObject.transform.position, _hitBoxSize, 0, _mask);
            SoundPlayer.PlayGlobalOneShot(_shootSound);
            if (hit != null && hit.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.DealDamage(_damage);
            }
        }
    }
}