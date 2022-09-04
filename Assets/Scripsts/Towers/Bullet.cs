using System;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 70f;
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
    }

    private void HitTarget()
    {
        GameObject effectInstance = Instantiate(_impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }
}
