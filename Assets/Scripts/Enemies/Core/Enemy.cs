using UnityEngine;
using UnityEngine.AI;
using TinyRPG.Enemies.Data;
using TinyRPG.Enemies.StateMachine.States;
using TinyRPG.Enemies.StateMachine;
//using TinyRPG.Player;

namespace TinyRPG.Enemies.Core
{

    public class Enemy : MonoBehaviour
    {
        [NaughtyAttributes.Foldout("Stats")] public EnemyStats stats;
        [Header("Patrol Waypoints")] public Transform[] waypoints;

        public NavMeshAgent agent { get; private set; }
        public PlayerMovement targetPlayer { get; private set; }
        public EnemyStateMachine stateMachine { get; private set; }

        public Animator animator { get; private set; }

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = stats.moveSpeed;
            animator = GetComponentInChildren<Animator>();
            stateMachine = new EnemyStateMachine();
        }

        private void Start()
        {
            if (waypoints != null && waypoints.Length > 0)
                stateMachine.ChangeState(new PatrolState(this));
            else
                stateMachine.ChangeState(new IdleState(this));
        }

        private void Update()
        {
            stateMachine.OnUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
/*            if( other.GetComponent<PlayerMovement>() != null);
            {
                targetPlayer = other.transform;
            }*/
        }

        private void OnTriggerExit(Collider other)
        {
/*            if (other.GetComponent<PlayerMovement>() != null) ;
            {
                targetPlayer = null;
            }*/
        }
    }
}