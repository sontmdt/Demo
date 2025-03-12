using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float followDistance = 10f;
    public float FollowDistance => followDistance;
    [SerializeField] private float attackDistance = 2.1f;
    public float AttackDistance => attackDistance;

    [SerializeField] private float distanceMin = 0.6f;
    public float DistanceMin => distanceMin;    

    [SerializeField] private float enemyMoveSpeed = 1f;

    [SerializeField] public NavMeshAgent agent;
    public Animator animator;
    [SerializeField] private EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => enemyCtrl;

    public IEnemyState currentState;
    public EnemyMovementState moveState;
    public EnemyChaseState chaseState;
    public EnemyAttackState attackState;
    private void Reset()
    {
        this.LoadAgent();
        this.LoadAnimator();
        this.LoadEnemyCtrl();
    }
    private void LoadAgent()
    {
        if (this.agent != null) return;
        this.agent = transform.GetComponent<NavMeshAgent>();
        this.agent.speed = this.enemyMoveSpeed;
        Debug.Log(transform.name + ": LoadAgent", gameObject);
    }
    private void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
    private void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected void Start()
    {
        moveState = new EnemyMovementState();
        chaseState = new EnemyChaseState();
        attackState = new EnemyAttackState();

        ChangeState(moveState);
    }
    protected void Update()
    {
        currentState?.UpdateState(this);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.rotation = new Quaternion(0, 0, 0, 1);

        if (GameCtrl.Instance.Player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


    }

    public void ChangeState(IEnemyState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    public bool ChaseRange()
    {
        return Vector3.Distance(transform.position, GameCtrl.Instance.PlayerCtrl.transform.position) < followDistance;
    }
    //public bool AttackRange()
    //{
    //    float distance = Vector3.Distance(transform.position, GameCtrl.Instance.PlayerCtrl.transform.position);
    //    float a = GameCtrl.Instance.PlayerCtrl.transform.position.y - transform.position.y;
    //    return distance < attackDistance && Mathf.Abs(a) < 0.2;
    //}
    public bool AttackRange()
    {
        float distance = Vector3.Distance(transform.position, GameCtrl.Instance.PlayerCtrl.transform.position);
        return distance < attackDistance;
    }
}
