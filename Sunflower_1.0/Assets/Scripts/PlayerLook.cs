using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _xSensitivity;
    [SerializeField] private float _ySensitivity;
    [SerializeField] private Camera _camera;

    private float _xRotation = 0f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        _xRotation -= (mouseY * Time.deltaTime) * _ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * _xSensitivity);
    }
}
