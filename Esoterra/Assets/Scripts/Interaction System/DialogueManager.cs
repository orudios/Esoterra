using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public Interactable interactable;

    [Header("World Space")]
    public TMP_Text worldNameText;
    public TMP_Text worldInteractionText;

    [Header("Canvas")]
    public GameObject dialogueUI;
    public TMP_Text interactableNameText;
    public TMP_Text interactableDialogueText;
    public TMP_Text playerDialogueText;

    // Controls
    string controlStartDialogue = "e";
    string controlExitDialogue = "e";
    string controlNextResponse = "Mouse ScrollWheel";
    string controlPrevResponse = "Mouse ScrollWheel";
    string controlSelectResponse = "r";

    GameObject player;

    float distanceToInteractable;
    float interactionDistance = 3f;

    bool inDialogue = false;
    float currentPlayerResponse = 0;
    int numPlayerResponses;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        numPlayerResponses = interactable.playerDialogue.Length - 1;

        SetActiveObjects(false, new GameObject[] {
            worldNameText.gameObject,
            worldInteractionText.gameObject,
            dialogueUI
        });

        InitialiseWorldText();
    }


    void Update()
    {
        AwaitInteraction();

        RotateObjectsToCamera(new GameObject[] {
            worldNameText.gameObject, 
            worldInteractionText.gameObject
        });
    }


    void SetActiveObjects(bool boolean, GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(boolean);
        }
    }


    void InitialiseWorldText()
    {
        worldNameText.GetComponent<TextMeshPro>().text = interactable.displayName;
        worldInteractionText.GetComponent<TextMeshPro>().text =
            interactable.interactionVerb + " [" + controlStartDialogue.ToUpper() + "]";
    }


    void AwaitInteraction()
    {
        distanceToInteractable = Vector3.Distance(player.transform.position, this.transform.position);

        // Player is too far from Interactable
        if(distanceToInteractable > interactionDistance)
        {
            SetActiveObjects(false, new GameObject[] {
                worldNameText.gameObject,
                worldInteractionText.gameObject
            });
        }

        // Player is near Interactable: enable dialogue
        if(distanceToInteractable <= interactionDistance)
        {
            SetActiveObjects(true, new GameObject[] {
                worldNameText.gameObject,
                worldInteractionText.gameObject
            });

            if(Input.GetKeyDown(controlStartDialogue) && !inDialogue)
            {
                StartDialogue();
            }
            else if(Input.GetKeyDown(controlExitDialogue) && inDialogue)
            {
                ExitDialogue();
            }

            NavigatePlayerResponses();
            UpdateDialogueText();
        }
    }


    void RotateObjectsToCamera(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            obj.transform.rotation = Quaternion.LookRotation(
                (obj.transform.position - Camera.main.transform.position).normalized);
        }
    }


    void NavigatePlayerResponses()
    {
        if(Input.GetAxis(controlNextResponse) < 0f)
        {
            currentPlayerResponse++;
            // Last response option
            if(currentPlayerResponse >= numPlayerResponses)
            {
                currentPlayerResponse = numPlayerResponses;
            }
        }
        else if(Input.GetAxis(controlPrevResponse) > 0f)
        {
            currentPlayerResponse--;
            // First response option
            if (currentPlayerResponse < 0)
            {
                currentPlayerResponse = 0;
            }
        }
    }


    void UpdateDialogueText()
    {
        for(int i = 0; i <= numPlayerResponses; i++)
        {
            if(currentPlayerResponse == i && i <= numPlayerResponses)
            {
                playerDialogueText.text = interactable.playerDialogue[i];
                if(Input.GetKeyDown(controlSelectResponse))
                {
                    interactableDialogueText.text = interactable.interactableDialogue[i+1];
                }
            }
        }
    }


    void StartDialogue()
    {
        dialogueUI.SetActive(true);
        inDialogue = true;
        currentPlayerResponse = 0;
        interactableNameText.text = interactable.displayName;
        interactableDialogueText.text = interactable.interactableDialogue[0];
    }


    void ExitDialogue()
    {
        dialogueUI.SetActive(false);
        inDialogue = false;
        currentPlayerResponse = 0;
    }
}
