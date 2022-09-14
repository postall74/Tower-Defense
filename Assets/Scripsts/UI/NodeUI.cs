using UnityEngine;

public class NodeUI : MonoBehaviour
{
    [SerializeField] private GameObject _ui;

    private Node _targetNode;

    public void SetTarget(Node node)
    {
        _targetNode = node;
        transform.position = _targetNode.GetBuildPosition();
        _ui.SetActive(true);
    }

    public void Hide()
    {
        _ui.SetActive(false);
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}
