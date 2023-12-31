using UnityEngine;
using UnityEngine.UI;

public class AmmoSystem : MonoBehaviour
{
    [SerializeField] private Text ammoPerShoot;
    [SerializeField] private Text ammoPerGun;
    [SerializeField] private int NumAmmoPerShoot;
    [SerializeField] private int ResetAmmo;
    [SerializeField] private int NumAmmoPerGun;
    [SerializeField] private float timeToReload;
    [SerializeField] private Gun gun;
    [SerializeField] private AnimationControl animationControl;

    public int NumAmmoPerShoot1 { get => NumAmmoPerShoot; set => NumAmmoPerShoot = value; }
    public int ResetAmmo1 { get => ResetAmmo; set => ResetAmmo = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (gun.weaponType == WeaponType.MEELEE)
            return;
        gun.OnShoot.AddListener(DecreasePerShoot);
    }

    private void Awake()
    {
        animationControl = GetComponent<AnimationControl>();
    }
    private void OnEnable()
    {
        SetUpAmmo();
    }

    private void SetUpAmmo()
    {
        gun = GetComponent<Gun>();
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
            gun.IsOutOfAmmo = true;
            animationControl.GunSoundInfo.PlayReload();
            animationControl.SetTriggerAnim("Reload");
            Invoke("WaitReloadAmmo", timeToReload);
        }
        SetAmmoPerShootTxt(NumAmmoPerShoot.ToString());
        StopShooting();
    }
    private void DecreasePerGun()
    {
        if (NumAmmoPerGun <= 0)
        {
            NumAmmoPerGun = 0;
            return;
        }
        // NumAmmoPerShoot = ResetAmmo;
        NumAmmoPerGun -= ResetAmmo;
        SetAmmoPerGunTxt(NumAmmoPerGun.ToString());
    }
    private void WaitReloadAmmo()
    {
        if (NumAmmoPerGun + NumAmmoPerShoot <= 0)
            return;
        NumAmmoPerShoot = ResetAmmo;
        SetAmmoPerShootTxt(NumAmmoPerShoot.ToString());
        print($"NumAmmoPerGun + NumAmmoPerShoot {NumAmmoPerGun + NumAmmoPerShoot}");
        gun.IsOutOfAmmo = false;
        DecreasePerGun();
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
    public void ReLoadAmmoBtn()
    {
        var reloadNumber = ResetAmmo - NumAmmoPerShoot;
        NumAmmoPerGun -= reloadNumber;
        NumAmmoPerShoot += reloadNumber;
        SetAmmoPerGunTxt(NumAmmoPerGun.ToString());
        SetAmmoPerShootTxt(NumAmmoPerShoot.ToString());
    }

}
