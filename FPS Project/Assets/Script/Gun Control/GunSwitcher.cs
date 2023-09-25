using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunSwitcher : MonoBehaviour
{
    [SerializeField] private List<Weapon> guns;
    [SerializeField] private List<GameObject> usingGun;

    private int gunIndex;
    private Transform currenGun;
    [SerializeField] private Gun CurrentGun;
    [SerializeField] private bool isButtonHeld;
    [SerializeField] private ShopController shopController;
    private void Start()
    {
        shopController = FindObjectOfType<ShopController>();
        gunIndex = 0;
        GetData();
        ChangeGun();
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
    public void ChangeGun()
    {
        HandleGunIndex();
        for (int i = 0; i < usingGun.Count; i++)
        {
            if (i == gunIndex)
            {
                usingGun[i].SetActive(true);
                currenGun = usingGun[i].transform;
                CurrentGun = usingGun[i].GetComponent<Gun>();
                // OnchangeGun?.Invoke(guns[i].GetComponent<Gun>());
            }
            else
            {
                print("disactive");
                usingGun[i].SetActive(false);
            }
        }
    }
    public void GetData()
    {
        // guns[gunIndex].SetActive(true);
        for (int i = 0; i < guns.Count; i++)
        {
            if (shopController.IsBoughtGunContain(guns[i].gunName) || guns[i].gunName == "Default")
            {
                usingGun.Add(guns[i].gun);
                // OnchangeGun?.Invoke(guns[i].GetComponent<Gun>());
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
        if (gunIndex >= usingGun.Count)
        {
            gunIndex = 0;
        }
    }
    public void ReloadCurrentGun()
    {
        CurrentGun.ReloadAmmo();
    }
    public void AddGunToList(string key, GameObject purchaseGun)
    {
        Weapon weapon = new Weapon(key, purchaseGun);
        guns.Add(weapon);
    }

}
