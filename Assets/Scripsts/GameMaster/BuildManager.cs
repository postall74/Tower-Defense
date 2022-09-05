using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint _turretToBuild;

    public bool CanBuild { get { return _turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
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

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.Cost)
        {
            Debug.Log("Not enoth money to build that!");
            return;
        }

        PlayerStats.Money -= _turretToBuild.Cost;

        GameObject turret = (GameObject)Instantiate(_turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.SetBuildTurret(turret);

        Debug.Log($"Turret build! Money left - {PlayerStats.Money}");
    }
}
