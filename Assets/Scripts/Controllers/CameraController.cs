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
        // ������ ������ ������
        float tempCoord = -_offset.x;
        _offset.x = _offset.z;
        _offset.z = tempCoord;

        // ������ ��������� ������
        //
        // ���� ����� �� ������� ��������� ������
        // (4 ����������� = 4 ���������), ������ ��������� �� ���������
        _cameraState++;
        if (_cameraState >= 4)
        {
            _cameraState = 0;
        }
    }
    private void ChangeFollowCounterclockwise()
    {
        // ������ ������ ������
        float tempCoord = _offset.x;
        _offset.x = -_offset.z;
        _offset.z = tempCoord;

        // ������ ��������� ������
        //
        // ���� ����� �� ������� ��������� ������
        // (4 ����������� = 4 ���������), ������ ��������� �� ��������
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
