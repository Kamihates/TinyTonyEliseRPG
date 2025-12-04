/// <summary>
/// État Idle d'un ennemi.
///
/// Son rôle est de:
/// - commencer en état Idle
/// - vérifier si des waypoints sont disponibles pour passer en état Patrol
///
/// Cet état est utilisé quand l'ennemi n'a pas encore commencé à patrouiller
/// ou quand il n'a aucune autre action spécifique à exécuter.

using TinyRPG.Enemies.Core;
using UnityEditorInternal;
using UnityEngine;

namespace TinyRPG.Enemies.StateMachine.States
{
    public class IdleState : IEnemyState
    {
        private Enemy enemy;

        public IdleState(Enemy e) => enemy = e;

        public void OnEnter(){}

        public void OnUpdate()
        {
            if(enemy.targetPlayer != null)
            {
                enemy.stateMachine.ChangeState(new ChaseState(enemy));
                return;
            }
            
            enemy.agent.SetDestination(enemy.startposition);
        }

        public void OnExit() { }
    }
}