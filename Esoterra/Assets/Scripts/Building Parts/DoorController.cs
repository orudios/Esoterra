using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimation;
    private bool doorOpen = false;
    
    private void Awake()
    {
        doorAnimation = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            // doorAnimation.Play("glass_door_open", 0, 0.0f);
            doorAnimation.SetBool("door_open", true);
            doorOpen = true;
        }
        else
        {
            // doorAnimation.Play("glass_door_close", 0, 0.0f);
            doorAnimation.SetBool("door_open", false);
            doorOpen = false;
        }
    }
}
