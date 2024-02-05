using UnityEngine;
using UnityEngine.Events;

public class InGameButton : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToDestroy;
    [SerializeField] private GameObject[] _objectsToSetActive;
    private UnityEvent _onPressedEvent = new UnityEvent();

    private AudioSource _attachedAudioSource;

    private void Start()
    {
        _attachedAudioSource = GetComponent<AudioSource>();
        _onPressedEvent.AddListener(DestroyObjects);
        _onPressedEvent.AddListener(ShowObjects);
    }

    private void DestroyObjects()
    {
        foreach (GameObject go in _objectsToDestroy)
        {
            Destroy(go);
        }
    }

    private void ShowObjects()
    {
        foreach (GameObject go in _objectsToSetActive)
        {
            go.SetActive(true);
        }
    }

    public void LaunchEvent()
    {
        _attachedAudioSource.Play();
        _onPressedEvent.Invoke();
    }
}
