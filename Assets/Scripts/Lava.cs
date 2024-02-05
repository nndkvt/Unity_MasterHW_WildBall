using UnityEngine;
using UnityEngine.Events;

public class Lava : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPlayerCollisionEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onPlayerCollisionEvent.Invoke();
        }
    }
}
