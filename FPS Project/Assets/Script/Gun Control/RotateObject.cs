using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        // Quay game object quanh trục Y với tốc độ xác định
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
