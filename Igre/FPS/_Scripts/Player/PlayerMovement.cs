using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] public float speed;
    [SerializeField] private Vector3 jumpForce = new Vector3(0,20,0);
    
    
    bool isGrounded;
    Vector3 moveDirection;

    private void Update()
    {
        if (!isGrounded)
        { 
            playerRigidbody.AddForce(-jumpForce);
            return;
        }
        
        moveDirection = Vector3.zero;
        
        if (Input.GetKey(KeyCode.A))
        {
           moveDirection += -transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        
        if (Input.GetKey(KeyCode.W) )
        {
            moveDirection += transform.forward;
        } 
        
        if (Input.GetKey(KeyCode.S) )
        {
            moveDirection += -transform.forward;

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidbody.AddForce(jumpForce, ForceMode.Impulse);
        }

        Move();
    }

    private void Move()
    {
        moveDirection.Normalize();
        playerRigidbody.linearVelocity = new Vector3(
            moveDirection.x * speed,
            playerRigidbody.linearVelocity.y,
            moveDirection.z * speed);
      
        
       /* direction.Normalize();
        Vector3 targetVelocity = direction * speed;
        playerRigidbody.linearVelocity =
            Vector3.Lerp(playerRigidbody.linearVelocity, targetVelocity, 10 * Time.deltaTime);*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out TerrainCollider terrainCollider))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out TerrainCollider terrainCollider))
        {
            isGrounded = false;
        }
    }
}
