using UnityEngine;


public class Health : MonoBehaviour, IDamagable
{
    [SerializeField]  private int currentHealth = 100;
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
            
        }
        set
        {
            currentHealth = value;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            // Sound
            // Particle effect
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public void Heal(int healing)
    {
        CurrentHealth += healing;
    }
}
