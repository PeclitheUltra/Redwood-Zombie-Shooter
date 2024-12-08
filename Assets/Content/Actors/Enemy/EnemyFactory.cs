using Reflex.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Content.Actors.Enemy
{
    public class EnemyFactory : IFactory<Enemy>
    {
        private readonly Enemy _enemyPrefab;
        private readonly ActorConfigDatabase _actorConfigDatabase;

        public EnemyFactory(Enemy enemyPrefab, ActorConfigDatabase actorConfigDatabase)
        {
            _actorConfigDatabase = actorConfigDatabase;
            _enemyPrefab = enemyPrefab;
        }
        
        public Enemy Get()
        {
            var instance = Object.Instantiate(_enemyPrefab);
            instance.SetConfig(_actorConfigDatabase.Enemies[Random.Range(0, _actorConfigDatabase.Enemies.Length)]);
            return instance;
        }
    }
}