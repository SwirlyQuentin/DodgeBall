using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class AttackComponent : MonoBehaviour, IAttackSource
{

    public AttackConfig config;
    public FirePoint[] firePoints;

    public bool IsAttacking { get; set; }

    private float attackTimer = 0f;

    [System.Serializable]
    public class FirePoint
    {
        public Transform position;
        public Transform target;

    }


    public void SetTarget(Transform target)
    {
        foreach (FirePoint fp in firePoints)
        {
            fp.target = target;
        }
    }


    private void Fire(FirePoint fp)
    {
        if (fp.target == null)
        {
            return;
        }

        GameObject bulletInstance = Instantiate(config.Bullet, fp.position);
        if (bulletInstance.TryGetComponent(out Rigidbody2D rb))
        {
            Vector2 direction = (fp.target.position - fp.position.position).normalized;
            rb.linearVelocity = direction * config.BulletForce;
        }

        Destroy(bulletInstance, config.BulletTime);
    }

    public void FireAll()
    {
        foreach (FirePoint fp in firePoints)
        {
            Fire(fp);
        }
    }

    public void StartAttack()
    {
        Debug.Log("ATTACKING");
        IsAttacking = true;
    }

    public void StopAttack()
    {
        Debug.Log("STOP ATTACKING");
        IsAttacking = false;
    }


    void Update()
    {
        if (IsAttacking)
        {
            if (attackTimer <= 0)
            {
                FireAll();
                attackTimer = config.AttackCooldown;
            }
            else
            {
                attackTimer -= Time.deltaTime;
            }
        }
    }
}
