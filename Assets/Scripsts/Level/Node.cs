using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;

    private GameObject _turret;
    private Renderer _renderer;
    private Color _defaultColor;
    private BuildManager _buildManager;

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

        if (_buildManager.GetTurretToBuild() == null)
            return;

        _renderer.material.color = _hoverColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (_buildManager.GetTurretToBuild() == null)
            return;

        if (_turret != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = _buildManager.GetTurretToBuild();
        _turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _defaultColor;
    }
}
