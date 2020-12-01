using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Crosshair : MonoBehaviour
{
    [Header("Canvas Elements")]
    public Image crosshair;

    // Other
    PlayerController playerController;
    GameObject lookingAtObj;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        CheckLookingAt();
    }

    void CheckLookingAt()
    {
        lookingAtObj = playerController.LookingAt();

        // The player is looking at something
        // Change crosshair colour based on what tag the object has
        if (lookingAtObj)
        {
            // Interactable
            // Player must also be within interaction distance
            if (lookingAtObj.CompareTag("Interactable")
                && lookingAtObj.GetComponent<Interactable>().CanInteract())
            {
                crosshair.color = new Color(0, 180, 255, 255);
            }
            else if (lookingAtObj.CompareTag("InteractableArea")
                && lookingAtObj.GetComponentInParent<Interactable>().CanInteract())
            {
                crosshair.color = new Color(0, 180, 255, 255);
            }
            else
            {
                crosshair.color = Color.white;
            }
        }
        // Not looking at anything; white crosshair
        else
        {
            crosshair.color = Color.white;
        }
    }
}
