using UnityEngine;
using UnityEngine.EventSystems;

public class RotateByDrag : MonoBehaviour, IDragHandler
{
    [SerializeField] private Transform playerTran;
    [SerializeField] private Transform cameraTran;
    [SerializeField] private float minPicht;
    [SerializeField] private float maxPicht;
    [SerializeField] private float rotationSpeed;
    float rotationX;
    float rotationY;
    public void OnDrag(PointerEventData eventData)
    {
        print("OnDrag");
        rotationX += eventData.delta.y * 0.07f;
        rotationY = -eventData.delta.x * rotationSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, minPicht, maxPicht);
        playerTran.transform.Rotate(0, -rotationY, 0);
        Debug.Log($" rotationX {rotationX}");
        cameraTran.transform.localRotation = Quaternion.Euler(-rotationX, 0, 0);
    }
    public void SetRotationSpeed(float set)
    {
        rotationSpeed = set;
    }
}
