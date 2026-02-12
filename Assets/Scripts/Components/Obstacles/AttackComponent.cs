using System;
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
        public Vector3 defaultTarget;

    }


    void Start()
    {
        GetDefaultTargets();
    }


    public void SetTarget(Transform target)
    {
        if (config.CanHaveTarget)
        {
            foreach (FirePoint fp in firePoints)
            {
                fp.target = target;
            }
        }
    }


    private void Fire(FirePoint fp)
    {

        SetDefaultFirePointTarget(fp);
        Vector2 direction;
        GameObject bulletInstance = Instantiate(config.Bullet, fp.position.position, fp.position.rotation);


        if (bulletInstance.TryGetComponent(out Rigidbody2D rb))
        {
            // if (fp.target == null)
            // {
            // direction = (fp.defaultTarget - fp.position.position).normalized;
            // }
            // else{
            //     direction = (fp.target.position - fp.position.position).normalized;
            // }

            direction = (fp.defaultTarget - fp.position.position).normalized;
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

        if (IsAttacking && config.CanHaveTarget)
        {
            RotateTowardsTarget();
        }


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

    #region Helper Functions

    private void SetDefaultFirePointTarget(FirePoint fp)
    {
        // Vector3 direction = -transform.up * 1000;
        // fp.defaultTarget = direction + (fp.position.position - transform.position);

        // fp.position.rotation = transform.rotation;
        fp.defaultTarget = fp.position.position + (-fp.position.up * 100f);
    }

    private void GetDefaultTargets(){
        foreach (FirePoint fp in firePoints){
            SetDefaultFirePointTarget(fp);
        }
    }

    private void RotateTowardsTarget()
    {
        if (firePoints.Length > 0 && firePoints[0].target != null)
        {
            Vector2 direction = firePoints[0].target.position - transform.position;
            if (direction != Vector2.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle + 90f);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * config.RotationSpeed);
            }
        }
    }

    #endregion
}
