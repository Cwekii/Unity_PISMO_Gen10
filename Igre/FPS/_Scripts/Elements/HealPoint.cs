using System;
using TMPro;
using UnityEngine;

public class HealPoint : MonoBehaviour
{
    [SerializeField] private TMP_Text healAmountText;
    [SerializeField] private float maxHealAmount = 20f;
    [SerializeField] private float healAmount;

    PlayerHealth playerHealth; // filling this reference in OnTrigger methods
    private bool isHealing = false;
    private float healingTimer = 0;

    private void Start()
    {
        healAmount =  maxHealAmount;
        healAmountText.text = ToString();
    }

    public override string ToString()
    {
        return $"Heal Amount: {healAmount}";
    }

    private void Update()
    {
        healingTimer += Time.deltaTime;
        
        RefillingHealingAmount();
        
        // checking if player health class is empty
        if (playerHealth == null)
        {
            return;
        }
        
        HealingPlayer();

    }

    private void HealingPlayer()
    {
        if (isHealing && healingTimer >= 1 && healAmount > 0)
        {
            healingTimer = 0;
            healAmount--;
            playerHealth.StartHealing(1);
            healAmountText.text = ToString();
        }
    }

    private void RefillingHealingAmount()
    {
        if (!isHealing && healAmount < maxHealAmount && healingTimer >= 1)
        {
            healingTimer = 0;
            healAmount++;
            healAmountText.text = ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
                healingTimer = 0;
                isHealing = true;
                this.playerHealth = playerHealth;
        }

        if (other.TryGetComponent(out EnemyMovement enemyMovement))
        {
            enemyMovement.movementSpeed = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            
                isHealing = false;
                this.playerHealth = null;
        }
        if (other.TryGetComponent(out EnemyMovement enemyMovement))
        {
            enemyMovement.movementSpeed = 10;
        }
    }
}
