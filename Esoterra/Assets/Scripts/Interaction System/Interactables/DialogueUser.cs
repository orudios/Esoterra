using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueUser : Interactable
{
    [Header("Dialogue Details")]
    [TextArea] public string[] dialogueStrings;
    public string nextButtonFinalString = "Leave";

    [HideInInspector] public DialogueManager dialogueManager;


    public virtual void Reset()
    {
        interactionVerb = "Examine";
    }

    public override void Start()
    {
        base.Start();
        dialogueManager = GameObject.Find("UI/Canvas/TextMenu").GetComponent<DialogueManager>();
    }

    public override void Interact()
    {
        base.Interact();
        dialogueManager.AddNewDialogue(displayName, dialogueStrings, nextButtonFinalString);
    }
}
