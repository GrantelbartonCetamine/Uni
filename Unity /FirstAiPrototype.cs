using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;
    public LayerMask GroundLayer, PlayerLayer;
    public float Health;

    public Transform[] PatrolPoints;

    //Patroling
    public Vector3 WalkPoint;
    bool WalkPointSet;
    public float WalkPointRange;

    //Attacking
    public float TimeBetweenAttacks;
    bool HasAttacked;
    public GameObject projectile;

    //States
    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerInAttackRange;

    private My3DMovement m_Movement;

    private void Awake()
    {

        if (Enemy == null)
        {
            Debug.LogError("NavMeshAgent is not assigned in the Inspector!");
        }

        if (projectile == null)
        {
            Debug.LogError("Projectile is not assigned in the Inspector!");
        }

        Player = GameObject.Find("MrMegaKrass").transform;
        Enemy = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        EnemyLogic();
    }

    private void EnemyLogic()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, SightRange, PlayerLayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, PlayerLayer);

        //Debug.Log($"PlayerInSightRange: {PlayerInSightRange}, PlayerInAttackRange: {PlayerInAttackRange}");

        if (!PlayerInSightRange && !PlayerInAttackRange) Patroling();
        if (PlayerInSightRange && !PlayerInAttackRange) Chasing();
        if (PlayerInAttackRange) AttackPlayer();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            My3DMovement health = other.GetComponent<My3DMovement>();
            if (health != null)
            {
                health.TakeDamage(20);
            }
        }
    }

    private void Patroling()
    {
        if (!WalkPointSet) SearchWalkPoint();

        if (WalkPointSet)
            Enemy.SetDestination(WalkPoint);

        Vector3 distanceToWalkPoint = transform.position - WalkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            WalkPointSet = false;
    }

    private void SearchWalkPoint()
    {

        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(WalkPoint, -transform.up, 2f, GroundLayer))
            WalkPointSet = true;
    }


    private void Chasing()
    {

        float distanceToPlayer = Vector3.Distance(Enemy.transform.position, Player.position);

        if (distanceToPlayer <= AttackRange) 
        {
            Debug.Log($"Remaining Distance: {distanceToPlayer}, Attack Range: {AttackRange}");
            AttackPlayer();
        }
        else
        {
            Debug.Log($"Remaining Distance: {distanceToPlayer}, Follow Player");
            Enemy.SetDestination(Player.position); 
        }
    }

    private void AttackPlayer()
    {

        Enemy.SetDestination(transform.position);

        transform.LookAt(Player);

        if (!HasAttacked)
        {

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            HasAttacked = true;
            //Invoke(nameof(ResetAttack), TimeBetweenAttacks);
            ResetAttack();
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
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }



}
