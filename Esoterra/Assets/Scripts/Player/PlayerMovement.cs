using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Defining variables for the movement script
    public CharacterController controller;
    public float playerSpeed = 12f;
    public float gravityConstant = -9.81f;
    public float playerJumpHeight = 1f;
    public float playerSprintBoost = 2.2f;

    // groundChecker to serve as an addition to the CharacterController and aid with ground detection
    public Transform groundChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundIndicator;

    Vector3 playerVelocity;
    bool grounded;

    void Update()
    {
        // Defines a boolean "grounded" that checks if there are any colliders overlapping with the defined sphere (attached to the bottom of player model)
        grounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundIndicator);


        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        // Defining core movement using the CharacterController
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector3 playerMovement = transform.right * horizontalAxis + transform.forward * verticalAxis;
        controller.Move(playerMovement * playerSpeed * Time.deltaTime);

        // Code governing jumping - ensures the player is grounded (by checking if they are on a groundIndicator)
        if(Input.GetButtonDown("Jump") && grounded)
        {
            Debug.Log("Jumped.");
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravityConstant);
        }

        // Additional deceleration due to gravity
        playerVelocity.y += gravityConstant * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
 

    
}
