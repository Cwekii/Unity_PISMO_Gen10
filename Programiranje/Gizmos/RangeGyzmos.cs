using System;
using UnityEngine;

public class RangeGyzmos : MonoBehaviour
{
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private Color gyzmoColor = Color.white;

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gyzmoColor;
        
        Gizmos.DrawWireSphere(sphereCollider.transform.position, sphereCollider.radius);
    }
}
