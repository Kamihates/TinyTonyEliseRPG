using UnityEngine;
using NaughtyAttributes;
using System.Xml.Linq;

namespace TinyRPG.Enemies.Data
{
    [CreateAssetMenu(fileName = "New Enemy Data", menuName = "TinyRPG/Enemies/Enemies Data")]
    public class EnemyStats : ScriptableObject
    {
        [HorizontalLine(color: EColor.Black)]
        [Foldout("Stats de base")]
        [Range(1.0f, 100.0f)] public float maxHealth = 100f;
        [Foldout("Stats de base")]
        [Range(1.0f, 10.0f)] public float moveSpeed = 1f;
        [Foldout("Stats de base")]
        [Range(1.0f, 10.0f)] public float chaseSpeed = 4f;

        [HorizontalLine(color: EColor.Black)]
        [Foldout("Combat")]
        [Range(5.0f, 100.0f)] public float detectionRange = 10f;
        [Foldout("Combat")]
        [Range(5.0f, 100.0f)] public float attackRange = 10f;
        [Foldout("Combat")]
        [Range(1.0f, 100.0f)] public float attackDamage = 10f;
        [Foldout("Combat")]
        [Range(1.0f, 5.0f)] public float attackCooldown = 3.5f;

        [HorizontalLine(color: EColor.Black)]
        [Foldout("Loot")]
        public int scoreReward = 10;
    }
}
