using UnityEngine;
using TinyRPG.Enemies.Core;

namespace TinyRPG.Enemies.StateMachine.States
{
    public class ChaseState : IEnemyState
    {
        private Enemy enemy;

        public ChaseState(Enemy e) => enemy = e;

        public void OnEnter()
        {
            enemy.agent.speed = enemy.stats.chaseSpeed;
            enemy.animator.SetBool("isRunning", true);
        }

        public void OnUpdate()
        {
            // Si l'ennemi n'a pas de cible, retourner à l'état de patrouille ou d'attente
            if (enemy.targetPlayer == null) 
            {
                // Si l'ennemi a des waypoints
                if (enemy.waypoints != null && enemy.waypoints.Length > 0)
                {
                    enemy.stateMachine.ChangeState(new PatrolState(enemy));
                }
                else
                {
                    enemy.stateMachine.ChangeState(new IdleState(enemy));
                }
                
                return;
            }

            // Déplacer l'ennemi vers le joueur
            enemy.agent.SetDestination(enemy.targetPlayer.transform.position);

            if(enemy.isPlayerIsInAttackArea)
            {
                enemy.stateMachine.ChangeState(new AttackState(enemy));
            }
        }

        public void OnExit()
        {
            enemy.agent.speed = enemy.stats.moveSpeed;
            enemy.animator.SetBool("isRunning", false);
        }
    }
}