using UnityEngine;

public class AttackComponent : MonoBehaviour
{

    public AttackConfig config;
    public FirePoint[] firePoints;

    [System.Serializable]
    public class FirePoint
    {
        public Transform position;
        public Transform target;

    }


    void Fire()
    {
        
    }



}
