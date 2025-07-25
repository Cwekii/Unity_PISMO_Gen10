using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // objekt sa ovom skriptom ce stvoriti ovu komponentu i ona mora biti na tom objektu
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    [SerializeField] private float damage = 20f;
    
    
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<SphereCollider>().isTrigger = true;
    }

    private void Start()
    {
        rigidbody.linearVelocity = speed * transform.forward;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damage);
        } 
        
        if (other.TryGetComponent(out Explosion explosion))
        {
            explosion.BarrelHealth(damage);
        }
        
        Destroy(gameObject);
    }
}
