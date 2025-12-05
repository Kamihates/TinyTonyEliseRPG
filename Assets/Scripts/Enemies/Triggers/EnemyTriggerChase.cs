using TinyRPG.Enemies.Core;
using TinyRPG.Enemies.Data;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyTriggerChase : MonoBehaviour
{
    private PlayerMoveController player = null;
    private Enemy enemy;
    private Collider col;
    private EnemyTriggerChase trigger;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        col = GetComponent<Collider>();
        col.isTrigger = true;

        ApplyDetectionRange();
    }

    private void OnTriggerEnter(Collider other)
    {

        player = other.GetComponentInParent<PlayerMoveController>();
   
        if (player != null)
        {
            enemy.targetPlayer = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = other.GetComponentInParent<PlayerMoveController>();
        if (player != null)
        {
            enemy.targetPlayer = null;
        }

    }

    private void ApplyDetectionRange()
    {
        trigger = GetComponent<EnemyTriggerChase>();

        if (trigger != null)
        {
            float range = enemy.stats.detectionRange;
            trigger.transform.localScale = new Vector3(range, trigger.transform.localScale.y, range);
        }
    }

}
