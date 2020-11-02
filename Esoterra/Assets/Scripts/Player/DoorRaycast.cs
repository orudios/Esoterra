using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
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
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, forward, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!doOnce)
                {
                    rayCastObj = hit.collider.gameObject.GetComponent<DoorController>();
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
