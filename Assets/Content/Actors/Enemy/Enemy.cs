using System;
using Reflex.Attributes;
using UnityEngine;

namespace Content.Actors.Enemy
{
    public class Enemy : Actor
    {
        private EnemyConfig _config;
        private Player.Player _player;
        private IDeathDrop _deathDrop;

        [Inject]
        private void Construct(Player.Player player)
        {
            _player = player;
        }
        
        public void SetConfig(EnemyConfig enemyConfig)
        {
            _config = enemyConfig;
            PullActorSettingsFromConfig(_config);
            _deathDrop = _config.DeathDrop.Clone();
            Instantiate(_config.EnemyModel, transform.position, transform.rotation, transform);
        }

        private void FixedUpdate()
        {
            var delta = _player.transform.position.x - transform.position.x;
            _movement.Move(Mathf.Sign(delta));
            transform.localScale = delta > 0 ? new Vector3(1, 1, 1) : new Vector3(-1,1, 1);
            if (Mathf.Abs(delta) < 2f)
            {
                _attack.TryAttack();
            }
        }

        protected override void OnDeath()
        {
            base.OnDeath();
            _deathDrop.TrySpawnLoot(transform.position);
        }
    }
}