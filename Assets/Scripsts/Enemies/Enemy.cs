using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 10f;
    [SerializeField] private float _startHealth = 100f;
    [SerializeField] private int _worth = 2;
    [SerializeField] private GameObject _deathEffect;
    [SerializeField] private Image _healthBar;
    
    private float _curretSpeed;
    private float _health;
    private bool _isDead = false;

    public float CurrentSpeed => _curretSpeed;
    public float Health => _health;
    public int Worth => _worth;

    private void Start()
    {
        _curretSpeed = _startSpeed;
        _health = _startHealth;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        _healthBar.fillAmount = NormalizeHealt(_health);

        if (_health < 0 && !_isDead)
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

    private float NormalizeHealt(float value)
    {
        return value / _startHealth;
    }

    private void Die()
    {
        _isDead = true;
        Payment(_worth);
        GameObject deathEffect = (GameObject)Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    private void Payment(int value)
    {
        PlayerStats.ChangeMoney(value);
    }
}
