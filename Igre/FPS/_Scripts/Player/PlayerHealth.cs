using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private Image healthBar;
   [SerializeField] private float maxHealth;
   
   private float currentHealth;

   private void Start()
   {
      currentHealth = maxHealth;
      healthBar.fillAmount = currentHealth / maxHealth;
   }
   
   public void TakeDamage(float damage)
   {
      currentHealth -= damage;
      healthBar.fillAmount = currentHealth / maxHealth;
      if (currentHealth <= 0)
      {
         Debug.Log("Player Dead");
      }
   }
}
