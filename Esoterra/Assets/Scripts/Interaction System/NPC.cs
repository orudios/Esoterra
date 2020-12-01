using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : Interactable
{
    void Reset()
    {
        interactionDistance = 6f;
        interactionVerb = "Talk";
    }

    public override void Interact()
    {
        Debug.Log("Interact() in NPC class");
        
        if (HasAudio()) {
            audioSources[0].Play();
        }
    }
}
