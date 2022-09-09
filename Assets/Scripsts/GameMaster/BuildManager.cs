using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private GameObject _buildEffect;

    private TurretBlueprint _turretToBuild;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Momey >= _turretToBuild.Cost; } }

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
        if (PlayerStats.Momey < _turretToBuild.Cost)
        {
            Debug.Log("Not enoth money to build that!");
            return;
        }

        Payment(_turretToBuild.Cost);

        GameObject turret = (GameObject)Instantiate(_turretToBuild.Prefab, node.GetBuildPosition(), Quaternion.identity);
        node.SetBuildTurret(turret);

        GameObject effect = Instantiate(_buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        Debug.Log($"Turret build! Money left - {PlayerStats.Momey}");
    }

    private void Payment(int value)
    {
        PlayerStats.ChangeMoney(-value);
    }
}
