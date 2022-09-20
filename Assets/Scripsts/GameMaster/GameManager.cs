using UnityEngine;
using UnityEngine.Device;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private string _nextLevel;
    [SerializeField] private int _levelToUnlock;
    [SerializeField] private SceneFader _sceneFader;

    private static bool _isGameOver;

    public static bool IsGameOver => _isGameOver;

    public void WinLevel()
    {
        Debug.Log("Level WON!");
        PlayerPrefs.SetInt("levelReached", _levelToUnlock);
        _sceneFader.FadeTo(_nextLevel);
    }

    private void Start()
    {
        _isGameOver = false;
    }

    private void Update()
    {
        if (_isGameOver)
            return;

        if (PlayerStats.Lives <= 0)
            EndGame();
    }

    private void EndGame()
    {
        _isGameOver = true;
        _gameOverUI.SetActive(true);
    }
}
