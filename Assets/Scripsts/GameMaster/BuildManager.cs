using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private GameObject _standertTurretPrefab;

    private GameObject _turretToBuild;

    public GameObject GetTurretTToBuild()
    {
        return _turretToBuild;
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

    private void Start()
    {
        _turretToBuild = _standertTurretPrefab;
    }

    private void Update()
    {
        
    }
}
