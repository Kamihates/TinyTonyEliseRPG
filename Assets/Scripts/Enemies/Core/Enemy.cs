using NaughtyAttributes;
using System.Drawing;
using TinyRPG.Enemies.Data;
using TinyRPG.Enemies.StateMachine;
using TinyRPG.Enemies.StateMachine.States;
using UnityEngine;
using UnityEngine.AI;
//using TinyRPG.Player;

namespace TinyRPG.Enemies.Core
{

/*    public enum EnemyArea
    {
        ChaseArea,
        AttackArea
    }

    [System.Serializable]
    public class EnemyTriggerArea
    {
        public EnemyArea areaType;
    }*/

    public class Enemy : MonoBehaviour
    {
/*        public EnemyTriggerArea[] enemyTriggerAreas;*/

        [field: SerializeField] public EnemyStats stats { get; private set; }
        [field:SerializeField] public Transform[] waypoints { get; private set; }

        public NavMeshAgent agent { get; set; }
        public PlayerMoveController targetPlayer { get; set; }
        //public PlayerMoveController targetPlayer { get; private set; }
        public EnemyStateMachine stateMachine { get; private set; }
        [field:SerializeField, ReadOnly, Foldout("Debug")] public Vector3 startposition { get; private set; }

        public bool isPlayerIsInAttackArea { get;  set; }

        public Animator animator { get; private set; }

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = stats.moveSpeed;
            animator = GetComponentInChildren<Animator>();
            stateMachine = new EnemyStateMachine();

            startposition = transform.position;
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

/*        private void OnTriggerEnter(Collider other)
        {
            PlayerMoveController player = other.GetComponentInParent<PlayerMoveController>();
            if (player != null)
            {
                targetPlayer = player;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            PlayerMoveController player = other.GetComponentInParent<PlayerMoveController>();
            if (player != null)
            {
                targetPlayer = null;
            }

        }*/
    }
}