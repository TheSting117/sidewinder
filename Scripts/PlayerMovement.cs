using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Defines a character controller
    public CharacterController controller;
    //Base movement speed
    public float speed = 12f;
    //Base gravity
    public float gravity = -9.81f;
    //This will check if the base of the player is touching the ground layer
    public Transform groundCheck;
    //Maximum distance where the player is considered "grounded"
    public float groundDistance;
    //Gets the ground layer
    public LayerMask groundMask;
    //Base jump height
    public float jumpHeight = 3f;
    //Initialises an empty Vector3 that will contain calculated velocity
    Vector3 velocity;
    //Bool to check if player is grounded
    bool boolIsGrounded;

    void Update()
    {
        //every frame checks if the groundCheck collider is touching the groundMask layer
        boolIsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if grounded and Y velocity less than 0 (due to negative accel of gravity), set Y velocity to 0
        if (boolIsGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        //Horizontal Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //If grounded and jump key is pressed, go up
        if (Input.GetButtonDown("Jump")&& boolIsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Continuous effect of gravity
        velocity.y += gravity * Time.deltaTime;

        //Moves player
        controller.Move(velocity * Time.deltaTime);
    }
}
