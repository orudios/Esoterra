using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAITest : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public LayerMask groundIndicator, playerIndicator;
    public Vector3 walkingPath;
    public GameObject projectile;

    public float walkingPathRange;
    public float attackTimeDelta;
    public float visionRange, attackRange;
    public float targetHealth;
    
    public bool playerWithinVision, playerWithinAttackRange;
    bool walkingPathSpecified;
    bool attackExecuted;
    CharacterController controller;
    Animator animator;

    private void Awake()
    {
        // Initialises the player object locally + enemy
        player = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();

        // Initialise the animation controller for the enemy
        controller=GetComponent<CharacterController>();
        animator=GetComponent<Animator>();

    }

    private void Update()
    {
        // Boolean check fields to determine whether player is within enemy vision/attack range
        playerWithinVision = Physics.CheckSphere(transform.position, visionRange, playerIndicator);
        playerWithinAttackRange = Physics.CheckSphere(transform.position, attackRange, playerIndicator);

        // Appropriate enemy actions based on boolean check field permutations
        if (!playerWithinVision && !playerWithinAttackRange) EnemyPatrol();
        if (playerWithinVision && !playerWithinAttackRange) EnemyChasePlayer();
        if (playerWithinVision && playerWithinAttackRange) EnemyAttackPlayer();

        
    }

    private void EnemyPatrol()
    {

        if (!walkingPathSpecified) AcquireWalkingPath();
        if (walkingPathSpecified)
        {
            
            enemy.SetDestination(walkingPath);
        }

        Vector3 distanceUntilWalkingPath = transform.position - walkingPath;
    }

    private void AcquireWalkingPath()
    {
        float positionZ = Random.Range(-walkingPathRange, walkingPathRange);
        float positionX = Random.Range(-walkingPathRange, walkingPathRange);

        walkingPath = new Vector3(transform.position.x + positionX, transform.position.y, transform.position.z + positionZ);

        if (Physics.Raycast(walkingPath, -transform.up, 2f, groundIndicator))
        {
            walkingPathSpecified = true;
        }
    }

    private void EnemyChasePlayer()
    {
        animator.SetInteger("condition", 1);
        enemy.SetDestination(player.position);
    }

    private void EnemyAttackPlayer()
    {
        enemy.SetDestination(transform.position);
        transform.LookAt(player);
        if (!attackExecuted)
        {
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);  
            animator.SetInteger("condition", 2);
            attackExecuted = true;
            Invoke(nameof(EnemyResetAttack), attackTimeDelta);
        }
    }

    private void EnemyResetAttack()
    {
        attackExecuted = false;
    }

    public void takeDamage(float damage)
    {
        targetHealth -= damage;
        if (targetHealth <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
