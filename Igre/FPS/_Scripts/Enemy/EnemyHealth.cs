using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float maxHealth = 100;
    private float currentHealth;
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
            TakeDamage(5);
            damageTimer = 0;
            
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            GameManager.Instance.IncreaseScore();
            Destroy(gameObject);
        }
    }
    public void FireDamage(bool inFire)
    {
        isInFire = inFire;
        damageTimer = 0;
    }

}
