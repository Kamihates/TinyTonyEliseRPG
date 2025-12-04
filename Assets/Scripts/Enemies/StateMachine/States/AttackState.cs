using UnityEngine;
using TinyRPG.Enemies.Core;
using System.Collections;

namespace TinyRPG.Enemies.StateMachine.States
{

    public class AttackState : IEnemyState
    {
        private Enemy enemy;

        public AttackState(Enemy e) => enemy = e;

        public void OnEnter() 
        {
            enemy.StartCoroutine(AttackCD());
        }

        public void OnUpdate()
        {
           
            if (!enemy.isPlayerIsInAttackArea)
            {
                enemy.stateMachine.ChangeState(new ChaseState(enemy));
            }
        }

        public void OnExit() 
        { 
            enemy.StopCoroutine(AttackCD());
        }

        public IEnumerator AttackCD()
        {
            while (enemy.isPlayerIsInAttackArea)
            {
                if (enemy.targetPlayer != null)
                {
                    enemy.animator.SetTrigger("attack");
                    Debug.Log("Enemy inflicted " + enemy.stats.attackDamage + " damage to player.");
                }

                yield return new WaitForSeconds(enemy.stats.attackCooldown);
            }
        }
    }
}