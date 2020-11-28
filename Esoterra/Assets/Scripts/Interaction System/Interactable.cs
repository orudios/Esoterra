using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Interactable : MonoBehaviour
{
    [Header("Interactable Details")]
    [Tooltip("A human-readable name displayed to the player.")]
    public string displayName;
    [Tooltip("What the player will do with this Interactable.")]
    public string interactionVerb;
    [Tooltip("How close the player needs to be to be able to interact.")]
    [Range(2.0f, 8.0f)]
    public float interactionDistance = 5f;

    [Header("World Space Text")]
    public TMP_Text displayNameText;
    public TMP_Text interactionVerbText;

    // Controls
    string controlInteract = "e";

    // Player
    GameObject player;
    float playerDistance;
    
    // Crosshair
    Image crosshair;
    RaycastHit hit;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();

        SetWorldSpaceText();
    }

    void SetWorldSpaceText()
    {
        displayNameText.GetComponent<TextMeshPro>().text = displayName;
        interactionVerbText.GetComponent<TextMeshPro>().text =
            interactionVerb + " [" + controlInteract.ToUpper() + "]";
    }

    void Update()
    {
        TryInteract();
    }

    void TryInteract()
    {
        if (PlayerInRange()) {

            // Show the world space text for this interactable
            SetActiveObjects(true, new GameObject[] {
                displayNameText.gameObject,
                interactionVerbText.gameObject
            });

            // If the player is looking at an interactable
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) {
                if (hit.transform.gameObject.tag == "Interactable") {
                    crosshair.color = Color.red;
                    Debug.Log(hit.transform.name);
                }
                else {
                    crosshair.color = Color.white;
                }
            }

        }
        // Player not in range
        else {
            SetActiveObjects(false, new GameObject[] {
                displayNameText.gameObject,
                interactionVerbText.gameObject
            });
        }
    }

    // Check if player is close enough to interact
    bool PlayerInRange()
    {
        playerDistance = Vector3.Distance(this.transform.position, player.transform.position);
        if (playerDistance <= interactionDistance) {
            return true;
        } else {
            return false;
        }
    }

    // Set the active state of multiple GameObjects at once
    void SetActiveObjects(bool boolean, GameObject[] objects)
    {
        foreach (GameObject obj in objects){
            obj.SetActive(boolean);
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interact() in Interactable class");
    }
}
