using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Content.Actors.Enemy
{
    [Serializable]
    internal class SimpleSingleDeathDrop : IDeathDrop
    {
        [SerializeField] private GameObject _item;
        [Range(0,1f)]
        [SerializeField] private float _chance;
        
        public IDeathDrop Clone()
        {
            return (IDeathDrop) this.MemberwiseClone();
        }

        public void TrySpawnLoot(Vector3 position)
        {
            if (Random.value < _chance)
            {
                Object.Instantiate(_item, position, Quaternion.identity, null);
            }
        }
    }
}