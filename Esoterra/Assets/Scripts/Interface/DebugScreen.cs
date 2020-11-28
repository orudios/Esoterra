using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DebugScreen : MonoBehaviour
{
    public GameObject debugCanvasText;

    Text position;
    Text lookingAt;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        position = GameObject.Find("Debug Canvas/Text/Position").GetComponent<Text>();
        lookingAt = GameObject.Find("Debug Canvas/Text/Looking at").GetComponent<Text>();
    }

    void Update()
    {
        ToggleText();
        UpdateText();
    }

    void ToggleText()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (debugCanvasText.gameObject.activeSelf) {
                debugCanvasText.gameObject.SetActive(false);
            } else {
                debugCanvasText.gameObject.SetActive(true);
            }
        }
    }

    void UpdateText()
    {
        position.text = "Position: " + player.transform.position;
        lookingAt.text = "Looking at: ";
    }
}
