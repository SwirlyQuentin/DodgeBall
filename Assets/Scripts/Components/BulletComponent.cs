using UnityEngine;

public class BulletComponent : MonoBehaviour
{

    public BulletConfig config;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.Damage(config.BulletDamage);
            Destroy(gameObject);
        }
    }
}
