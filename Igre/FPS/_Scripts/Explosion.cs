using System;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float health = 30;
    [SerializeField] private SpringJoint springJoint;
    
    
    public float radius = 5.0F;
    public float power = 10.0F;


    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Explode();
        }
    }

    public void BarrelHealth(float damage)
    {
        health -= damage;
       
        if (health <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (hit.gameObject.name != "Terrain" && hit.GetComponent<SpringJoint>().connectedBody != null)
            {
             hit.AddComponent<SpringJoint>().connectedBody = GetComponent<Rigidbody>();
                //hit.GetComponent<SpringJoint>().connectedBody = GetComponent<Rigidbody>();
                
            }
            

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 6.0F);
        }
    }
}
