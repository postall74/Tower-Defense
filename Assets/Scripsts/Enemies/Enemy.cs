using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _health = 100;
    [SerializeField] private int _moneyGain = 2;
    [SerializeField] private GameObject _deathEffect;

    private Transform _targer;
    private int _wavePointIndex = 0;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
            Die();
    }

    private void Start()
    {
        _targer = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = _targer.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * _speed, Space.World);

        if (Vector3.Distance(transform.position, _targer.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (_wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        _wavePointIndex++;
        _targer = Waypoints.points[_wavePointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    private void Die()
    {
        Payment(_moneyGain);
        GameObject deathEffect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);
        Destroy(gameObject);
    }

    private void Payment(int value)
    {
        PlayerStats.Money += value;
    }
}
