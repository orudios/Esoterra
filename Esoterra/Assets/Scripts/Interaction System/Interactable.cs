using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Interactable : MonoBehaviour
{
    [Header("Interactable Details")]
    [Tooltip("The object the player needs to be in range of and look at to interact.")]
    public GameObject targetObject;
    [Tooltip("How close the player needs to be in order to interact.")]
    [Range(1.0f, 10.0f)]
    public float interactionDistance = 5f;

    [Header("In-Game Text")]
    [Tooltip("A human-readable name displayed to the player.")]
    public string displayName;
    [Tooltip("What the player will do with this interactable.")]
    public string interactionVerb;
    public TMP_Text displayNameText;
    public TMP_Text interactionVerbText;

    // Controls
    [HideInInspector] public string keyInteract = "e";

    // Audio
    [HideInInspector] public AudioSource[] audioSources;

    // Player
    [HideInInspector] public PlayerController playerController;


    public virtual void Start()
    {
        audioSources = gameObject.GetComponents<AudioSource>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		
        SetWorldSpaceText();
    }

    void Update()
    {
        ToggleWorldSpaceText();

        if (CanInteract()) {
            targetObject.layer = LayerMask.NameToLayer("Outline");
        } else {
            targetObject.layer = LayerMask.NameToLayer("Default");
        }

        if (CanInteract() && Input.GetKeyDown(keyInteract)) {
            Interact();
        }
    }

    public virtual void SetWorldSpaceText()
    {
        displayNameText.GetComponent<TextMeshPro>().text = displayName;
        interactionVerbText.GetComponent<TextMeshPro>().text =
            interactionVerb + " [" + keyInteract.ToUpper() + "]";
    }

    // Show or hide name and verb above interactables in the world
    // Player must be in range
    public virtual void ToggleWorldSpaceText()
    {
        if (PlayerInRange())
        {
            SetActiveObjects(true, new GameObject[] {
                displayNameText.gameObject,
                interactionVerbText.gameObject
            });
        }
        else
        {
            SetActiveObjects(false, new GameObject[] {
                displayNameText.gameObject,
                interactionVerbText.gameObject
            });
        }
    }

    // Set the active state of multiple GameObjects at once
    public void SetActiveObjects(bool boolean, GameObject[] objects)
    {
        foreach (GameObject obj in objects){
            obj.SetActive(boolean);
        }
    }

    // Check if the player is within range of this interactable
    public bool PlayerInRange()
    {
        float playerDistance = playerController.DistanceTo(gameObject);
        if (playerDistance <= interactionDistance) {
            return true;
        }
        return false;
    }

    // Return true if player is in range and looking at interactable
    public virtual bool CanInteract()
    {
        if (PlayerInRange() && playerController.LookingAt() == gameObject) {
            return true;
        }
        return false;
    }

    public bool HasAudio()
    {
        if (audioSources.Length > 0) {
            return true;
        }
        return false;
    }

    public virtual void Interact()
    {
        Debug.Log("Interact() in Interactable class");
        if (HasAudio()) {
            audioSources[0].Play();
        }
    }
}
