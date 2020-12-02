using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAITest : MonoBehaviour
{
    public NavMeshAgent enemy;
    //public Transform player;
    public LayerMask groundIndicator, playerIndicator;
    public float attackTimeDelta;
    public float visionRange, attackRange;
    public float targetHealth;
    
    public bool playerWithinVision, playerWithinAttackRange;
    bool attackExecuted;

    public float enemyRange = 15f;
    //This is how far the enemy can see

    Transform target; 
    //Player reference

    NavMeshAgent agent;
    //NavMeshAgent reference
    //CharacterController controller;
    //[SerializeField] public enemyAnimations condition;
    public Animator animator;
    [SerializeField] private playerHealth health;
    private void Start()
    {
        // Initialises the player object locally + enemy
        //player = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();

        // Initialise the animation controller for the enemy
        //controller=GetComponent<CharacterController>();
        animator=GetComponent<Animator>();

        target = PlayerManager.instance.player.transform;
        // this is a script that keeps track of where the player is
        
        agent = GetComponent<NavMeshAgent>(); //game object component belonging to enemy

        //animator["Running"].wrapMode = WrapMode.Clamp;

    }

    private void Update()
    {
        // Boolean check fields to determine whether player is within enemy vision/attack range
        playerWithinVision = Physics.CheckSphere(transform.position, visionRange, playerIndicator);
        playerWithinAttackRange = Physics.CheckSphere(transform.position, attackRange, playerIndicator);

        // Appropriate enemy actions based on boolean check field permutations
        if (playerWithinVision && !playerWithinAttackRange) chasePlayer();
        if (playerWithinVision && playerWithinAttackRange) EnemyAttackPlayer();
        
    }

    void chasePlayer(){
        float distance = Vector3.Distance(target.position, transform.position);
        //distance between the player and enemy

        if (distance<=enemyRange){
            agent.SetDestination(target.position);
            //chase player
            Debug.Log("Chasing");
            animator.SetInteger("condition", 1);
            //condition.setCondition(1);
            if (distance<=agent.stoppingDistance){
                //if the enemy is next to the player
                //animator.SetInteger("condition", 0);
                
                FacePlayer();
                //face the player

            }
            
        }
        
    }
    
    void FacePlayer(){
        Vector3 direction = (target.position - transform.position).normalized;
        //player direction

        Quaternion rotate = Quaternion.LookRotation(new Vector3(direction.x,0, direction.z));
        //which way we rotate

        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 5f);
        //update our own direction
    }

    private void EnemyAttackPlayer()
    {
   
        if (!attackExecuted)
        {
 
            Debug.Log("attacking player");
            //condition.setCondition(2);
            animator.SetInteger("condition", 2);
            health.receiveDamage(10); //making damage to the player
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
