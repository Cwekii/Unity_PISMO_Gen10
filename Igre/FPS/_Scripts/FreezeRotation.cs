using UnityEngine;

public class FreezeRotation : MonoBehaviour
{

    [SerializeField] private Transform spherePosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(spherePosition.position.x, spherePosition.position.y + 1, spherePosition.position.z);
    }
}
