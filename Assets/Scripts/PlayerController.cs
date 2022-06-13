using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerController : MonoBehaviour
{
    //Character Controller
    public CharacterController characterController;
    public float speed;
    public float jumpSpeed;
    private float gravSpeed;
    private float originalStepOffset;
    private Vector3 moveInput;

    //Camera
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;

    public static bool lockUser;

    public PauseManager pm;
    public EnableArrows ea;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        lockUser = false;
    }
    void Update()
    {
        if (lockUser == false)
        {
            Rotate();
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void FixedUpdate()
    {
        if (lockUser == false)
        {
            updatedMove();
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalMove + transform.right * horizontalMove;
        float magnitude = Mathf.Clamp01(move.magnitude) * speed;
        move.Normalize();

        gravSpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 velocity = move * magnitude;
        velocity.y = gravSpeed;

        characterController.Move(velocity * Time.deltaTime);

    }

    private void updatedMove()
    {
        Vector3 move = transform.forward * moveInput.y + transform.right * moveInput.x;
        float magnitude = Mathf.Clamp01(move.magnitude) * speed;
        move.Normalize();

        gravSpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 velocity = move * magnitude;
        velocity.y = gravSpeed;

        characterController.Move(velocity * Time.deltaTime);
    }


    public void OnJump()
    {
        if (characterController.isGrounded)
        {
            print("grounded");
            characterController.stepOffset = originalStepOffset;

            gravSpeed = jumpSpeed;

        }
        else
        {
            print("not grounded");
            characterController.stepOffset = 0;
        }
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveInput = inputVec;
    }

    public void OnPause()
    {
        pm.PauseGame();
    }

    public void OnEnableArrow()
    {
        try
        {
            print("Enable Arrow");
            ea.activateArrow();
        }
         catch (NullReferenceException ex)
        {
            Debug.Log("arrow was not set in the inspector");
        }
    }


    public void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);

    }
}
