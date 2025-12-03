using UnityEngine;
using NaughtyAttributes;

namespace TinyRPG.Enemies.Data
{
    [CreateAssetMenu(menuName = "Enemies/EnemyStats")]
    public class EnemyStats : ScriptableObject
    {
        [BoxGroup("Stats de base")]
        [Range(1.0f, 100.0f)] public float maxHealth = 100f;
        [BoxGroup("Stats de base")]
        [Range(1.0f, 10.0f)] public float moveSpeed = 1f;
        [BoxGroup("Stats de base")]
        [Range(1.0f, 10.0f)] public float chaseSpeed = 4f;

        [BoxGroup("Combat")]
        [Range(5.0f, 100.0f)] public float detectionRange = 5f;
        [BoxGroup("Combat")]
        [Range(1.0f, 100.0f)] public float attackDamage = 10f;
        [BoxGroup("Combat")]
        [Range(1.0f, 5.0f)] public float attackCooldown = 1.5f;

        [BoxGroup("Loot")]
        public int scoreReward = 10;
    }
}