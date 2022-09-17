using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBlueprint
{
    [SerializeField] private GameObject _buildPrefab;
    [SerializeField] private int _buildCost;
    [SerializeField] private GameObject _upgradePrefab;
    [SerializeField] private int _upgradeCost;

    public GameObject BuildPrefab => _buildPrefab;
    public GameObject UpgradePrefab => _upgradePrefab;
    public int BuildCost => _buildCost;
    public int UpgradeCost => _upgradeCost;
}
