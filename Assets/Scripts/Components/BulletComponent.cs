using UnityEngine;

public class BulletComponent : MonoBehaviour
{

    public BulletConfig config;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                if (damageable.CanDamage)
                {
                    damageable.Damage(config.BulletDamage);
                    Destroy(gameObject);
                }
            }
        }
    }
}
