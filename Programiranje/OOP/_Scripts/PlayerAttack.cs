using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            //enemy.Damage(10);
           // UnityEngine.Debug.Log($"Enemy {other.gameObject.name} Detected ");
        }

        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(10); 
            UnityEngine.Debug.Log($"Enemy {other.gameObject.name} Detected ");
        }
    }
}
