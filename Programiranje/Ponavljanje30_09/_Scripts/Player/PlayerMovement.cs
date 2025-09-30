using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private string[] inputMaps;
    private int mapIndex = 0;
    
    [SerializeField] private UnityEvent<float> onHealthChanged = new UnityEvent<float>();
    [SerializeField] private UnityEvent onDeath = new UnityEvent();

    [SerializeField] private TMP_Text healthText;
    
    
    private float currentHealth;
    [SerializeField] private float maxHealth = 100;
    
    [SerializeField] private MovementData movementData;
    [SerializeField] private Transform hands;
    
    
    private Rigidbody rigidbody;
    private Rigidbody pickupRigidbody;

    private Vector2 moveInput;
    //[SerializeField] private float moveSpeed = 10f;

    private Vector2 lookInput;

    private bool isTrigger;
    int counter = 0;

    private bool isCrounching;
    private bool isGrabbing;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentHealth = maxHealth;
        
    }

    public void OnMapChange(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mapIndex++;
            if (mapIndex >= inputMaps.Length) mapIndex = 0;
            playerInput.SwitchCurrentActionMap(inputMaps[mapIndex]);
            Debug.Log($"Current map: {inputMaps[mapIndex]}");
           
        }
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

    public void OnInteract(InputAction.CallbackContext context)
    {
        //Do something
        if (context.started)
        {
            isGrabbing = true;

        }
        if (context.canceled) isGrabbing = false;

        Interact();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Jump();

        }
    }

    public void OnDamage(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            onHealthChanged.Invoke(4);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthText.text = $"Health: {currentHealth}/{maxHealth}";
        if (currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }
    
    private void Move()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;

        Vector3 finalVelocity = moveDirection * movementData.moveSpeed;
        finalVelocity.y = rigidbody.linearVelocity.y;
        rigidbody.linearVelocity = finalVelocity;
        // Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y);
       // rigidbody.linearVelocity = moveDirection * movementData.moveSpeed;
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
            movementData.moveSpeed = 5.5f;
            transform.localScale = new Vector3(1, 0.5f, 1);
            transform.localPosition = new Vector3(transform.localPosition.x, 0.5f, transform.localPosition.z);
        }

        if (!isCrounching)
        {
            movementData.moveSpeed = 10;
            transform.localScale = Vector3.one;
        }
    }

    private void Jump()
    {
        if (rigidbody.linearVelocity.y != 0) return;
        rigidbody.AddForce(Vector3.up * movementData.jumpForce, ForceMode.Impulse);
    }

    private void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 500))
        {
            if (hit.transform.TryGetComponent(out Rigidbody pickupRigidbody))
            {
                this.pickupRigidbody = pickupRigidbody;

                if (isGrabbing)
                {
                    pickupRigidbody.isKinematic = true;
                    pickupRigidbody.transform.parent = hands;
                    pickupRigidbody.transform.localPosition = Vector3.zero;
                    pickupRigidbody.gameObject.GetComponent<Collider>().enabled = false;

                }


            }
        }

        if (!isGrabbing)
        {
            pickupRigidbody.isKinematic = false;
            pickupRigidbody.gameObject.GetComponent<Collider>().enabled = true;
            pickupRigidbody.transform.parent = null;
        }

        Debug.DrawRay(transform.position, transform.forward, Color.red, 200);


    }

    private void Update()
    {
        Move();
        Look();
        Attack();
       // Crouch();

    }
}
