using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int scoreAmount;
    [SerializeField] private bool isBad;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.IncreaseScore(scoreAmount);
            if (isBad)
            {
                playerMovement.ReduceLive();
            }
        }

        Destroy(gameObject);
    }
}
