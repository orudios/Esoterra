using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC : Interactable
{
    [Header("NPC Details")]
    public string[] dialogueStrings;
    public string endString = "Leave";

    DialogueManager dialogueManager;


    void Reset()
    {
        interactionDistance = 6f;
        interactionVerb = "Talk";
    }

    public override void Start()
    {
        base.Start();
        dialogueManager = GameObject.Find("UI/Canvas/Dialogue").GetComponent<DialogueManager>();
    }

    public override void Interact()
    {
        dialogueManager.AddNewDialogue(displayName, dialogueStrings, endString);
        
        if (HasAudio()) {
            audioSources[0].Play();
        }
    }
}
