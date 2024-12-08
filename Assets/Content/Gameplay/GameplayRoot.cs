using System;
using Content.Actors.Attack;
using Content.Actors.Enemy;
using Content.Actors.Player;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Content.Gameplay
{
    public class GameplayRoot : MonoBehaviour
    {
        private EnemySpawner _enemySpawner;
        private Player _player;
        private AmmoDisplay _ammoDisplay;
        private GameOverScreen _gameOverScreen;

        [Inject]
        private void Construct(EnemySpawner enemySpawner, Player player, AmmoDisplay ammoDisplay, GameOverScreen gameOverScreen)
        {
            _gameOverScreen = gameOverScreen;
            _ammoDisplay = ammoDisplay;
            _player = player;
            _enemySpawner = enemySpawner;
            _player.HealthChanged += CheckPlayerHealth;
            _player.AmmoChanged += CheckPlayerAmmo;
        }

        private void CheckPlayerAmmo()
        {
            if (_player.GetAmmo() <= 0)
            {
                HandleLose();
            }
        }

        private void HandleLose()
        {
            Time.timeScale = 0;
            _enemySpawner.StopSpawning();
            _gameOverScreen.Show(RestartGame, QuitGame);
        }

        private void CheckPlayerHealth()
        {
            if (_player.GetHealth01() <= 0)
            {
                HandleLose();
            }
        }

        private void Start()
        {
            _enemySpawner.StartSpawning();
            
            _ammoDisplay.SetSource(_player);
        }

        public void OnDestroy()
        {
            _enemySpawner.StopSpawning();
        }

        private void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}
