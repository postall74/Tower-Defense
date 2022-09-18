using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private string _levelToLoad = "MainLevel";

    public void OnPlay()
    {
        SceneManager.LoadScene(_levelToLoad);
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
