using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Content.Actors.Enemy
{
    public class EnemySpawner
    {
        private IFactory<Enemy> _enemyFactory;
        private CancellationTokenSource _cts;
        private ActorConfigDatabase _actorConfigDatabase;

        public EnemySpawner(IFactory<Enemy> enemyFactory, ActorConfigDatabase actorConfigDatabase)
        {
            _actorConfigDatabase = actorConfigDatabase;
            _enemyFactory = enemyFactory;
        }

        public void StartSpawning()
        {
            _cts = new CancellationTokenSource();
            SpawningRoutine(_cts.Token).Forget();
        }

        public void StopSpawning()
        {
            _cts?.Cancel();
        }

        private async UniTaskVoid SpawningRoutine(CancellationToken cancellationToken)
        {
            while (true)
            {
                var newEnemy = _enemyFactory.Get();
                newEnemy.WarpTo(Vector3.right * 10f); 
                float waitTime = Random.Range(_actorConfigDatabase.EnemySpawnIntervalRange.x,
                    _actorConfigDatabase.EnemySpawnIntervalRange.y);
                await UniTask.WaitForSeconds(waitTime, cancellationToken: cancellationToken);
            }
        }
    }
}