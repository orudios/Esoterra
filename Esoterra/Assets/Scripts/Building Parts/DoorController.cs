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
        // Checks if audioSources are populated within the gameObject (crewquarters door [parent of  DoorController])
        if (audioSources.Length == 2)
        {   
            // Both sound files are defined within the Game Object
            doorOpenSound = audioSources[0];
            doorCloseSound = audioSources[1];
        }
    }

    // Code governing door open/close animations as well as corresponding sounds for each
    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnimation.SetBool("door_open", true);
            doorOpenSound.Play();
            doorOpen = true;
        }
        else
        {
            doorAnimation.SetBool("door_open", false);
            doorCloseSound.Play();
            doorOpen = false;
        }
    }
}
