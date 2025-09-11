using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D pivot;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float respawnDelay;
    
    [SerializeField] private Rigidbody2D currentBallRigidBody;
    [SerializeField] private SpringJoint2D currentBallSpringJoint2D;
    [SerializeField] private float detachDelay = 0.2f;
    
    private bool isDragging;

    private void Start()
    {
        SpawnBall();
    }

    private void Update()
    {
        if (currentBallRigidBody == null)
        {
            return;
        }
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isDragging)
            {
                LaunchBall();
            }
            isDragging = false;
            return;
        }
        isDragging = true;
        currentBallRigidBody.bodyType = RigidbodyType2D.Kinematic;

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        
        currentBallRigidBody.position = worldPosition;

    }

    private void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, pivot.position, Quaternion.identity);
        
        currentBallRigidBody = ball.GetComponent<Rigidbody2D>();
        currentBallSpringJoint2D = ball.GetComponent<SpringJoint2D>();
        
        currentBallSpringJoint2D.connectedBody = pivot;
    }

    private void LaunchBall()
    {
        currentBallRigidBody.bodyType = RigidbodyType2D.Dynamic;
        currentBallRigidBody = null;

        Invoke(nameof(DetachBall), detachDelay);
    }

    private void DetachBall()
    {
        currentBallSpringJoint2D.enabled = false;
        currentBallSpringJoint2D = null;
        Invoke(nameof(SpawnBall),  respawnDelay);
    }
}
