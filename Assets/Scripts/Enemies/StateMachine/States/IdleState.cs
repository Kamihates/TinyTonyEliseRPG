/// <summary>
/// État Idle d'un ennemi.
///
/// Son rôle est de:
/// - attendre qu'un joueur soit détecté
/// - puis passer automatiquement en ChaseState
///
/// Cet état est utilisé quand l'ennemi n'a pas encore commencé à patrouiller
/// ou quand il n'a aucune autre action spécifique à exécuter.

using UnityEngine;
using TinyRPG.Enemies.Core;

namespace TinyRPG.Enemies.StateMachine.States
{
    public class IdleState : IEnemyState
    {
        private Enemy enemy;

        public IdleState(Enemy e) => enemy = e;

        public void OnEnter(){}

        public void OnUpdate()
        {
            if (enemy.targetPlayer != null)
                enemy.stateMachine.ChangeState(new ChaseState(enemy));
        }

        public void OnExit() { }
    }
}