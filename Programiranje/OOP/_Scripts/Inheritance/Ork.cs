
using System;
using UnityEngine;

public class Ork : Enemy
{
    private void Start()
    {
        base.SetMaxHealth();
    }

    protected override void Die()
    {
        //Animation code
        //Sound Code
        // particle effect code
        
        base.Die(); // Poziva metodu iz parent klase
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
        Debug.Log($"Enemy current health {currentHealth}");
    }

    protected override void Move()
    {
        
    }
    
    
    
    
}
