﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerHealth : MonoBehaviour
{
    public float health;
    public Animator animator;

    public playerAnimations playerAnimationsScript;

    private void Start(){
        animator=GetComponent<Animator>();
        //playerAnimationsScript = gameObject.Find("Ch48_nonPBR").GetComponent<playerAnimations>();
    }


    public void receiveDamage(float damage)
    {
        health -= damage;
        //Debug.Log(health);
        // if (health <= 0f)
        // {
        //     Death();
            
        // }
    }
    void Death()
    {
        //show player object
        //GameObject.Find("Ch48_nonPBR").SetActive(true);

        //move camera to third person
        //GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x-1.5f, transform.position.y-1.5f, transform.position.z-1.5f);

        // death animation
        //animator.SetInteger("condition", 3);
        //playerAnimationsScript.playDeath();
        
        //Debug.Log("Player has died");
        //returnhealth();
    }

    

    
}
