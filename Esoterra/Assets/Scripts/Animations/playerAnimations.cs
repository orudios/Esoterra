using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update

    public playerHealth health;

    private float currentHealth;

    public float cameraRotation;
    Transform playerTarget; 
    //Enemy reference
    void Start()
    {
        animator=GetComponent<Animator>();
        

        GameObject.Find("Ch50_nonPBR").transform.position = new Vector3(100, 0,0);
        //GameObject.Find("Ch50_nonPBR").SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        playerTarget = GameObject.Find("Ch50_nonPBR").transform;
        currentHealth = health.health;
        if (currentHealth>0){
            if (Input.GetAxis("Horizontal")>0||Input.GetAxis("Vertical")>0){
                
                animator.SetInteger("condition", 1);
            }
            else{
                animator.SetInteger("condition",0);
            }
        }else{
            GameObject.Find("Ch50_nonPBR").transform.position = GameObject.Find("Main Camera").transform.position;
            //set player object visible
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x-1.5f, transform.position.y-1.5f, transform.position.z-1.5f);
           // GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x-0.1f, transform.position.y-7f, transform.position.z-0.1f);
            //Move the camera to third person

            Vector3 direction = (playerTarget.position - GameObject.Find("Main Camera").transform.position).normalized;
            //player direction

            Quaternion rotate = Quaternion.LookRotation(new Vector3(direction.x,0, direction.z));
            //which way we rotate

            GameObject.Find("Main Camera").transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * 5f);
            //update camera direction

            
            //GameObject.Find("Main Camera").transform.localRotation = Quaternion.Euler(0, cameraRotation, 0);
            animator.SetInteger("condition", 3);
            //Cursor.lockState = CursorLockMode.Locked;
            //animate
        }
    }

    public void playDeath(){
        Debug.Log("Playing death");
        animator.SetInteger("condition", 3);
    }

    
}
