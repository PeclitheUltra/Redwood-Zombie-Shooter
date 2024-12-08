using System;
using Content.Sounds;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Gameplay
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Button _restart, _quit;
        private Action _restartCallback;
        private Action _quitCallback;

        private void Start()
        {
            _restart.onClick.AddListener(RestartClick);
            _quit.onClick.AddListener(QuitClick);
        }

        public void Show(Action restart, Action quit)
        {
            SoundPlayer.PlayGlobalOneShot(ESoundType.GameOver);
            _restartCallback = restart;
            _quitCallback = quit;
            gameObject.SetActive(true);
            Debug.Log("Game over");
        }

        private void RestartClick()
        {
            _restartCallback?.Invoke();
        }

        private void QuitClick()
        {
            _quitCallback?.Invoke();
        }
    }
}
