using TinyRPG.Enemies.Core;
using UnityEngine;

public class EnemyTriggerAttack : MonoBehaviour
{
    private PlayerMoveController player = null;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
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
}
