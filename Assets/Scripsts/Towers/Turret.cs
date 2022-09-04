using UnityEngine;

public class Turret : MonoBehaviour
{
    private const string EnemyTag = "Enemy";

    [Header("System watching to Enemy")]
    [SerializeField] private float _range = 15f;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private float _turnSpeed = 10f;
    [Header("Fire system")]
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _firCountdown = 0f;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;

    private Transform _target;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (_target == null)
            return;

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (_firCountdown <=0)
        {
            Shoot();
            _firCountdown = 1f / _fireRate;
        }

        _firCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(_target);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
            _target = nearestEnemy.transform;
        else
            _target = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
