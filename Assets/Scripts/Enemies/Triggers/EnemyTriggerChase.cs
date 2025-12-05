using UnityEngine;
using TinyRPG.Enemies.Core;

// #C'est Elise qui m'a dit de faire comme ça
public class EnemyTriggerChase : MonoBehaviour
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
}
