using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTarget;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private float damage = 20f;
    
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            playerTarget.position,
            movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
