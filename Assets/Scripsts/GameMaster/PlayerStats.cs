using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;

    [SerializeField] private int _startMoney = 500;

    private void Start()
    {
        Money = _startMoney;
    }
}
