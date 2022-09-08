using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TurretBlueprint _machinegunTurret;  
    [SerializeField] private TurretBlueprint _rocketTurret;
    [SerializeField] private TurretBlueprint _laserTurret;

    private BuildManager _buildManager;

    public void OnSelectMachineguneTurret()
    {
        Debug.Log("Machingun turret Selected");
        _buildManager.SelectTurretToBuild(_machinegunTurret);
    }

    public void OnSelectRocketTurret()
    {
        Debug.Log("Rocket turret Selected");
        _buildManager.SelectTurretToBuild(_rocketTurret);
    }

    public void OnSelectLaserTurret()
    {
        Debug.Log("Laser turret Selected");
        _buildManager.SelectTurretToBuild(_laserTurret);
    }

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }
}
