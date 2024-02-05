using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _attachedParticleSystem;

    public void PlayParticleSystem()
    {
        transform.DetachChildren();
        _attachedParticleSystem.Play();
        gameObject.SetActive(false);
    }
}
