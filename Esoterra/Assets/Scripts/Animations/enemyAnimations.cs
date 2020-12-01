using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimations : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Initialise the animation controller for the enemy
        animator=GetComponent<Animator>();
    }

    public void setCondition(int value)
    {
        animator.SetInteger("condition", value);
    }
}
