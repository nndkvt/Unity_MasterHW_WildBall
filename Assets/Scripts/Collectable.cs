using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPlayerCollisionEvent;

    private bool _isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isCollected = true;
            _onPlayerCollisionEvent.Invoke();
        }
    }

    public bool CheckCollected()
    {
        return _isCollected;
    }
}
