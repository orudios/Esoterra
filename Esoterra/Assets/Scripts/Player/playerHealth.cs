using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerHealth : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update

    public void receiveDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Death();
        }
    }
    void Death()
    {
        //show player object
        GameObject.Find("Ch48_nonPBR").SetActive(true);

        //move camera to third person
        GameObject.Find("Main Camera").transform.position = new Vector3(transform.position.x-1.5f, transform.position.y-1.5f, transform.position.z-1.5f);

        // death animation
        Debug.Log("Player has died");
    }

    
}
