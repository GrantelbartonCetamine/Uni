using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Behavior : MonoBehaviour
{
    //State
    private enum State
    {
        Roaming,
        Chasing,
        HuntPlayer,
        Attacking,
    }
    private State state;

    [Header("SpeedVars")]
    public float LaserSpeed = 2f;
    public float EnemyVelocity = 0.0f;
    public float Acceleration = 0.1f;

    [Header("PatroulStats")]
    public float NegativeRndPosition = -1f;
    public float PositiveRndPosition = 1f;
    private bool GoRoaming = false;

    [Header("ActivateAi")]
    public bool ToggleAi = false;
    public bool ActivateHuntPlayer = false;

    [Header("PatroulDestinations")]
    public bool SetDestinationManually = false;
    [SerializeField]
    public Transform[] EnemyDestination;
    public int DestinationIndex;

    [Header("Layers")]
    public LayerMask PlayerLayer = 1 << 10;

    [Header("Positions")]
    private Vector3 StartingPosition;
    public Transform FaceRayOrigin;   

    [Header("Sizes")]
    public float RayCastSize = 20f;
    public float SeeRange = 10f;
    public float ShootRange = 10f;
    public float MeeleRange = 5f;
    public float FaceRaySize = 1.0f; // Unused for now

    [Header("Sizes")]
    public GameObject LaserProjectile;
    private NavMeshAgent Enemy;
    public Animator Animator;
    [SerializeField] Transform EnemyTarget;

    [Header("Animations")]
    int VelocityHash;

    void Start()
    {
        StartingPosition = transform.position;
        VelocityHash = Animator.StringToHash("Velocity");
    }

    private void Awake()
    {
        Enemy = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>();
    }
    void Update()
    {
        ActivateAi();
        CheckFront();
        Debug.Log("Animator Controller: " + Animator.runtimeAnimatorController.name);

    }

    private void ActivateAi()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            ToggleAi = !ToggleAi;
            Debug.Log("Activate Ai : " + ToggleAi);
        }

        if (ToggleAi)
        {
            StateMachine();

        }
        if (!ToggleAi)
        {
            Debug.Log("Ai ist Deactivated");
        }
    }
    private void StateMachine()
    {
        bool PlayerInSight = Physics.CheckSphere(transform.position, SeeRange, PlayerLayer);
        bool PlayerInAttackRange = Physics.CheckSphere(transform.position, ShootRange, PlayerLayer);

        if (!PlayerInAttackRange && !PlayerInSight)
        {
            if (ActivateHuntPlayer && !GoRoaming && ToggleAi)
            {
                state = State.HuntPlayer;
            }
            else if  (!ActivateHuntPlayer && GoRoaming && ToggleAi)
            {
                state = State.Roaming;
            }
        }

        if (PlayerInSight && !PlayerInAttackRange)
        {
            state = State.Chasing;
        }

        if (PlayerInSight && PlayerInAttackRange)
        {
            state = State.Attacking;
        }

        switch (state)
        {

            case State.Roaming:

                Debug.Log("Ai Is Roaming");

                if (SetDestinationManually)
                {
                    if (EnemyDestination.Length == 0)
                    {
                        Debug.Log("No Destination is Set Change to Randomly Patrouling");
                        RandomPatrouling();
                    }
                    else if (!SetDestinationManually)
                    {
                        MoveToNextPatrolPoint();
                    }

                }
                else if (!SetDestinationManually && !ActivateHuntPlayer && !GoRoaming)
                {
                    RandomPatrouling();
                }
                break;

            case State.Chasing:
                Debug.Log("Chase Player");
                Chasing();
                break;

            case State.HuntPlayer:
                Debug.Log("Chase Player on Map");
                ChasePlayer();
                break;

            case State.Attacking:
                Debug.Log("Attack Player");
                Attacking();
                break;
        }
        DoAnimations();
    }

    private void DoAnimations()
    {
        float speed = Enemy.velocity.magnitude * EnemyVelocity;  
        Animator.SetFloat("Velocity", speed);

        if (speed < 0.1f)  
        {
            Animator.SetBool("IsIdle", true);
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsAttacking", false);
        }
        else if (state == State.Chasing || state == State.Roaming)
        {
            Animator.SetBool("IsIdle", false);
            Animator.SetBool("IsWalking", true);
            Animator.SetBool("IsAttacking", false);
        }
        else if (state == State.Attacking)
        {
            Animator.SetBool("IsIdle", false);
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsAttacking", true);
        }
    }

    private void MoveToNextPatrolPoint()
    {
        if (Enemy.remainingDistance < 0.2f)
        {
            DestinationIndex = (DestinationIndex + 1) % EnemyDestination.Length;

            Vector3 destination = EnemyDestination[DestinationIndex].transform.position;

            Enemy.SetDestination(destination);
        }
    }
    private void RandomPatrouling()
    {
        if (Enemy.remainingDistance > Enemy.stoppingDistance) return;

        Vector3 randomPosition = StartingPosition + new Vector3(

            UnityEngine.Random.Range(NegativeRndPosition, PositiveRndPosition),
            0,
            UnityEngine.Random.Range(NegativeRndPosition, PositiveRndPosition)

        );

        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
        {
            Enemy.SetDestination(hit.position);
            Debug.Log("New patrol point: " + hit.position);

        }
    }
    private void Chasing()
    {
        if (!GoRoaming)
        {
            float distance = Vector3.Distance(EnemyTarget.position, Enemy.transform.position);
            Debug.Log("Enemy is Hunting Player");
            Debug.Log("Distance between Player and horde is : " + distance);

            Enemy.destination = EnemyTarget.position;
            transform.LookAt(EnemyTarget.transform.position);
        }

    }

    private void ChasePlayer()
    {
        float targetDistance = Vector3.Distance(Enemy.transform.position, EnemyTarget.transform.position);
        Debug.Log("Enemy is Chasing Player | Remaining Distance : " + targetDistance);
        Enemy.SetDestination(EnemyTarget.transform.position);
    }

    private void Attacking()
    {
        Ray ray = new Ray(FaceRayOrigin.transform.position, Enemy.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, RayCastSize))
        {
            Debug.DrawRay(ray.origin, ray.direction * RayCastSize, Color.red);
            Debug.Log("ray hit object : " + hit.collider.gameObject.name);

            if (hit.distance < ShootRange)
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
                    ShootLaser();
            }

            if (hit.distance < MeeleRange)
            {
                MeeleAttack();
            }

        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * RayCastSize, Color.red);
            Debug.Log("Nothing in Front.");
        }
    }

    private void CheckFront()
    {
        Ray ray = new Ray(FaceRayOrigin.transform.position, Enemy.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, RayCastSize))
        {
            Debug.DrawRay(ray.origin, ray.direction * RayCastSize, Color.red);
            Debug.Log("ray hit object : " + hit.collider.gameObject.name);

            if (hit.distance < ShootRange)
            {
                ShootLaser();
            }

            if (hit.distance < MeeleRange)
            {
                MeeleAttack();
            }
        }

        else
        {
            Debug.DrawRay(ray.origin, ray.direction * RayCastSize, Color.red);
            Debug.Log("Nothing in Front.");
        }
    }
    private void ShootLaser()
    {
        GameObject laserobj = Instantiate(LaserProjectile, transform.position, Quaternion.identity);
        Rigidbody rb = LaserProjectile.GetComponent<Rigidbody>();
        rb.velocity = (EnemyTarget.position - transform.position).normalized * LaserSpeed;
    }

    private void MeeleAttack()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform == EnemyTarget)
        {
            Debug.Log("Horde Collide with : " + other);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ShootRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, SeeRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MeeleRange);
    }
}
