using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Door : Interactable
{
    [Header("In-Game Text (Back)")]
    public TMP_Text displayNameTextBack;
    public TMP_Text interactionVerbTextBack;
    
    [Header("Door Details")]
    public bool locked = false;
    public bool open = false;

    // Audio
    AudioSource audioOpen;
    AudioSource audioClose;

    // Animation
    Animator doorAnimation;
    
    
    public override void Start()
    {
        base.Start();
        ConfigureAudio();
        doorAnimation = gameObject.GetComponent<Animator>();
    }

    void Reset()
    {
        displayName = "Door";
        interactionVerb = "Open";
    }

    public override void SetWorldSpaceText()
    {
        displayNameText.GetComponent<TMP_Text>().text = displayName;
        displayNameTextBack.GetComponent<TMP_Text>().text = displayName;

        interactionVerbText.GetComponent<TMP_Text>().text =
            interactionVerb + " [" + interactKey.ToUpper() + "]";
        interactionVerbTextBack.GetComponent<TMP_Text>().text =
            interactionVerb + " [" + interactKey.ToUpper() + "]";
    }

    // Show or hide name and verb in-game
    // Interactables only need player in range, doors also need them looking
    public override void ToggleWorldSpaceText()
    {
        if (CanInteract() && !open)
        {
            // Doors have two sets of text in-game
            // Only show the set closest to the player on one side of the door
            int closest = ClosestObjectToPlayer(new GameObject[] {
                displayNameText.gameObject,
                displayNameTextBack.gameObject
            });
            // Front text is closest
            if (closest == 0) {
                SetActiveObjects(true, new GameObject[] {
                    displayNameText.gameObject,
                    interactionVerbText.gameObject
                });
            // Back text is closest
            } else {
                SetActiveObjects(true, new GameObject[] {
                    displayNameTextBack.gameObject,
                    interactionVerbTextBack.gameObject
                });
            }
        }
        // Cannot interact or door is already open
        else
        {
            SetActiveObjects(false, new GameObject[] {
                displayNameText.gameObject,
                interactionVerbText.gameObject,
                displayNameTextBack.gameObject,
                interactionVerbTextBack.gameObject
            });
        }
    }

    // Return the index of the closest object to the player
    int ClosestObjectToPlayer(GameObject[] objects)
    {
        int closestIndex = 0;
        float closestDistance = playerController.DistanceTo(objects[0]);
        float compareDistance;

        for (int i=0; i<objects.Length; i++){
            compareDistance = playerController.DistanceTo(objects[i]);
            if (compareDistance < closestDistance) {
                closestDistance = compareDistance;
                closestIndex = i;
            }
        }
        return closestIndex;
    }

    // For doors, player must look at DoorTargetArea rather than gameObject
    public override bool CanInteract()
    {
        if (PlayerInRange() && playerController.LookingAt() == outlineObject) {
            return true;
        }
        return false;
    }

    void ConfigureAudio()
    {
        if (HasAudio()) {
            // Open and close have separate sounds
            if (audioSources.Length == 2) {
                audioOpen = audioSources[0];
                audioClose = audioSources[1];
            // Open and close will both use the first audio source
            } else if (audioSources.Length == 1) {
                audioOpen = audioSources[0];
                audioClose = audioSources[0];
            }
        }
    }

    public override void Interact()
    {
        if (!open)
        {
            open = true;
            doorAnimation.SetBool("door_open", true);
            if (HasAudio()) {
                audioOpen.Play();
            }
        }
        else
        {
            open = false;
            doorAnimation.SetBool("door_open", false);
            if (HasAudio()) {
                audioClose.Play();
            }
        }
    }
}
