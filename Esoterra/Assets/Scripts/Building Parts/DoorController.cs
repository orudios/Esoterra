using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator doorAnimation;
    private AudioSource[] audioSources;
    private AudioSource doorOpenSound;
    private AudioSource doorCloseSound;
    private bool doorOpen = false;  

    private void Awake()
    {
        doorAnimation = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        if (audioSources.Length == 2)
        {
            doorOpenSound = audioSources[0];
            doorCloseSound = audioSources[1];
        }
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            // doorAnimation.Play("glass_door_open", 0, 0.0f);
            doorAnimation.SetBool("door_open", true);
            // gameObject.GetComponent<AudioSource>().Play();
            doorOpenSound.Play();
            doorOpen = true;
        }
        else
        {
            // doorAnimation.Play("glass_door_close", 0, 0.0f);
            doorAnimation.SetBool("door_open", false);
            doorCloseSound.Play();
            doorOpen = false;
        }
    }
}
