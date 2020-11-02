using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float playerSpeed = 12f;
    public float gravityConstant = -9.81f;
    public float playerJumpHeight = 3f;

    public Transform groundChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 playerVelocity;
    bool grounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask);

        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector3 playerMovement = transform.right * horizontalAxis + transform.forward * verticalAxis;

        controller.Move(playerMovement * playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && grounded)
        {
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravityConstant);
        }

        playerVelocity.y += gravityConstant * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
