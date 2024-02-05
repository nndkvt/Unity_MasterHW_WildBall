using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Text _adviceText;
    [SerializeField] private Animator _doorAnimator;

    private bool _isPlayerNear = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerNear)
        {
            bool isOpen = _doorAnimator.GetBool("IsOpen");
            _doorAnimator.SetBool("IsOpen", !isOpen);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _adviceText.text = "Press 'F' to open/close the door";
            _isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _adviceText.text = "";
            _isPlayerNear = false;
        }
    }
}
