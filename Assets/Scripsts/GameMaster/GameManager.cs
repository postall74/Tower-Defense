using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverUI;

    private static bool _isGameOver;

    public static bool IsGameOver => _isGameOver;

    private void Start()
    {
        _isGameOver = false;
        Time.timeScale = 1f;
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
        Time.timeScale = 0f;
    }
}
