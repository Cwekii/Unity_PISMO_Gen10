using System;
using UnityEngine;
using UnityEngine.UI;

public class Vjezbe_1 : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private float maxHealth = 130;
    [SerializeField] private float healAmount = 13;
    [SerializeField] private float damageAmount = -21;
    
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthImage.fillAmount = HealthCalculation();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            // DAmage
                HealthChanged(damageAmount);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // heal
                HealthChanged(healAmount);
        }
    }

    private void HealthChanged(float health)
    {
        currentHealth += health;
        healthImage.fillAmount = HealthCalculation();
    }

    private float HealthCalculation()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        float health = currentHealth / maxHealth;
        return health;
    }
}
