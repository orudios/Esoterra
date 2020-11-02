using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Alien : MonoBehaviour, IEnemy
{
    public int ID {get; set;}  // initialise in Start()
    public float currentHealth;
    public float maxHealth;
    public int strengthLevel;
    public int defenceLevel;

    // Set this to be the same as the layer which the player has
    public LayerMask aggressionLayer;


    void Start()
    {
        ID = 0;
        currentHealth = maxHealth;
    }

    public void DealDamage(int amount)
    {
        return;
    }

    public void ReceiveDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log(gameObject.name + " died, destroying");
        Destroy(gameObject);
    }
}
