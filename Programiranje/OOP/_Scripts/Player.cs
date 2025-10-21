using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour, ISaveSystem
{
    [SerializeField] private Health healthClass;
    
    public int health => healthClass.CurrentHealth;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //HEAL
            healthClass.Heal(2);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //DAMAGE
            healthClass.TakeDamage(6);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact();
        }
    }


    public void Save()
    {
        PlayerPrefs.SetInt("Health", health);
    }

   
}
