using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeathBar : MonoBehaviour
{
    void Update()
    {
        // Hướng của camera
        Vector3 cameraDirection = Camera.main.transform.forward;

        // Đảm bảo health bar chỉ xoay theo trục y (up)
        cameraDirection.y = 0f;

        // Quay health bar để hướng về camera
        transform.forward = cameraDirection;
    }
}
