using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public Transform target;
   [SerializeField] private float speed = 50f;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody=GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
     transform.position = Vector3.MoveTowards(
         transform.position, target.position,
         speed * Time.deltaTime);
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent( out Player player))
        {
            player.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}