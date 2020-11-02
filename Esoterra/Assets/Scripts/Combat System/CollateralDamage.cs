using UnityEngine;

public class CollateralDamage : MonoBehaviour
{
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

