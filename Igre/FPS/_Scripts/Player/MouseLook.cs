using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity = 100;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private float rotationX = 0f;
    private void Update()
    {
      float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
      float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

      rotationX -= mouseY; // inverted
     rotationX = Mathf.Clamp(rotationX, -90, 90); // min and max rotation
     transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
      playerBody.Rotate(Vector3.up * mouseX);
    }
}
