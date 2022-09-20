using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private Text _waveCountdownText;
    [SerializeField] private Wave[] _waves;

    private float _countdown = 2.0f;
    private int _waveIndex = 0; 

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (_countdown <= 0)
        {
            StartCoroutine(SpawnWaves());
            _countdown = _timeBetweenWaves;
            return;
        }

        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown, 0 , Mathf.Infinity);

        _waveCountdownText.text = string.Format("{0:00.00}", _countdown);
    }

    private IEnumerator SpawnWaves()
    {
        PlayerStats.AddRound();

        Wave wave = _waves[_waveIndex];

        for (int i = 0; i < wave.Count; i++)
        {
            SpawnEnemy(wave.EnemyPrefab);
            yield return new WaitForSeconds(1f / wave.Rate);
        }

        _waveIndex++;

        if (_waveIndex == _waves.Length)
        {
            Debug.Log("Level WON!");
            this.enabled = false;
        }

    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnPoint.position, _spawnPoint.rotation);
        EnemiesAlive++; 
    }
}
