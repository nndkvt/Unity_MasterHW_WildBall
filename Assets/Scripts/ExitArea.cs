using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitArea : MonoBehaviour
{
    [SerializeField] private Collectable[] _collectables;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

            if (currentBuildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(currentBuildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void CheckIfCollected()
    {
        if (AreAllCollectablesCollected())
        {
            gameObject.SetActive(true);
        }
    }

    private bool AreAllCollectablesCollected()
    {
        bool areAllCollected = true;

        foreach (Collectable c in _collectables)
        {
            areAllCollected &= c.CheckCollected();
        }

        return areAllCollected;
    }
}
