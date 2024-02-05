using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private int _cameraState;

    private void Start()
    {
        _cameraState = 0;
    }

    private void Update()
    {
        if (_player != null)
        {
            transform.position = _player.position + _offset;
            transform.LookAt(_player);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeFollowClockwise();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeFollowCounterclockwise();
        }
    }

    private void ChangeFollowClockwise()
    {
        // Меняем слежку камеры
        float tempCoord = -_offset.x;
        _offset.x = _offset.z;
        _offset.z = tempCoord;

        // Меняем состояние камеры
        //
        // Если вышли за пределы состояний камеры
        // (4 направления = 4 состояния), меняем состояние на начальное
        _cameraState++;
        if (_cameraState >= 4)
        {
            _cameraState = 0;
        }
    }
    private void ChangeFollowCounterclockwise()
    {
        // Меняем слежку камеры
        float tempCoord = _offset.x;
        _offset.x = -_offset.z;
        _offset.z = tempCoord;

        // Меняем состояние камеры
        //
        // Если вышли за пределы состояний камеры
        // (4 направления = 4 состояния), меняем состояние на конечное
        _cameraState--;
        if (_cameraState <= -1)
        {
            _cameraState = 3;
        }
    }

    public int GetCameraState()
    {
        return _cameraState;
    }
}
