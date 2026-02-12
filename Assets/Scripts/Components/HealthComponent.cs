using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamageable
{

    public UnityEvent onDied;

    public Health config;

    public float MaxHealth { get ; set ; }
    public float CurrentHealth { get ; set ; }
    public bool CanDamage { get; set; }


    public void Damage(float damageAmount)
    {
        if (!CanDamage)
        {
            return;
        }

        CurrentHealth -= damageAmount;
        if (CurrentHealth <= 0)
        {
            Die();
        }

        Debug.Log("Damage taken: " + CurrentHealth);
    }

    public void Die()
    {
        if (onDied != null)
        {
            onDied.Invoke();
        }
    }

    public void Kill()
    {
        if (CanDamage)
        {
            Die();
        }
    }

    void Awake()
    {
        MaxHealth = config.maxHealth;
        CanDamage = true;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetInvulnerable()
    {
        CanDamage = false;
    }

    public void SetVulnerable()
    {
        CanDamage = true;
    }
}
