using UnityEngine;

public class CollateralDamage : MonoBehaviour
{
    // Simple script to enable any object in the world to take damage from weapons
    public float targetHealth = 50f;
    
    public void takeDamage(float damage)
    {
        targetHealth -= damage;
        if (targetHealth <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}

