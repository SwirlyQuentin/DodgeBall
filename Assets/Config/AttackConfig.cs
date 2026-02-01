using UnityEngine;

[CreateAssetMenu(fileName = "AttackConfig", menuName = "Config/AttackConfig")]
public class AttackConfig : ScriptableObject
{
    public float BulletForce;
    public float BulletTime;
    public float AttackCooldown;
    public GameObject Bullet;
    public bool CanHaveTarget;
    public float RotationSpeed;


}
