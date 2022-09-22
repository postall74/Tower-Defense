using UnityEngine;
using UnityEngine.Device;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private GameObject _completeLevelUI;

    private static bool _isGameOver;

    public static bool IsGameOver => _isGameOver;

    public void WinLevel()
    {
        _isGameOver = true;
        _completeLevelUI.SetActive(true);
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
