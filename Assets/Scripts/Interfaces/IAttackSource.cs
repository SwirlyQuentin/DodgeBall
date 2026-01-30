using UnityEngine;

public interface IAttackSource
{
    void StartAttack();
    void StopAttack();
    void SetTarget(Transform target);
    bool IsAttacking {get; set;}
}
