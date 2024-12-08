using Content.Actors.Attack;
using Content.Actors.Health;
using Content.Actors.Movement;
using Content.Actors.Player;
using UnityEngine;

namespace Content.Actors.Enemy
{
    [CreateAssetMenu(menuName = "Configs/Enemy")]
    public class EnemyConfig : ActorConfig
    {
        [field:SerializeField] public ActorAnimator EnemyModel { get; private set; }
        public override IAttack Attack => _hitscanAttack;
        public override IMovement Movement => _rigidbodyMovement;
        public override IHealth Health => _defaultHealth;
        public IDeathDrop DeathDrop => _simpleSingleDeathDrop;
        
        [SerializeField] private HitscanAttack _hitscanAttack;
        [SerializeField] private RigidbodyMovement _rigidbodyMovement;
        [SerializeField] private DefaultHealth _defaultHealth;
        [SerializeField] private SimpleSingleDeathDrop _simpleSingleDeathDrop;
    }
}