using System;
using UnityEngine;

public class VisualGyzmos : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Color gizmoColor = Color.white;
    
    

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        for (int i = 0; i < patrolPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i + 1].position);

        }

        Gizmos.DrawLine(patrolPoints[patrolPoints.Length - 1].position, patrolPoints[0].position);
    }
}


