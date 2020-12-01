using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Resource : Interactable
{
    void Reset()
    {
        interactionVerb = "Collect";
    }

    public override void Interact()
    {
        Debug.Log("Interact() in Resource class");
        Debug.Log("Collected a " + displayName);

        if (HasAudio()) {
            audioSources[0].Play();
        }

        // Destroy the parent object
        // This destroys the interactable, its world space text, and the container
        Destroy(transform.parent.gameObject);
    }
}
