/// <summary>
/// Interface pour tous les states d'un ennemi (Idle, Patrol, Chase, Attack, etc.)
/// 
/// Chaque states doit implémenter :
/// - OnEnter() : appelé une fois au début du state
/// - OnUpdate() : appelé à chaque frame pour exécuter la logique du state
/// - OnExit()  : appelé une fois quand on quitte l'état
/// </summary>

using UnityEngine;

namespace TinyRPG.Enemies.StateMachine
{
    public interface IEnemyState
    {
        public void OnEnter();
        public void OnUpdate();
        public void OnExit();
    }
}