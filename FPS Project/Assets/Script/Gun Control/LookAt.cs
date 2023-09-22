using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LookAt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LookAtCenter();
    }
    private void LookAtCenter()
    {
        // print($"Loook at");
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 worldCenter = Camera.main.ScreenToWorldPoint(screenCenter);
        transform.DOLookAt(-worldCenter, .5f);
    }
}
