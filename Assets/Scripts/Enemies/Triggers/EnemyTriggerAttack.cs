using TinyRPG.Enemies.Core;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyTriggerAttack : MonoBehaviour
{
    private PlayerMoveController player = null;
    private Enemy enemy;
    private Collider col;
    private EnemyTriggerAttack trigger;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        col = GetComponent<Collider>();
        col.isTrigger = true;

        ApplyAttackRange();
    }

    private void OnTriggerEnter(Collider other)
    {

        player = other.GetComponentInParent<PlayerMoveController>();
        if (player != null)
        {
            enemy.isPlayerIsInAttackArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = other.GetComponentInParent<PlayerMoveController>();
        if (player != null)
        {
            enemy.isPlayerIsInAttackArea = false;
        }
    }

    private void ApplyAttackRange()
    {
        trigger = GetComponent<EnemyTriggerAttack>();

        if (trigger != null)
        {
            float range = enemy.stats.attackRange;
            trigger.transform.localScale = new Vector3(range, trigger.transform.localScale.y, range);
        }
    }
}
