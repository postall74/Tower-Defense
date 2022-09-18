using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    [SerializeField] private GameObject _gui;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Text _upgradeCost;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Text _sellAmount;

    private Node _targetNode;

    public void SetTarget(Node node)
    {
        _targetNode = node;
        transform.position = _targetNode.GetBuildPosition();

        if (!_targetNode.IsUpgrade)
        {
            _upgradeCost.text = "$" + _targetNode.TurretBlueprint.UpgradeCost;
            _upgradeButton.interactable = true;
        }
        else
        {
            _upgradeCost.text = "DONE";
            _upgradeButton.interactable = false;
        }

        _sellAmount.text = "$" + _targetNode.TurretBlueprint.GetSellAmount();

        _gui.SetActive(true);
    }

    public void Hide()
    {
        _gui.SetActive(false);
    }

    public void OnUpgrade()
    {
        _targetNode.UpdateTurret();
        BuildManager.instance.DeselectNode();
    }

    public void OnSell()
    {
        _targetNode.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
