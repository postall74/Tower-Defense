using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;

    private GameObject _turret;
    private Renderer _renderer;
    private Color _defaultColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    private void Update()
    {
        
    }


    private void OnMouseEnter()
    {
        _renderer.material.color = _hoverColor;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretTToBuild();
        _turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _defaultColor;
    }
}
