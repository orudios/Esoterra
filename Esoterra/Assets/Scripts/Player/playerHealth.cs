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
        Debug.Log("Player has died");
    }
}
