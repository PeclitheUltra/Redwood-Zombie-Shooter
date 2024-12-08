using Content.Actors.Enemy;
using Content.Actors.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Content.Actors
{
    [CreateAssetMenu(menuName = "Configs/ActorDatabase")]
    public class ActorConfigDatabase : ScriptableObject
    {
        [field:SerializeField] public PlayerConfig Player { get; private set; }
        [field:SerializeField] public EnemyConfig[] Enemies { get; private set; }
        [field: SerializeField] public Vector2 EnemySpawnIntervalRange { get; private set; }
    }
}
