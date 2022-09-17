using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _notEnouthMoneyColor;

    private GameObject _turret;
    private Renderer _renderer;
    private Color _defaultColor;
    private BuildManager _buildManager;
    private TurretBlueprint _turretBlueprint;
    private bool _isUpgrade = false;

    public TurretBlueprint TurretBlueprint => _turretBlueprint;
    public bool IsUpgrade => _isUpgrade;

    public Vector3 GetBuildPosition() 
    {
        return transform.position; 
    }

    public void SetBuildTurret(GameObject turret)
    {
        _turret = turret;
    }
    

    public void UpdateTurret()
    {
        if (PlayerStats.Momey < _turretBlueprint.UpgradeCost)
        {
            Debug.Log("Not enoth money to upgrade that!");
            return;
        }

        if (_isUpgrade)
        {
            Debug.Log("");
            return;
        }

        Payment(_turretBlueprint.UpgradeCost);

        Destroy(_turret);

        GameObject turret = (GameObject)Instantiate(_turretBlueprint.UpgradePrefab, GetBuildPosition(), Quaternion.identity);
        SetBuildTurret(turret);

        GameObject effect = Instantiate(_buildManager.UpgradeEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);

        _isUpgrade = true;

        Debug.Log("Turret Upgrade");
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
        _buildManager = BuildManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
            return;

        if (_buildManager.HasMoney)
        {
            _renderer.material.color = _hoverColor;
        }
        else
        {
            _renderer.material.color = _notEnouthMoneyColor;
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }

        if (!_buildManager.CanBuild)
            return;

        BuildTurret(_buildManager.TurretToBuild);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _defaultColor;
    }

    private void BuildTurret(TurretBlueprint turretToBuild)
    {
        if (PlayerStats.Momey < turretToBuild.BuildCost)
        {
            Debug.Log("Not enoth money to build that!");
            return;
        }

        Payment(turretToBuild.BuildCost);

        GameObject turret = (GameObject)Instantiate(turretToBuild.BuildPrefab, GetBuildPosition(), Quaternion.identity);
        SetBuildTurret(turret);

        _turretBlueprint = turretToBuild;

        GameObject effect = Instantiate(_buildManager.BuildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 2f);
    }

    private void Payment(int value)
    {
        PlayerStats.ChangeMoney(-value);
    }
}
