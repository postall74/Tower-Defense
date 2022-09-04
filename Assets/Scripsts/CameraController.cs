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

    private bool _isMovment = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            _isMovment = !_isMovment;

        if (!_isMovment)
            return;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - _panBorderThickness)
        {
            transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= _panBorderThickness)
        {
            transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - _panBorderThickness)
        {
            transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= _panBorderThickness)
        {
            transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
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
