using UnityEngine;

public class NoNoSquare : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                Debug.Log("KILLING");
                damageable.Kill();
            }
        }
    }
}
