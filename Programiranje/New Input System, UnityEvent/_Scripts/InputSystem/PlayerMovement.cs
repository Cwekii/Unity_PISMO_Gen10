using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;

    private Vector2 moveInput;
    [SerializeField] private float moveSpeed = 10f;

    private Vector2 lookInput;

    private bool isTrigger;
    int counter = 0;

    private bool isCrounching;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isTrigger = true;
        }

        if (context.canceled)
        {
            isTrigger = false;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isCrounching = true;
        }

        if (context.canceled)
        {
            isCrounching = false;
        }
        
        Crouch();
    }

    private void Move()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;

        // Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y);
        rigidbody.linearVelocity = moveDirection * moveSpeed;
    }

    private void Look()
    {
        transform.Rotate(Vector3.up, lookInput.x);
    }

    private void Attack()
    {


        if (isTrigger)
        {
            counter++;
            Debug.Log($"I attacked {counter} times");
        }
    }

    private void Crouch()
    {
        if (isCrounching)
        {
            moveSpeed = 5.5f;
            transform.localScale = new Vector3(1, 0.5f, 1);
            transform.localPosition = new Vector3(transform.localPosition.x, 0.5f, transform.localPosition.z);
        }

        if (!isCrounching)
        {
            moveSpeed = 10;
            transform.localScale = Vector3.one;
        }
    }

    private void Update()
    {
        Move();
        Look();
        Attack();
       // Crouch();

    }
}
