using Content.Actors.Attack;
using UnityEngine;

namespace Content.Actors.Enemy
{
    public interface IDeathDrop : IPrototype<IDeathDrop>
    {
        public void TrySpawnLoot(Vector3 position);
    }
}