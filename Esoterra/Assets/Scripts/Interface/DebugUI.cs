using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugUI : MonoBehaviour
{
    [Header("Canvas Text")]
    public Text positionText;
    public Text lookingAtText;

    PlayerController playerController;


    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

    void Update()
    {
        UpdateText();
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
