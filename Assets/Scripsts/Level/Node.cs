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

    public Vector3 GetBuildPosition()
    {
        return transform.position;
    }

    public void SetBuildTurret(GameObject turret)
    {
        _turret = turret;
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

        _buildManager.BuildTurretOn(this);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _defaultColor;
    }
}
