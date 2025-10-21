using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float durability;


    public abstract void Shoot();
    public abstract void Durability();

}
