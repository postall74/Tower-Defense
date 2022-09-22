using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    const string MainMenu = "MainMenu";

    [SerializeField] private SceneFader _sceneFader;

    public void OnRetry()
    {
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void OnMenu()
    {
        _sceneFader.FadeTo(MainMenu);
    }

}
