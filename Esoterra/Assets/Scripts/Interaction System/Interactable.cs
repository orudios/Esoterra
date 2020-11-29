using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Interactable : MonoBehaviour
{
    [Header("Controls")]
    public string keyInteract = "e";

    [Header("Interactable Details")]
    [Tooltip("How close the player needs to be in order to interact.")]
    [Range(2.0f, 8.0f)]
    public float interactionDistance = 5f;
    [Tooltip("The object in world space which is highlighted when the player is in range.")]
    public GameObject outlineObject;

    [Header("World Space Text")]
    [Tooltip("A human-readable name displayed to the player.")]
    public string displayName;
    public TMP_Text displayNameText;
    [Tooltip("What the player will do with this Interactable.")]
    public string interactionVerb;
    public TMP_Text interactionVerbText;

    // Player
    PlayerController playerController;
    float playerDistance;


    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		
        SetWorldSpaceText();
    }

    void Update()
    {
        ToggleWorldSpaceText();

        if (CanInteract()) {
            outlineObject.layer = LayerMask.NameToLayer("Outline");
        } else {
            outlineObject.layer = LayerMask.NameToLayer("Default");
        }

        if (CanInteract() && Input.GetKeyDown(keyInteract)) {
            Interact();
        }
    }

    void SetWorldSpaceText()
    {
        displayNameText.GetComponent<TextMeshPro>().text = displayName;
        interactionVerbText.GetComponent<TextMeshPro>().text =
            interactionVerb + " [" + keyInteract.ToUpper() + "]";
    }

    // Show or hide name and verb above interactables in the world
    void ToggleWorldSpaceText()
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
    void SetActiveObjects(bool boolean, GameObject[] objects)
    {
        foreach (GameObject obj in objects){
            obj.SetActive(boolean);
        }
    }

    // Check if the player is close enough to this interactable
    public bool PlayerInRange()
    {
        // Here, gameObject refers to this interactable
        playerDistance = playerController.DistanceTo(gameObject);
        if (playerDistance <= interactionDistance) {
            return true;
        }
        return false;
    }

    // Return true if player is in range and looking at interactable
    public bool CanInteract()
    {
        if (PlayerInRange() && playerController.LookingAt() == gameObject) {
            return true;
        }
        return false;
    }

    public virtual void Interact()
    {
        Debug.Log("Interact() in Interactable class");
    }
}
