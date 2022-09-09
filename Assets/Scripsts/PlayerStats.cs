using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _startMoney = 500;
    [SerializeField] private int _startLive = 3;

    private static int _rounds;
    private static int _money;
    private static int _lives;

    public static int Momey => _money;
    public static int Lives => _lives;
    public static int Rounds => _rounds;    

    public static int AddRound()
    {
        return _rounds++;
    }

    public static void ChangeMoney(int value)
    {
        _money += value;
    }

    public static void ChangeLives(int value)
    {
        _lives -= value;
    }

    private void Start()
    {
        _lives = _startLive;
        _money = _startMoney;
        _rounds = 0;
    }
}
