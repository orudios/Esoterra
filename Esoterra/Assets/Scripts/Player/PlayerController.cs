using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // public Objective objective;
    public List<Objective> objectives;

    // Combat stats
    public float currentHealth;
    public float maxHealth;
    public int strengthLevel;
    public int defenceLevel;
    
    // Camera looking
    Ray ray;
    RaycastHit hit;

    void Start()
    {
        this.currentHealth = this.maxHealth;
    }

    void Update()
    {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
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

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public float DistanceTo(GameObject obj)
    {
        return Vector3.Distance(transform.position, obj.transform.position);
    }

    public GameObject LookingAt()
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            return hit.transform.gameObject;
        }
        return null;
    }
}
