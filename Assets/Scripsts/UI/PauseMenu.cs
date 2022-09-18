using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private string _menuSceneName = "MainMenu";

    public void OnContinue()
    {
        Toggle();
    }

    public void OnRetry()
    {
        Toggle();
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void OnMenu()
    {
        Toggle();
        _sceneFader.FadeTo(_menuSceneName);
    }

    public void Toggle()
    {
        _ui.SetActive(!_ui.activeSelf);

        if (_ui.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            Toggle();
    }
}
