using Content.Actors.Attack;
using Content.Actors.Health;
using Content.Actors.Movement;
using UnityEngine;

namespace Content.Actors
{
    public abstract class ActorConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        public abstract IAttack Attack { get; }
        public abstract IMovement Movement { get; }
        public abstract IHealth Health { get; }
    }
}