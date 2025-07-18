using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private Image healtImage;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private float currentHealth;
        [SerializeField] private float maxHealth = 100;

        private void Start()
        {
                gameOverPanel.SetActive(false);
                currentHealth = maxHealth;
                healtImage.fillAmount = currentHealth / maxHealth;
                healthText.text = $"{currentHealth / maxHealth * 100}%";
        }

        public void TakeDamage(float damage)
        {
                
                currentHealth -= damage;
                if (currentHealth <= 0)
                {
                        currentHealth = 0;
                        gameOverPanel.SetActive(true);
                }
                if (currentHealth <= maxHealth / 2)
                {
                        healthText.color = Color.white;
                }
                healthText.text = $"{currentHealth / maxHealth * 100}%";
                healtImage.fillAmount = currentHealth / maxHealth;
        }
}