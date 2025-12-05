using TinyRPG.Enemies.StateMachine;
using UnityEngine;
using TinyRPG.Enemies.Core;

public class DeathState : IEnemyState
{
    private Enemy enemy;

    public DeathState(Enemy e) => enemy = e;

    public void OnEnter()
    {
        enemy.gameObject.SetActive(false);
    }

    public void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public void OnUpdate()
    {
        throw new System.NotImplementedException();
    }
}
