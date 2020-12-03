using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAITest : MonoBehaviour
{
    public NavMeshAgent enemy; 
    
    public LayerMask groundIndicator, playerIndicator;
    public float attackTimeDelta;
    public float visionRange, attackRange;
    public float targetHealth; //enemy health
    
    public bool playerWithinVision, playerWithinAttackRange; //for the enemy to decide whether to chase or attack
    bool attackExecuted; //stops spamming attacks

    public int attackCondition; //identifies which animation is used for the attack
    public float enemyRange = 15f;
    //This is how far the enemy can see

    Transform target; 
    //Player reference

    NavMeshAgent agent;
    //NavMeshAgent reference
    //CharacterController controller;
    //[SerializeField] public enemyAnimations condition;
    public Animator animator;

    bool playerDead;
    
    private AudioSource enemyWalking;

    public float walkTimeDelta;
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

        playerDead = false;

        enemyWalking = gameObject.GetComponent<AudioSource>();

    }

    private void Update()
    {
        // Boolean check fields to determine whether player is within enemy vision/attack range
        playerWithinVision = Physics.CheckSphere(transform.position, visionRange, playerIndicator);
        playerWithinAttackRange = Physics.CheckSphere(transform.position, attackRange, playerIndicator);

        
        if (playerDead == false){
            // Appropriate enemy actions based on boolean check field permutations
        if (playerWithinVision && !playerWithinAttackRange) chasePlayer();
        if (playerWithinVision && playerWithinAttackRange) EnemyAttackPlayer();
        }
        


        
        
        
    }

    void chasePlayer(){
        float distance = Vector3.Distance(target.position, transform.position);
        //distance between the player and enemy
        
        if (distance<=enemyRange && !enemyWalking.isPlaying && playerDead==false){
            agent.SetDestination(target.position);
            //chase player
            Debug.Log("Chasing");
            Debug.Log("Supposed to play now");
            enemyWalking.Play();
            Invoke(nameof(enemyResetSound), walkTimeDelta);
            
            animator.SetInteger("condition", 1);
            
            
            //condition.setCondition(1);
            if (distance<=agent.stoppingDistance){
                //if the enemy is next to the player
                
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
            if (enemyWalking.isPlaying){
                enemyWalking.Stop();
            }
            if (playerDead==false){
                animator.SetInteger("condition", attackCondition);
            }
            health.receiveDamage(10); //making damage to the player
            attackExecuted = true;
            Invoke(nameof(EnemyResetAttackSound), attackTimeDelta);
        }
   
    }

    private void EnemyResetAttackSound()
    {
        enemyWalking.Stop();
        
    }

    public void takeDamage(float damage)
    {
        targetHealth -= damage;
        if (targetHealth <= 0f)
        {
            if(playerDead==false){
                Debug.Log("enemy has died");
                agent.baseOffset=0;
                enemy.speed=0;
                enemy.acceleration=0;
                animator.SetInteger("condition", 3);
                playerDead=true;
                //Death();
            }
            
            //Death();
        }
    }

    void Death()
    {
        
        Destroy(gameObject);
    }

    private void enemyResetSound()
    {
        enemyWalking.Stop();
        
    }


}
