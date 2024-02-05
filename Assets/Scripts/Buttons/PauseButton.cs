using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
