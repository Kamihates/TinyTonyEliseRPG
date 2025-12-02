using UnityEngine;
using TinyRPG.Enemies.Core;

namespace TinyRPG.Enemies.StateMachine.States
{

    public class AttackState : IEnemyState
    {
        private Enemy enemy;

        public AttackState(Enemy e) => enemy = e;

        public void OnEnter() { }

        public void OnUpdate()
        {

        }

        public void OnExit() { }
    }
}

   