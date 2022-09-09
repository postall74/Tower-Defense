using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private float _health = 100f;
    [SerializeField] private int _worth = 2;
    [SerializeField] private GameObject _deathEffect;
    
    private float _curretSpeed;

    public float CurrentSpeed => _curretSpeed;
    public float Health => _health;
    public int Worth => _worth;

    private void Start()
    {
        _curretSpeed = _startSpeed;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health < 0)
            Die();
    }

    public void Slow(float value)
    {
        _curretSpeed = _startSpeed * (1f - value);
    }

    public void ResetSpeed()
    {
        _curretSpeed = _startSpeed;
    }

    private void Die()
    {
        Payment(_worth);
        GameObject deathEffect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);
        Destroy(gameObject);
    }

    private void Payment(int value)
    {
        PlayerStats.Money += value;
    }
}
