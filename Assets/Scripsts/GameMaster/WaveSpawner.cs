using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private Text _waveCountdownText;

    private float _countdown = 2f;
    private int _waveIndex = 0; 

    private void Update()
    {
        if (_countdown <= 0)
        {
            StartCoroutine(SpawnWaves());
            _countdown = _timeBetweenWaves;
        }

        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0 , Mathf.Infinity);

        _waveCountdownText.text = string.Format("{0:00.00}", _countdown);
    }

    private IEnumerator SpawnWaves()
    {
        _waveIndex++;
        PlayerStats.AddRound();

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
