using Content.Actors.Attack;
using Content.Actors.Health;
using Content.Actors.Movement;
using UnityEngine;

namespace Content.Actors.Player
{
    [CreateAssetMenu(menuName = "Configs/Player")]
    public class PlayerConfig : ActorConfig
    {
        public override IAttack Attack => _projectileAttack;
        public override IMovement Movement => _rigidbodyMovement;
        public override IHealth Health => _health;

        [SerializeField] private ProjectileAttack _projectileAttack;
        [SerializeField] private RigidbodyMovement _rigidbodyMovement;
        [SerializeField] private DefaultHealth _health;

    }
}