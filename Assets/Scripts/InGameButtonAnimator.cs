using UnityEngine;

public class InGameButtonAnimator : MonoBehaviour
{
    [SerializeField] private Animator _buttonAnimator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _buttonAnimator.SetBool("IsPressed", true);
        }
    }
}
