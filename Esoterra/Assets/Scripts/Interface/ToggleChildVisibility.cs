using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToggleChildVisibility : MonoBehaviour
{
    public string toggleKey = "f3";
    [Tooltip("The active state which child objects should have initially. You do not need to set these manually.")]
    public bool initialActiveState = false;

    bool childrenActive;


    void Start()
    {
        SetInitialStates();
	}

    void Update()
    {
        TryToggleChildren();
    }

    // Change initial active states of children on behalf of the user
    void SetInitialStates()
    {
        if (initialActiveState) {
            ChildrenSetActive(gameObject.transform, true);
        } else {
            ChildrenSetActive(gameObject.transform, false);
        }
        childrenActive = initialActiveState;
    }

    // Do toggle on condition
    void TryToggleChildren()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleChildren();
        }
    }

    // Show or hide children based on their current state
    void ToggleChildren()
    {
        // If active, then hide
        if (childrenActive) {
            ChildrenSetActive(gameObject.transform, false);
            childrenActive = false;
        // Otherwise, display
        } else {
            ChildrenSetActive(gameObject.transform, true);
            childrenActive = true;
        }
    }

    // Recursively set the active state of all children of a transform
    void ChildrenSetActive(Transform transform, bool state)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(state);
            ChildrenSetActive(child, state);
        }
    }
}
