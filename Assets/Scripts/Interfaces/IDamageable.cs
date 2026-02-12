using UnityEngine;

public interface IDamageable
{
    void Damage(float damageAmount);
    void Kill();
    void Die();

    float MaxHealth {get; set;}
    float CurrentHealth {get; set;}

    bool CanDamage {get; set;}
}
