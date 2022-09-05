using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _isGameEnd = false;

    private void Update()
    {
        if (_isGameEnd)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _isGameEnd = true;
        Debug.Log("Game over");
    }
}
