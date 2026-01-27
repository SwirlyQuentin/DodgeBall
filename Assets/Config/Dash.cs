using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "Config/Dash")]
public class Dash : ScriptableObject
{
    public float DashCooldown;
    public float DashTime;
    public float DashSpeed;
}
