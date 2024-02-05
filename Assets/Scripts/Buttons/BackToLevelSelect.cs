using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLevelSelect : MonoBehaviour
{
    public void BackToLevelSelectVoid()
    {
        SceneManager.LoadScene(0);
    }
}
