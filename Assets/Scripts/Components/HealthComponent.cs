using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageable
{

    public Health config;

    public float MaxHealth { get ; set ; }
    public float CurrentHealth { get ; set ; }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Dead");
    }

    void Awake()
    {
        MaxHealth = config.maxHealth;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
