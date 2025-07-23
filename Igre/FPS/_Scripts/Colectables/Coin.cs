using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,45 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            GameManager.Instance.IncreaseScore();
            Destroy(gameObject);
        }
    }
}
