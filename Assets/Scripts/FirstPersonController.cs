using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 5.0f;              // Movement speed
    public float mouseSensitivity = 2.0f;   // Mouse sensitivity
    public float jumpSpeed = 10.0f;         // Jump height
    public float gravity = 20.0f;           // Gravity strength

    private CharacterController characterController;   // Reference to CharacterController component
    private Camera playerCamera;                        // Reference to Camera component
    private float verticalVelocity = 0.0f;              // Vertical velocity for jumping and falling
    private float xRotation = 0.0f;                     // Rotation around x-axis

    void Start()
    {
        // Get references to components
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        // Hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        // Movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.TransformDirection(new Vector3(moveX, 0, moveZ)) * speed;

        // Jump
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpSpeed;
            }
        }

        // Apply gravity
        verticalVelocity -= gravity * Time.deltaTime;
        moveDirection.y = verticalVelocity;

        // Move the character
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
