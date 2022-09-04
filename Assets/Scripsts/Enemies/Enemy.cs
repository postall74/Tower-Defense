using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Transform _targer;
    private int _wavePointIndex = 0;

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
            Destroy(gameObject);
            return;
        }

        _wavePointIndex++;
        _targer = Waypoints.points[_wavePointIndex];
    }
}
