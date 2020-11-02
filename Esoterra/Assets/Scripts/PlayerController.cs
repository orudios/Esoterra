using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // public Objective objective;
    public List<Objective> objectives;

    public float currentHealth;
    public float maxHealth;
    public int strengthLevel;
    public int defenceLevel;
    
    void Start()
    {
        this.currentHealth = this.maxHealth;
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
        Debug.Log("Player died!");
        this.currentHealth = this.maxHealth;
    }
}
