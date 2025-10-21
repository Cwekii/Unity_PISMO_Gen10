using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;

    [SerializeField] protected string[] names;

    private bool isDead;
    
    public virtual void SetMaxHealth()
    {
        currentHealth = maxHealth;
        Debug.Log($"Current Health: {currentHealth}");
    }

    public virtual void Damage(float damage)
    {
        if (isDead) return;
        if (currentHealth <= 0)
        {
            Die();
        }
        currentHealth -= damage;
        // send data (currentHealth) via event
        
    }

    protected virtual void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    protected virtual void Move()
    {
        
    }
}
