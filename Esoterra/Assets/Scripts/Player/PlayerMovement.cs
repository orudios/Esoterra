using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float playerSpeed = 12f;
    public float gravityConstant = -9.81f;
    public float playerJumpHeight = 2f;
    public float playerSprintBoost = 2.2f;

    // groundChecker to serve as an addition to the CharacterController and aid with ground detection
    public Transform groundChecker;
    public float groundDistance = 0.4f;
    public LayerMask groundIndicator;

    Vector3 playerVelocity;
    bool grounded;


    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        Vector3 playerMovement = transform.right * horizontalAxis + transform.forward * verticalAxis;
        
        controller.Move(playerMovement * playerSpeed * Time.deltaTime);
        
        // Defines a boolean "grounded" that checks if there are any colliders overlapping with the defined sphere (attached to the bottom of player model)
        grounded = Physics.CheckSphere(groundChecker.position, groundDistance, groundIndicator);

        // Jump
        if (grounded && Input.GetButtonDown("Jump")) {
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -2f * gravityConstant);
        }

        // Fall
        if (grounded && playerVelocity.y < 0) {
            playerVelocity.y = -2f;
        }

        // Deceleration due to gravity
        playerVelocity.y += gravityConstant * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    } 
}