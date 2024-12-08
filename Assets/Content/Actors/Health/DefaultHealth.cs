using System;
using Content.Actors.Attack;
using UnityEngine;

namespace Content.Actors.Health
{
    [Serializable]
    internal class DefaultHealth : IHealth, IDamageable
    {
        public event Action HealthChanged;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _startHealth;
        private float _currentHealth;

        public IHealth Clone()
        {
            var clone = (DefaultHealth) this.MemberwiseClone();
            clone._currentHealth = _startHealth;
            return clone;
        }
        
        

        public float GetHealth01()
        {
            return _currentHealth / _maxHealth;
        }

        public void DealDamage(float damage)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke();
        }
    }
}