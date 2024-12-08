using Content.Actors;
using Content.Actors.Attack;
using Content.Actors.Enemy;
using Content.Actors.Player;
using Content.Gameplay;
using Content.Sounds;
using Reflex.Core;
using UnityEngine;

namespace Content.DI
{
    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private ActorConfigDatabase _actorConfigDatabase;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Player _player;
        [SerializeField] private AmmoDisplay _ammoDisplay;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private SoundPlayer _soundPlayer;
         
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddScoped(typeof(DesktopPlayerInput), typeof(IPlayerInput));
            containerBuilder.AddSingleton(_actorConfigDatabase, typeof(ActorConfigDatabase));
            containerBuilder.AddSingleton(_enemyPrefab, typeof(Enemy));
            containerBuilder.AddSingleton(typeof(EnemyFactory), typeof(IFactory<Enemy>));
            containerBuilder.AddSingleton(typeof(EnemySpawner), typeof(EnemySpawner));
            containerBuilder.AddSingleton(_player, typeof(Player));
            containerBuilder.AddSingleton(_ammoDisplay, typeof(AmmoDisplay));
            containerBuilder.AddSingleton(_gameOverScreen, typeof(GameOverScreen));
            containerBuilder.AddSingleton(_soundPlayer, typeof(SoundPlayer));
        }
    }
}
