using Content.Sounds;
using UnityEngine;

namespace Content.Actors.Attack
{
    internal class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private ESoundType _impactSound;
        private float _damage;
        private int _piercing;
        private float _destroyTime;
        private float _speed;
        private int _targetHitCount;

        public void SetData(in float damage, in int piercing, in float destroyTime, in float speed)
        {
            _speed = speed;
            _destroyTime = destroyTime;
            _piercing = piercing;
            _damage = damage;
            _rigidbody2D.velocity = transform.right * _speed;
            Destroy(gameObject, destroyTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                SoundPlayer.PlayGlobalOneShot(_impactSound);
                damageable.DealDamage(_damage);
                _targetHitCount++;
                if(_targetHitCount > _piercing)
                    Destroy(gameObject);
            }
        }
    }
}