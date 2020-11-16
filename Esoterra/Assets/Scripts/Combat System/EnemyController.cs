using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyRange = 10f;
    //This is how far the enemy can see

    Transform target; 
    //Player reference

    NavMeshAgent agent;
    //NavMeshAgent reference

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        //distance between the player and enemy

        if (distance<=enemyRange){
            agent.SetDestination(target.position);
            //chase player

            if (distance<=agent.stoppingDistance){

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
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyRange);
    }
}
