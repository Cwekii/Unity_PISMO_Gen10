using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = Vector3.zero;
        
        if (Input.GetKey(KeyCode.A))
        {
           Move(-transform.right);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.right);
        }
        
        if (Input.GetKey(KeyCode.W) )
        {
            Move(transform.forward);
        } 
        
        if (Input.GetKey(KeyCode.S) )
        {
            Move(-transform.forward);
        }
    }

    private void Move(Vector3 direction)
    {
        direction.Normalize();
        Vector3 targetVelocity = direction * speed;
        playerRigidbody.linearVelocity =
            Vector3.Lerp(playerRigidbody.linearVelocity, targetVelocity, 10 * Time.deltaTime);
    }
    
}
