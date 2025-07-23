using System;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float moveSpeedReduction = 3;
    
    private void OnTriggerEnter(Collider other)
    {
        PlayerCheckOnEnter(other);
        EnemyCheckOnEnter(other);
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerCheckOnExit(other);
        EnemyCheckOnExit(other);
    }

    private void EnemyCheckOnExit(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth  enemyHealth))
        {
            enemyHealth.FireDamage(false);
        }

        if (other.TryGetComponent(out EnemyMovement enemyMovement))
        {
            enemyMovement.movementSpeed *= moveSpeedReduction;
        }
    }

    private void EnemyCheckOnEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyMovement enemyMovement))
        {
            enemyMovement.movementSpeed /= moveSpeedReduction;
        }

        if (other.TryGetComponent(out EnemyHealth  enemyHealth))
        {
            enemyHealth.FireDamage(true);
        }
    }

    private void PlayerCheckOnEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.FireDamage(true);
        }

        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.speed /= moveSpeedReduction;
        }
    }

    private void PlayerCheckOnExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.FireDamage(false);
        }

        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.speed *= moveSpeedReduction;
        }
    }
}
