using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const string EnemyTag = "Enemy";

    [SerializeField] private float _speed = 70f;
    [SerializeField] private float _explosionRadius = 0f;
    [SerializeField] private GameObject _impactEffect;  

    private Transform _target;

    public void Seek(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }    

        Vector3 directon = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (directon.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return; 
        }

        transform.Translate(directon.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    private void HitTarget()
    {
        GameObject effectInstance = Instantiate(_impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        if (_explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(_target);
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
         Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == EnemyTag)
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
