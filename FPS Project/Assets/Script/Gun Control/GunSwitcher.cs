using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] private static List<GameObject> guns;
    public static GunSwitcher Instance;
    private int gunIndex;
    private Transform currenGun;
    [SerializeField] private Gun CurrentGun;
    [SerializeField] private bool isButtonHeld;
    public UnityEvent<Gun> OnchangeGun;
    private void Start()
    {
        gunIndex = 0;
        SwitchGun();
        DontDestroyOnLoad(this.gameObject);
    }
    public void CurrentGunShoot()
    {
        if (isButtonHeld)
        {
            CurrentGun.HandleShootInteval();
        }
    }
    private void Update()
    {
        CurrentGunShoot();
    }
    public void ButtonPress()
    {
        isButtonHeld = true;
    }
    public void ButtonRelease()
    {
        isButtonHeld = false;
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
                CurrentGun = guns[gunIndex].GetComponent<Gun>();
                OnchangeGun?.Invoke(guns[i].GetComponent<Gun>());
            }
            else
            {
                guns[i].SetActive(false);
            }
        }
    }

    public void SetAimCurrentGun(bool set)
    {
        currenGun.GetComponent<AmingSystem>().SetAim(set);
    }
    private void HandleGunIndex()
    {
        gunIndex++;
        if (gunIndex >= guns.Count)
        {
            gunIndex = 0;
        }
    }
    public void ReloadCurrentGun()
    {
        CurrentGun.ReloadAmmo();
    }
    public void AddGunToList(GameObject purchaseGun)
    {
        guns.Add(purchaseGun);
    }
}
