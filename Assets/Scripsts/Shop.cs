using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildManager;

    public void OnPurchaseMachineguneTurret()
    {
        Debug.Log("Machingun turret Selected");
        _buildManager.SetTurretToBuild(_buildManager.MachinegunLevel1TurretPrefab);
    }

    public void OnPurchaseRocketTurret()
    {
        Debug.Log("Rocket turret Selected");
        _buildManager.SetTurretToBuild(_buildManager.RocketTurretPrefab);
    }

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    private void Update()
    {
        
    }
}
