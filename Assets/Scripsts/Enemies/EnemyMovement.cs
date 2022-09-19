using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _targer;
    private int _wavePointIndex = 0;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _targer = Waypoints.Points[0];
    }

    private void Update()
    {
        Vector3 direction = _targer.position - transform.position;
        transform.Translate(_enemy.CurrentSpeed * Time.deltaTime * direction.normalized, Space.World);

        if (Vector3.Distance(transform.position, _targer.position) <= 0.4f)
        {
            GetNextWayPoint();
        }

        _enemy.ResetSpeed();
    }

    private void GetNextWayPoint()
    {
        if (_wavePointIndex >= Waypoints.Points.Length - 1)
        {
            EndPath();
            return;
        }

        _wavePointIndex++;
        _targer = Waypoints.Points[_wavePointIndex];
    }

    private void EndPath()
    {
        PlayerStats.ChangeLives(-1);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
