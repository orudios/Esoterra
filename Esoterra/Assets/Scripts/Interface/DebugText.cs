using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugText : MonoBehaviour
{
    [Header("Controls")]
    public string toggleKey = "f3";
    
    [Header("Canvas Text")]
    public Text positionText;
    public Text lookingAtText;

    // Other
    PlayerController playerController;
    bool isActive = false;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

    void Update()
    {
        ToggleText();
        if (isActive) {UpdateText();}
    }

    void ToggleText()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            // If the debug text is active, hide it
            if (isActive) {
                SetActiveObjects(false, new GameObject[] {
                    positionText.gameObject,
                    lookingAtText.gameObject
                });
                isActive = false;
            // Otherwise, display it
            } else {
                SetActiveObjects(true, new GameObject[] {
                    positionText.gameObject,
                    lookingAtText.gameObject
                });
                isActive = true;
            }
        }
    }

    // Set the active state of multiple GameObjects at once
    void SetActiveObjects(bool boolean, GameObject[] objects)
    {
        foreach (GameObject obj in objects){
            obj.SetActive(boolean);
        }
    }

    void UpdateText()
    {
        positionText.text = "Position: " + playerController.GetPosition();

        lookingAtText.text = "Looking at: ";
        if (playerController.LookingAt()) {
            lookingAtText.text += playerController.LookingAt();
        }
    }
}
