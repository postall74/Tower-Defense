using System;
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
    [SerializeField] private float _fireCountdown = 0f;
    [SerializeField] private Transform[] _firePoints;
    [Header("Bullets")]
    [SerializeField] private GameObject _bulletPrefab;
    [Header("Laser")]
    [SerializeField] private bool _isUseLaser = false;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private ParticleSystem _impactEffect;
    [SerializeField] private Light _impactLight;

    private Transform _target;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (_target == null)
        {
            if (_isUseLaser)
            {
                if (_lineRenderer.enabled)
                {
                    _lineRenderer.enabled = false;
                    _impactEffect.Stop();
                    _impactLight.enabled = false; 
                }
            }

            return;
        }

        LookOnTarget();

        if (_isUseLaser)
            Laser();
        else
        {
            if (_fireCountdown <= 0)
            {
                Shoot();
                _fireCountdown = 1f / _fireRate;
            }

            _fireCountdown -= Time.deltaTime;
        }
    }

    private void Laser()
    {
        foreach (Transform firePoint in _firePoints)
        {
            if (!_lineRenderer.enabled)
            {
                _lineRenderer.enabled = true;
                _impactEffect.Play();
                _impactLight.enabled = true;
            }

            _lineRenderer.SetPosition(0, firePoint.position);
            _lineRenderer.SetPosition(1, _target.position);

            Vector3 direction = firePoint.position - _target.position;
            _impactEffect.transform.position = _target.position + direction.normalized;
            _impactEffect.transform.rotation = Quaternion.LookRotation(direction);

        }
    }

    private void LookOnTarget()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {
        foreach (Transform firePoint in _firePoints)
        {
            GameObject bulletGameObject = (GameObject)Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);  
            Bullet bullet = bulletGameObject.GetComponent<Bullet>();

            if (bullet != null)
                bullet.Seek(_target);
        }
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
