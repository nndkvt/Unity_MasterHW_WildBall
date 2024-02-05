using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevelButton : MonoBehaviour
{
    [SerializeField] private int _levelNumber;

    [SerializeField] private Text _buttonText;

    private void Start()
    {
        _buttonText.text = $"{_levelNumber}";
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene(_levelNumber);
    }
}
