using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private int scoreAmount;
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.IncreaseScore(scoreAmount);
        }
            Destroy(gameObject);
    }
}
