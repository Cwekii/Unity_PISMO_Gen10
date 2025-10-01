using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.Gyroscope;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float rotateSpeed;
    

    private Rigidbody playerRigidbody;
    private Camera camera;

    Vector3 moveDirection;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        Input();
        KeepPlayerOnScreen();
        RotateToFaceVelocity();
    }

    private void Input()
    {
        if (Touchscreen.current == null || !Touchscreen.current.primaryTouch.press.isPressed)
        {
            moveDirection = Vector3.zero;
            playerRigidbody.linearVelocity = Vector3.Lerp(playerRigidbody.linearVelocity, Vector3.zero, Time.deltaTime);
        }

        else
        {

            Vector3 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            float zDistance = Mathf.Abs(camera.transform.position.z - transform.position.z);
            touchPosition.z = zDistance;
            Vector3 worldPosition = camera.ScreenToWorldPoint(touchPosition);


            moveDirection = (transform.position - worldPosition);
            moveDirection.z = 0;
            moveDirection.Normalize();
        }
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewPosition = camera.WorldToViewportPoint(transform.position);

        if (viewPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if (viewPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }


        transform.position = newPosition;
    }

    private void RotateToFaceVelocity()
    {
        if (playerRigidbody.linearVelocity == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation =
            Quaternion.LookRotation(playerRigidbody.linearVelocity, Vector3.back);
        targetRotation.x = 0;
        targetRotation.y = 0;

     transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
     
     
    }

    private void FixedUpdate()
    {
        if (moveDirection == Vector3.zero)
        {
            return;
        }
        
        playerRigidbody.AddForce(moveDirection * (forceMagnitude * Time.deltaTime), ForceMode.Force);
        Vector3.ClampMagnitude(playerRigidbody.linearVelocity, maxVelocity);
    }
}
