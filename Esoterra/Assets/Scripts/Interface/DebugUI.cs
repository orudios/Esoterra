using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugUI : MonoBehaviour
{
    Text[] childrenText;

    PlayerController playerController;
    Inventory inventory;
    int minID = 1;
    int maxID = 6;


    void Awake()
    {
        childrenText = gameObject.transform.GetComponentsInChildren<Text>();
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	    inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
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
        for (int i = minID; i <= maxID; i++) {
            // If the player has pressed a key corresponding to an Item ID...
            if (Input.GetKey(i.ToString())) {
                // + add resource
                if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus)) {
                    inventory.AddItem(i, 1);
                }
                // - remove resource
                else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus)) {
                    inventory.RemoveItem(i, 1);
                }
            }
        }
    }
}
