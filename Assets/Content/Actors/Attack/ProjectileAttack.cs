using System;
using Content.Sounds;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Content.Actors.Attack
{
    [Serializable]
    internal class ProjectileAttack : IAttack, IAmmoDataSource, IAmmoReceiver
    {
        public event Action AmmoChanged;
        [SerializeField] private Projectile _projectile;
        [SerializeField] private float _attackInterval, _damage, _speed, _destroyTime;
        [SerializeField] private int _piercing;
        [SerializeField] private int _startAmmo;
        [SerializeField] private ESoundType _shootSound;
        private FirePoint _firePoint;
        private float _lastTimeAttacked;
        private int _ammo;
        private GameObject _shooter;

        public IAttack Clone()
        {
            var clone = (ProjectileAttack) this.MemberwiseClone();
            clone._ammo = _startAmmo;
            return clone;
        }

        public void SetObject(GameObject gameObject)
        {
            _shooter = gameObject;
            _firePoint = gameObject.GetComponentInChildren<FirePoint>();
        }

        public void TryAttack()
        {
            if (Time.time - _lastTimeAttacked < _attackInterval || _ammo <= 0)
                return;
            _ammo--;
            AmmoChanged?.Invoke();
            _lastTimeAttacked = Time.time;
            var projectile = Object.Instantiate(_projectile, _firePoint.transform.position, Quaternion.identity, null);
            projectile.transform.right = _shooter.transform.localScale.x > 0 ? Vector3.right : Vector3.left;
            projectile.SetData(_damage, _piercing, _destroyTime, _speed);
            SoundPlayer.PlayGlobalOneShot(_shootSound);
        }

        public int GetAmmo()
        {
            return _ammo;
        }

        public void AddAmmo(int amount)
        {
            _ammo += amount;
            AmmoChanged?.Invoke();
        }
    }
}