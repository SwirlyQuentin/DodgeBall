using UnityEngine;

[CreateAssetMenu(fileName = "AttackConfig", menuName = "Config/AttackConfig")]
public class AttackConfig : ScriptableObject
{
    public float BulletForce;
    public float BulletSize;
    public float BulletTime;
    public GameObject Bullet;


}
