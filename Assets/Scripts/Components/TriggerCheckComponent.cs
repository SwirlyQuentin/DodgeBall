using UnityEngine;
using UnityEngine.Events;

public class TriggerCheckComponent : MonoBehaviour
{
    public UnityEvent<Collider2D> EnterEvent;
    public UnityEvent<Collider2D> ExitEvent;


    void OnTriggerEnter2D(Collider2D collision)
    {
        EnterEvent.Invoke(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ExitEvent.Invoke(collision);
    }
}
