using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private GameObject _machinegunTurretPrefab;
    [SerializeField] private GameObject _rocketTurretPrefab;

    private GameObject _turretToBuild;

    public GameObject MachinegunLevel1TurretPrefab => _machinegunTurretPrefab;
    public GameObject RocketTurretPrefab => _rocketTurretPrefab;

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More that one BuildManager in scene!");
            return;
        }

        instance = this;
    }
}
