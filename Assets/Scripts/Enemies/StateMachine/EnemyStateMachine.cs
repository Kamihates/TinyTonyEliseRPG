/// <summary>
/// Sert de StateMachine pour un ennemi
/// 
/// Gère la current state de l'ennemi et les transitions entre les states.
/// - ChangeState(newState) : change d'état proprement en appelant OnExit et OnEnter.
/// - OnUpdate() : appelle OnUpdate() de l'état courant à chaque frame.

/// </summary>

using TinyRPG.Enemies.Data;
using UnityEngine;

namespace TinyRPG.Enemies.StateMachine
{
    public class EnemyStateMachine
    {
        private IEnemyState currentState;

        public void ChangeState(IEnemyState newState)
        {
            currentState?.OnExit();
            currentState = newState;
            currentState.OnEnter();
        }

        public void OnUpdate()
        {
            currentState?.OnUpdate();
        }
    }
}
