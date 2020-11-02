using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    // Code governing door operation right outside the initial spawn room
    // Utilising Raycasting to detect when Mouse is on the door
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;
    [SerializeField] private Image crosshair = null;

    private DoorController rayCastObj;
    private bool crosshairActive;
    private bool doOnce;
    private const string interactableTag = "InteractiveObject";

    private void Update()
    {
        // Local reference to RaycastHit
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        // Checks for specified LayerMask including potential layer exclusions
        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, forward, out hit, rayLength, mask))
        {
            // Checks if hit collider meets a specified tag
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    rayCastObj = hit.collider.gameObject.GetComponent<DoorController>();
                    // Calls function to change crosshair to correspond to intractable door that is hovered over with the camera
                    AdjustCrosshair(true);
                }

                crosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    rayCastObj = GameObject.Find("crewquarters_door").GetComponent<DoorController>();
                    rayCastObj.PlayAnimation();
                }
            }
        }

        else
        {
            if (crosshairActive)
            {
                AdjustCrosshair(false);
                doOnce = false;
            }
        }
    }

    void AdjustCrosshair(bool on)
    {
        // Code governing crosshair colour change
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            crosshairActive = false;
        }
    }
}
