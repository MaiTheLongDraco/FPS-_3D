using UnityEngine;
using UnityEngine.EventSystems;

public class RotateByDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Transform playerTran;
    [SerializeField] private Transform cameraTran;
    [SerializeField] private Transform GunTran;
    [SerializeField] private float minPicht;
    [SerializeField] private float maxPicht;
    [SerializeField] private float rotationSpeed;
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("OnDrag");
        float rotationX = eventData.delta.y * rotationSpeed * Time.deltaTime;
        float rotationY = -eventData.delta.x * rotationSpeed * Time.deltaTime;
        playerTran.transform.Rotate(0, -rotationY, 0);
        rotationX = Mathf.Clamp(rotationX, -60, 60);
        cameraTran.transform.Rotate(-rotationX, 0, 0);
        GunTran.transform.Rotate(-rotationX, 0, 0);
    }
    public void SetGunTranform(Gun currenGun)
    {
        print($" prev gun tranform -- {GunTran}");
        GunTran = currenGun.transform;
        print($" after gun tranform  --{GunTran}");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("OnEndDrag");
    }
}
