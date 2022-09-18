using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _roundText;
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private string _menuSceneName = "MainMenu";

    public void OnRetry()
    {
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void OnMenu()
    {
        _sceneFader.FadeTo(_menuSceneName);
    }

    private void OnEnable()
    {
        _roundText.text = PlayerStats.Rounds.ToString();
    }
}
