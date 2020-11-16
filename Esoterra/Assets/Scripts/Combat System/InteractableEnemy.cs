using UnityEngine;

// this will be a base class that all objects the player can interact with will derive from

public class InteractableEnemy : MonoBehaviour
{
    public float radius = 3f;

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
        //will draw out a sphere around object on what they can interact with

    }

    public virtual void Interact(){
        // meant to be overwridden
    }

}
