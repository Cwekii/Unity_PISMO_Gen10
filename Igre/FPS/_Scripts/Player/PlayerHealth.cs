using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] private Image healthBar;
   [SerializeField] private float maxHealth;
   
   [SerializeField] private float currentHealth;
   private bool isInFire;
   private float damageTimer;
  

   private void Start()
   {
      currentHealth = maxHealth;
      healthBar.fillAmount = currentHealth / maxHealth;
   }

   private void Update()
   {
      damageTimer += Time.deltaTime;
      
      if (isInFire && damageTimer >= 1f)
      {
         TakeDamage(1);
         damageTimer = 0;
      }
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

   public void StartHealing(float healAmount)
   {
      if (currentHealth > maxHealth)
      {
         currentHealth = maxHealth;
         return;
      }
      currentHealth += healAmount;
      healthBar.fillAmount = currentHealth / maxHealth;
   }

   public void FireDamage(bool inFire)
   {
      isInFire = inFire;
      damageTimer = 0;
   }
}
