using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CameraController _assignedCamera;
    [SerializeField, Range(1, 10)] private float _speed = 5f;
    [SerializeField, Range(1, 10)] private float _jumpForce = 5f;

    private Rigidbody _rigidBody;
    private bool _isPlayerOnTheGround;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = GetMovementDirection(_assignedCamera.GetCameraState());
        MovePlayer(movement);
    }

    private void Update()
    {
        CheckForJump();
    }

    #region Методы перемещения

    private void MovePlayer(Vector3 move)
    {
        _rigidBody.AddForce(move * _speed);
    }

    private void CheckForJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isPlayerOnTheGround)
        {
            _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isPlayerOnTheGround = false;
        }
    }
    
    private Vector3 GetMovementDirection(int cameraState)
    {
        float horizontal = Input.GetAxis(GlobalStringVars.HorizontalAxis);
        float vertical = Input.GetAxis(GlobalStringVars.VerticalAxis);

        Vector3 movement = Vector3.zero;

        switch(cameraState)
        {
            case 0:
                movement = new Vector3(horizontal, 0, vertical);
                break;
            case 1:
                movement = new Vector3(vertical, 0, -horizontal);
                break;
            case 2:
                movement = new Vector3(-horizontal, 0, -vertical);
                break;
            case 3:
                movement = new Vector3(-vertical, 0, horizontal);
                break;
        }

        return movement;
    }
    
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        // Поменял слой на тэг
        if (collision.gameObject.CompareTag("Land"))
        {
            _isPlayerOnTheGround = true;
        }
    }

    [ContextMenu("Reset Values")]
    public void ResetValues()
    {
        _speed = 5f;
        _jumpForce = 5f;
    }
}
