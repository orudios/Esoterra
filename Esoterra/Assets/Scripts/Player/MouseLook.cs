using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    private float xRotation = 0f;
    public float mouseSensitivity = 100f;

    public GameOver gameOver;

    // Locks the cursor to the game view inside Unity to prevent it from escaping
    void Start()
    {
        if (gameOver.gameOver == false){
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Code that enables 3D first person camera movement
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);

        if (gameOver.gameOver == true){
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
