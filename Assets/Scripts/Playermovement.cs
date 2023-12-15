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

    private Vector3 velocity;
    private CharacterController characterController;
    private Transform playerModel; // Reference to the player model's transform
    private bool isCrouching = false;

    private Vector3 moveDirection;
    

    public float gravity = -9.81f;
    public float jumpHeight = 4f;

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

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * moveZ + right * moveX;
        moveDirection = Vector3.Normalize(desiredMoveDirection);

        if (Input.GetKeyDown(KeyCode.C))
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
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
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