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
            
        }

        public void OnExit() { }
    }
}