using Content.Sounds;
using UnityEngine;

namespace Content.Actors.Attack
{
    public interface IAttack : IPrototype<IAttack>
    {
        public void SetObject(GameObject gameObject);
        public void TryAttack();
    }
}