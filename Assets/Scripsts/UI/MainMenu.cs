using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string _levelToLoad = "MainLevel";
    [SerializeField] private SceneFader _sceneFader;

    public void OnPlay()
    {
        _sceneFader.FadeTo(_levelToLoad);
    }

    public void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnSettings()
    {
        Debug.Log("Settings");
    }
}
