using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    [SerializeField] private int _startMoney = 500;
    [SerializeField] private int _startLive = 20;

    private void Start()
    {
        Lives = _startLive;
        Money = _startMoney;
    }
}
