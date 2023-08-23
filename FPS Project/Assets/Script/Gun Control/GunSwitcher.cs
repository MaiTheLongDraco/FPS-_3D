using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> guns;
    private int gunIndex;
    private Transform currenGun;
    public UnityEvent<Gun> OnchangeGun;
    private void Start()
    {
        gunIndex = 0;
        SwitchGun();
    }

    public void SwitchGun()
    {
        HandleGunIndex();
        // guns[gunIndex].SetActive(true);
        for (int i = 0; i < guns.Count; i++)
        {
            if (i == gunIndex)
            {
                guns[i].SetActive(true);
                currenGun = guns[i].transform;
                OnchangeGun?.Invoke(guns[i].GetComponent<Gun>());
            }
            else
            {
                guns[i].SetActive(false);
            }
        }
    }
    private void HandleGunIndex()
    {
        gunIndex++;
        if (gunIndex >= guns.Count)
        {
            gunIndex = 0;
        }
    }

}
