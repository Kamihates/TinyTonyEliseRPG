/// <summary>
/// State de patrouille pour un ennemi
/// 
/// Ce state gère le déplacement automatique entre une liste de waypoints.
/// L'ennemi se déplace en ping-pong : il avance jusqu'au dernier waypoint, 
/// puis revient vers le premier, et ainsi de suite.
///
/// Si un joueur entre dans la zone de détection (via OnTriggerEnter dans Enemy),
/// le state bascule vers ChaseState.
/// </summary>

using UnityEngine;
using TinyRPG.Enemies.Core;

namespace TinyRPG.Enemies.StateMachine.States
{
    public class PatrolState : IEnemyState
    {
        private Enemy enemy;
        private int currentWaypoint = 0;
        private int direction = 1;

        public PatrolState(Enemy e) => enemy = e;

        public void OnEnter()
        {
            enemy.animator.SetBool("isWalking", true);
            enemy.agent.SetDestination(enemy.waypoints[currentWaypoint].position);
        }

        public void OnUpdate()
        {
            if (enemy.targetPlayer != null)
            {
                enemy.stateMachine.ChangeState(new ChaseState(enemy));
                return;
            }

            if (enemy.waypoints == null || enemy.waypoints.Length == 0) return;


            if (!enemy.agent.pathPending &&
                enemy.agent.remainingDistance <= enemy.agent.stoppingDistance)
            {
                currentWaypoint += direction;

                if (currentWaypoint >= enemy.waypoints.Length - 1)
                    direction = -1;
                else if (currentWaypoint <= 0)
                    direction = 1;

                enemy.agent.SetDestination(enemy.waypoints[currentWaypoint].position);
            }
        }

        public void OnExit()
        {
            enemy.animator.SetBool("isWalking", false);
        }
    }

}