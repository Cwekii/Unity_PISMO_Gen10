public class AK47 : Weapon
{
    public override void Shoot()
    {
        durability = 100;
    }

    public override void Durability()
    {
        
    }

    private float CalculateDamage()
    {
        
        damage = 20;
        return damage;
    }
}