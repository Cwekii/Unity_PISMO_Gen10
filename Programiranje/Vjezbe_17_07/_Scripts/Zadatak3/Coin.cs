using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int scoreWorth = 1;
    
    private Vector3 rotationSpeed = new Vector3(90,0,0);
    private Vector3 startPosition;
    
    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(rotationSpeed * Time.deltaTime);
        float hover = startPosition.y +0.5f + Mathf.Sin(Time.time * 1f) * 0.5f;
        transform.position = new Vector3(transform.position.x, hover, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMove playerMove))
        {
            GameControl.Instance.Score += scoreWorth;
            Destroy(gameObject);
            
        }
    }
}
