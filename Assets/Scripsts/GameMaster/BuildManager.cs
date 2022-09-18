using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [SerializeField] private GameObject _buildEffect;
    [SerializeField] private GameObject _upgradeEffect;
    [SerializeField] private GameObject _sellEffect;
    [SerializeField] private NodeUI _nodeUI;

    private TurretBlueprint _turretToBuild;
    private Node _selectedNode; 

    public GameObject BuildEffect => _buildEffect;
    public GameObject UpgradeEffect => _upgradeEffect;
    public GameObject SellEffect => _sellEffect;
    public TurretBlueprint TurretToBuild => _turretToBuild;

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Momey >= _turretToBuild.BuildCost; } }

    public void SelectNode(Node node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }

        _selectedNode = node;
        _turretToBuild = null;
        _nodeUI.SetTarget(_selectedNode);
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
        DeselectNode();
    }

    public void DeselectNode()
    {
        _selectedNode = null;
        _nodeUI.Hide();
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
