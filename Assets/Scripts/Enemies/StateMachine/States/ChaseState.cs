using UnityEngine;
using TinyRPG.Enemies.Core;

namespace TinyRPG.Enemies.StateMachine.States
{
    public class ChaseState : IEnemyState
    {
        private Enemy enemy;

        public ChaseState(Enemy e) => enemy = e;

        public void OnEnter() { }

        public void OnUpdate()
        {
            if(enemy.targetPlayer == null) 
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

            // Si le joueur n'est plus détecté, revenir à l'état de patrouille
            enemy.stateMachine.ChangeState(new PatrolState(enemy));

            // Déplacer l'ennemi vers le joueur
            enemy.agent.SetDestination(enemy.targetPlayer.position);
        }

        public void OnExit() { }
    }
}