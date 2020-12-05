using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal")>0||Input.GetAxis("Vertical")>0){
            
            animator.SetInteger("condition", 1);
        }
        else{
            animator.SetInteger("condition",0);
        }
    }
}
