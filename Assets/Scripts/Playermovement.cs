using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 7f;
    [SerializeField] private float crouchSpeed = 2f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;

    private Vector3 moveDirection;
    private Vector3 velocity;

    public float gravity = -9.81f;
    public float jumpHeight = 4f;

    private CharacterController characterController;
    private Transform playerModel; // Reference to the player model's transform

    private bool isCrouching = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerModel = transform.Find("PlayerModel"); // Assuming the player model is a child of the player object
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float MoveZ = Input.GetAxis("Vertical");
        float MoveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(MoveX, 0, MoveZ).normalized;

        if (Input.GetKeyDown(KeyCode.C)) // Toggle crouch on C key press
        {
            isCrouching = !isCrouching;

            if (isCrouching)
            {
                Crouch();
            }
            else
            {
                StandUp();
            }
        }

        float currentSpeed = isCrouching ? crouchSpeed : (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
        moveDirection *= currentSpeed;

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump")) // Jump
            {
                Jump();
            }
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime; // Applies gravity
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Crouch()
    {
        characterController.height = crouchHeight;
        playerModel.localScale = new Vector3(1, 0.5f, 1); // Adjust the scale for crouching
    }

    private void StandUp()
    {
        characterController.height = standingHeight;
        playerModel.localScale = new Vector3(1, 1, 1); // Reset the scale to the original size
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
    private void idle()
    {

    }
}