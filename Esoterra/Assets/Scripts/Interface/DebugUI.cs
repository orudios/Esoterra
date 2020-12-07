using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugUI : MonoBehaviour
{
    Text[] childrenText;

    PlayerRaycasting playerController;
    Inventory inventory;


    void Awake()
    {
        childrenText = gameObject.transform.GetComponentsInChildren<Text>();
    }

    void Start()
    {
        playerController =
            GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerRaycasting>();
	    inventory =
            GameObject.FindGameObjectWithTag("Player")
            .GetComponentInChildren<Inventory>();
    }

    void Update()
    {
        UpdateText();
        TryInventoryCheat();
    }

    void UpdateText()
    {
        childrenText[0].text = "Position: " + playerController.GetPosition();

        childrenText[1].text = "Looking at: ";
        if (playerController.LookingAt()) {
            childrenText[1].text += playerController.LookingAt();
        }
    }

    // Try cheat on condition
    void TryInventoryCheat()
    {
        // Only allow inventory cheats if debug is enabled
        if (childrenText[0].IsActive()) {
            InventoryCheat();
        }
    }

    void InventoryCheat()
    {
        // Add or remove 1 resource
        for (int i = 1; i <= 6; i++) {
            // If the player has pressed a key corresponding to an Item ID...
            if (Input.GetKey(i.ToString())) {
                // + add
                if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus)) {
                    inventory.AddResource(i, 1);
                }
                // - remove
                else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus)) {
                    inventory.RemoveResource(i, 1);
                }
            }
        }
        // Add 7 of all resources
        if (Input.GetKey("7")) {
            if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus)) {
                for (int i = 1; i <= 6; i++) {
                    inventory.AddResource(i, 7);
                }
            }
        }
    }
}
