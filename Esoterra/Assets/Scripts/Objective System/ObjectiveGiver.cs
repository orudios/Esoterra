using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectiveGiver : DialogueUser
{
    // Track state and use this to control what happens on interaction
    public bool Given {get; set;}
    public bool Completed {get; set;}

    [Header("Objective Giver Details")]
    [Tooltip("Objective script (class name) to give to player.")]
    public string objectiveScript;

    // Object in the hierarchy which stores the player's objectives
    GameObject playerObjectives;
    // A reference to the specific objective given
    Objective MyObjective {get; set;}


    public override void Reset()
    {
        interactionVerb = "Talk";
        interactionDistance = 6f;
    }

    public override void Start()
    {
        base.Start();
        playerObjectives =
            GameObject.FindGameObjectWithTag("Player")
            .transform.Find("Objectives").gameObject;
    }

    public override void Interact()
    {
        // Never interacted with this giver before
        if (!Given && !Completed) {
            // Audio and original dialogue
            base.Interact();
            GiveObjective();
        }

        // Have interacted, but not completed the objective
        else if (Given && !Completed) {
            if (HasAudio()) audioSources[0].Play();
            CheckObjective();
        }

        // Have interacted and completed the objective
        else {
            if (HasAudio()) audioSources[0].Play();
            dialogueManager.AddNewDialogue(
                displayName, MyObjective.CompletedDialogue, nextButtonFinalString
            );
        }
    }

    void GiveObjective()
    {
        Given = true;

        // Add objective to player and get a reference to it
        MyObjective = (Objective)playerObjectives.AddComponent(
            System.Type.GetType(objectiveScript)
        );
    }

    void CheckObjective()
    {
        if (MyObjective.Completed) {
            Completed = true;
            MyObjective.GiveReward();
            dialogueManager.AddNewDialogue(
                displayName, MyObjective.JustCompletedDialogue, nextButtonFinalString
            );

        // Not complete yet
        } else {
            dialogueManager.AddNewDialogue(
                displayName, MyObjective.NotCompletedDialogue, nextButtonFinalString
            );
        }
    }
}
