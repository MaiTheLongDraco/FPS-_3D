using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    [SerializeField] private float anglePerSecond;
    private float xRotation;
    [SerializeField] private Transform player;
   // Enemy 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RoatateByMousePos();
    }
    private void RoatateByMousePos()
    {
        var mouseX = Input.GetAxis("Mouse X") * anglePerSecond * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * anglePerSecond * Time.deltaTime;
        xRotation -= mouseY;
        xRotation=Mathf.Clamp(xRotation, -90, 90);
        player.transform.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
       // Debug.Log(Vector3.up);
    }    
}
