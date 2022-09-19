using UnityEngine;

[System.Serializable]
public class Wave
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _count;
    [SerializeField] private float _rate;

    public GameObject EnemyPrefab => _enemyPrefab;
    public int Count => _count;
    public float Rate => _rate;

}
