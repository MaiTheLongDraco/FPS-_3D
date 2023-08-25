using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    [SerializeField] private Text ammoPerShoot;
    [SerializeField] private Text ammoPerGun;
    [SerializeField] private int NumAmmoPerShoot;
    [SerializeField] private int ResetAmmo;
    [SerializeField] private int NumAmmoPerGun;

    [SerializeField] private Gun gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = GetComponent<Gun>();
        gun.OnShoot.AddListener(DecreasePerShoot);
        SetAmmoPerShootTxt(NumAmmoPerShoot.ToString());
        SetAmmoPerGunTxt(NumAmmoPerGun.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DecreasePerShoot()
    {
        NumAmmoPerShoot--;
        if (NumAmmoPerShoot <= 0)
        {
            DecreasePerGun();
        }
        SetAmmoPerShootTxt(NumAmmoPerShoot.ToString());
        StopShooting();
    }
    private void DecreasePerGun()
    {
        if (NumAmmoPerGun <= 0) return;
        NumAmmoPerGun -= ResetAmmo;
        NumAmmoPerShoot = ResetAmmo;
        SetAmmoPerGunTxt(NumAmmoPerGun.ToString());
    }
    private void StopShooting()
    {
        if (NumAmmoPerGun + NumAmmoPerShoot <= 0)
        {
            gun.IsOutOfAmmo = true;
        }
    }
    private void SetAmmoPerShootTxt(string desireText)
    {
        ammoPerShoot.text = desireText;
    }
    private void SetAmmoPerGunTxt(string desireText)
    {
        ammoPerGun.text = desireText;
    }

}
