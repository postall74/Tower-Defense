using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _panSpeed = 30f;
    [SerializeField] private float _panBorderThickness = 15f;
    [SerializeField] private float _scrollSpeed = 5f;
    [SerializeField] private float _minY = 10f;
    [SerializeField] private float _maxY = 80f;
    [SerializeField] private float _minZ = -125f;
    [SerializeField] private float _maxZ = 0f;
    [SerializeField] private float _minX = -45f;
    [SerializeField] private float _maxX = 115f;

    private void Update()
    {
        if (GameManager.IsGameOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - _panBorderThickness)
        {
            transform.Translate(_panSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= _panBorderThickness)
        {
            transform.Translate(_panSpeed * Time.deltaTime * Vector3.back, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - _panBorderThickness)
        {
            transform.Translate(_panSpeed * Time.deltaTime * Vector3.right, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= _panBorderThickness)
        {
            transform.Translate(_panSpeed * Time.deltaTime * Vector3.left, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * 1000 * _scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, _minY, _maxY);
        position.x = Mathf.Clamp(position.x, _minX, _maxX);
        position.z = Mathf.Clamp(position.z, _minZ, _maxZ);

        transform.position = position;
    }
}
