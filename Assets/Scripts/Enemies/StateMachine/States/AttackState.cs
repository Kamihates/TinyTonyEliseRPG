using UnityEngine;
using TinyRPG.Enemies.Core;
using System.Collections;
using UnityEngine.InputSystem.XR.Haptics;

namespace TinyRPG.Enemies.StateMachine.States
{
    public class AttackState : MonoBehaviour, IEnemyState
    {
        
        private Enemy enemy;
        private bool canAttack = true;
        public AttackState(Enemy e) => enemy = e;

        public void OnEnter() 
        {
            enemy.StartCoroutine(AttackCD());
        }

        public void OnUpdate()
        {
           
            if (!enemy.isPlayerIsInAttackArea && canAttack)
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
                    canAttack = false;
                    enemy.animator.SetTrigger("attack");

                    
                    if (enemy.AttackBox != null)
                        enemy.AttackBox.SetActive(true);
                }

                yield return new WaitForSeconds(enemy.stats.attackCooldown);

                canAttack = true;

                if (enemy.AttackBox != null)
                    enemy.AttackBox.SetActive(false);

            }
        }
    }
}