using UnityEngine;
using UnityEngine.AI;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform player;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float agroDistanse;
    [SerializeField] public float attakDistanse;
    private Transform target;

    private BaseState currentState;
    public IdleState idleState;
    public ArgrState argrState;
    public AttakState attakState;

    private void Awake()
    {
        // Инициализация состояний
        idleState = gameObject.AddComponent<IdleState>();
        argrState = gameObject.AddComponent<ArgrState>();
        attakState = gameObject.AddComponent<AttakState>();
    }

    public void SwitchState(BaseState newState)
    {
        if (currentState != null)
            currentState.ExitState(this);
        
        currentState = newState;
        currentState.EnterState(this);
    }

    private void Start()
    {
        if (navMeshAgent == null)
            navMeshAgent = GetComponent<NavMeshAgent>();
            
        SwitchState(idleState);
    }

    private void Update()
    {
        if (player != null)
            SetDestination(player);
            
        if (navMeshAgent != null && target != null)
            navMeshAgent.destination = target.position;
            
        if (currentState != null)
            currentState.UpdateState(this);
    }

    public void SetSpeed(float newSpeed)
    {
        if (navMeshAgent != null)
            navMeshAgent.speed = newSpeed;
    }

    public void SetDestination(Transform newDestination)
    {
        target = newDestination;
    }

    public float DistanceToTarget()
    {
        if (target == null) 
        {
            Debug.LogError("Target is not assigned!");
            return Mathf.Infinity;
        }
        
        return Vector3.Distance(transform.position, target.position);
    }
}