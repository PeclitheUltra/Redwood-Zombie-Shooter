using System;
using System.Collections.Generic;
using System.Linq;
using Reflex.Attributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Content.Sounds
{
    [CreateAssetMenu(menuName = "Configs/Sound Database")]
    public class SoundDatabase : ScriptableObject
    {
        [field:SerializeField] public List<SoundItem> Sounds { get; private set; }
       

        public bool TryGetFirst(ESoundType soundType, out AudioClip clip)
        {
            var soundItem = Sounds.FirstOrDefault(x => x.SoundType == soundType);
            if (soundItem != null)
            {
                clip = soundItem.Clips[Random.Range(0, soundItem.Clips.Length)];
                return true;
            }

            clip = null;
            return false;
        }
    }

    [Serializable]
    public class SoundItem
    {
        [field:SerializeField] public ESoundType SoundType { get; private set; }
        [field:SerializeField] public AudioClip[] Clips { get; private set; }
    }

    public enum ESoundType
    {
        Shoot,
        ZombieHit,
        PlayerHit,
        GameOver,
        AmmoPickup
    }
}
