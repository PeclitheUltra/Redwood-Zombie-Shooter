using System;
using Content.Actors.Attack;
using Content.Actors.Health;
using Content.Actors.Movement;
using UnityEngine;

namespace Content.Actors
{
    public abstract class Actor : MonoBehaviour, IHealthDataSource, IDamageable
    {
        public EActorState State { get; protected set; }
        public event Action HealthChanged;
        protected IAttack _attack;
        protected IHealth _health;
        protected IMovement _movement;

        protected void PullActorSettingsFromConfig(ActorConfig actorConfig)
        {
            _attack = actorConfig.Attack.Clone();
            _attack.SetObject(gameObject);
            _movement = actorConfig.Movement.Clone();
            _movement.SetObject(gameObject);
            _health = actorConfig.Health.Clone();
            _health.HealthChanged += HandleHealthChange;
        }

        private void HandleHealthChange()
        {
            if (_health.GetHealth01() <= 0)
            {
                OnDeath();
                Destroy(gameObject);
            }
            HealthChanged?.Invoke();
        }

        public void WarpTo(Vector3 position)
        {
            _movement.WarpTo(position);
        }

        public float GetHealth01()
        {
            return _health.GetHealth01();
        }

        public void DealDamage(float damage)
        {
            _health.DealDamage(damage);
        }

        protected virtual void OnDeath()
        {
            
        }
    }
}