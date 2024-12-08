using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Content.Sounds
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private SoundDatabase _soundDatabase;
        [SerializeField] private AudioSource _defaultSource;
        [SerializeField] private AudioSource[] _sourcesOfDifferentPitch;
        private static SoundPlayer _instance;

        private void Awake()
        {
            _instance = this;
        }

        public static void PlayGlobalOneShot(ESoundType soundType, bool userRandomPitch = true)
        {
            _instance.Play(soundType, userRandomPitch);
        }

        public void Play(ESoundType soundType, bool userRandomPitch = true)
        {
            var source = userRandomPitch
                ? _sourcesOfDifferentPitch[Random.Range(0, _sourcesOfDifferentPitch.Length)]
                : _defaultSource;
            if (_soundDatabase.TryGetFirst(soundType, out var clip))
            {
                source.PlayOneShot(clip);
            }
        }
    }
}