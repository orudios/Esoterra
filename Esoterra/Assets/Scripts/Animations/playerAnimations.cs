using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    public playerHealth health;

    private float currentHealth;

    Transform target; 
    //Enemy reference
    void Start()
    {
        animator=GetComponent<Animator>();
        ///health=gameObject.Find("Player").GetComponent<playerHealth>();
        target = GameObject.Find("New Enemy").transform;
        // this is a script that keeps track of where the player is

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = health.health;
        if (currentHealth>0){
            if (Input.GetAxis("Horizontal")>0||Input.GetAxis("Vertical")>0){
                
                animator.SetInteger("condition", 1);
            }
            else{
                animator.SetInteger("condition",0);
            }
        }else{
            GameObject.Find("Ch50_nonPBR").SetActive(true);
            //set player object visible
            GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x-1.5f, transform.position.y-1.5f, transform.position.z-1.5f);
            //Move the camera to third person

            Vector3 direction = (target.position - GameObject.Find("Main Camera").transform.position).normalized;
            //player direction

            Quaternion rotate = Quaternion.LookRotation(new Vector3(direction.x,0, direction.z));
            //which way we rotate

            GameObject.Find("Main Camera").transform.rotation = Quaternion.Slerp(GameObject.Find("Main Camera").transform.rotation, rotate, Time.deltaTime * 5f);
            //update camera direction

            

            animator.SetInteger("condition", 3);
            //animate
        }
    }

    public void playDeath(){
        Debug.Log("Playing death");
        animator.SetInteger("condition", 3);
    }

    
}
