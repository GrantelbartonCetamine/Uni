using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;
    public LayerMask GroundLayer, PlayerLayer;
    public float Health;

    //Vars for Patrolling 
    public Vector3 WalkPoint;
    bool WalkPointSet;
    public float WalkDistance;

    public Transform[] PatrolPoints;
    private int currentPatrolIndex = 0;

    //Vars for Attacking 
    public float TimeBetweenAttacks;
    bool HasAttacked;
    public GameObject Projectile;

    //States
    public float SeeRange, AttackRange;
    public bool IsPlayerinRange, playerInAttackRange;

    private bool PrintDebugLogs = false;
    public bool ShowDebugLogs = false;  

    private void Start()
    {
        Player = GameObject.Find("MainCharackter").transform;
        if (PrintDebugLogs == true && Player == null) {

            Debug.Log("Player not found");
        }
        else
        {
            Debug.Log("Player was Found");
        }


        Enemy = GetComponent<NavMeshAgent>();

        if (PrintDebugLogs == true && Player == null)
        {
            Debug.Log("Enemy not found");
        }
        else
        {
            Debug.Log("Enemy was Found");
        }

    }

    private void Update()
    {
        EnemyLogic();

    }

    private void EnemyLogic()
    {
        IsPlayerinRange = Physics.CheckSphere(transform.position, SeeRange, PlayerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, PlayerLayer);

        if (!IsPlayerinRange && !playerInAttackRange)
        {
            Patrolling();
        }
        else if (IsPlayerinRange && !playerInAttackRange)
        {
            Chasing();
        }
        else if (IsPlayerinRange && playerInAttackRange)
        {
            AttackPlayer();
        }

    }

    private void Patrolling()
    {
        if (PatrolPoints.Length == 0) return;

        // Zielpunkt setzen
        if (!Enemy.pathPending && Enemy.remainingDistance < 10.0f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % PatrolPoints.Length;
            Enemy.SetDestination(PatrolPoints[currentPatrolIndex].position);
        }
    }

    //private void Patrolling()
    //{
    //    if (PatrolPoints.Length == 0) return;
    //
    //    // Zielpunkt setzen
    //    if (!Enemy.pathPending && Enemy.remainingDistance < 0.5f)
    //    {
    //        currentPatrolIndex = (currentPatrolIndex + 1) % PatrolPoints.Length;
    //        Enemy.SetDestination(PatrolPoints[currentPatrolIndex].position);
    //    }
    //}

    //private void Patrolling()
    //{
    //    if (!WalkPointSet) PatrollingWithSetetPoints();
    //    if (WalkPointSet) Enemy.SetDestination(WalkPoint);
    //
    //    Vector3 distancetowalkpoint = transform.position - WalkPoint;
    //    if (distancetowalkpoint.magnitude < 1f)
    //    {
    //        WalkPointSet = true;
    //    }
    //    else
    //    {
    //        WalkPointSet = false;
    //    }
    //}

    private void Chasing()
    {
        Enemy.SetDestination(Player.position);
    }

    private void AttackPlayer()
    {

        Enemy.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!HasAttacked)
        {
            Rigidbody body = Instantiate(Projectile , transform.position , Quaternion.identity).GetComponent<Rigidbody>();
            body.AddForce(transform.forward * 32 , ForceMode.Impulse);
            body.AddForce(transform.up, ForceMode.Impulse);

            HasAttacked = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttacks);
        }
    }

    //private void SearchWalkPoint()
    //{
    //    float randomZ = Random.Range(-WalkDistance, WalkDistance);
    //    float randomX = Random.Range(-WalkDistance, WalkDistance);
    //
    //    WalkPoint = new Vector3(transform.position.x + randomX , transform.position.y , transform.position.z + randomZ);
    //
    //    if (Physics.Raycast(WalkPoint , -transform.up , 10f , GroundLayer))
    //    {
    //        WalkPointSet = true;
    //    }
    //}

    private void PatrollingWithSetetPoints()
    {
        if (PatrolPoints.Length == 0) return;

        Transform targetPoint = PatrolPoints[currentPatrolIndex];
        WalkPoint = targetPoint.position;
        Enemy.SetDestination(WalkPoint);
        WalkPointSet = true;

        //Debug.Log($"Destination Set to {WalkPoint} WalkPointSet is now {WalkPointSet}");

        Vector3 distanceToTarget = transform.position - targetPoint.position;
        if (distanceToTarget.magnitude < 1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % PatrolPoints.Length;
            WalkPointSet = false;
            //Debug.Log($"Walkpoint Set to {WalkPointSet} WalkPointSet is now {WalkPointSet}");
        }

    }

    private void ResetAttack()
    { 
        HasAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, SeeRange);
    }



}
