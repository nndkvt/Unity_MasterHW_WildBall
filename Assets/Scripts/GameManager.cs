using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Continue();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }
}
