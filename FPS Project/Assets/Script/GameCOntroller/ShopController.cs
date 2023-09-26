using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    [SerializeField] private List<GameObject> pickUpGuns;
    [SerializeField] private List<Weapon> boughtGuns;
    [SerializeField] private int gunIndex;
    [SerializeField] private Transform mainPos;
    [SerializeField] private Vector3 minorPos;
    [SerializeField] private float duration;
    [SerializeField] private PickUpGunInFo currentGun;
    [SerializeField] private List<Weapon> weapons;
    #region TextRegion
    [SerializeField] private Text gunNameTxt;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Text coinAmountTxt;
    [SerializeField] private Text coinAmountTxtGlobal;

    #endregion
    #region Button Region
    [SerializeField] private Button buyBtn;
    [SerializeField] private Button addCoinBtn;
    #endregion
    [SerializeField] private int coinAmount;
    [SerializeField] private Sprite equiptedBg;
    [SerializeField] private Sprite unequiptBG;
    [SerializeField] private Text buyTxt;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        InitListWeapon();
        minorPos = mainPos.position + Vector3.right * 5;
        SwitchGunInfo();
        SetCoinAmountTxt(coinAmount.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddCoint(int extraCoin)
    {
        coinAmount += extraCoin;
        SetCoinAmountTxt(coinAmount.ToString());
    }
    public bool IsBoughtGunContain(string key)
    {
        foreach (var gun in boughtGuns)
        {
            if (gun.gunName == key)
                return true;
        }
        return false;
    }
    private void AssignNewInfoTOBuyBtn(Sprite sprite, string newTxt)
    {
        buyBtn.GetComponent<Image>().sprite = sprite;
        buyTxt.text = newTxt;
    }
    private void SwitchGunInfo()
    {
        currentGun = pickUpGuns[gunIndex].GetComponent<PickUpGunInFo>();
        SetTextForGunNameTxt(currentGun.gunName);
        SetTextForPriceTxt(currentGun.gunPrice.ToString());
    }
    public void MoveToNextGun()
    {
        pickUpGuns[gunIndex].transform.position = new Vector3(minorPos.x, minorPos.y, pickUpGuns[gunIndex].transform.position.z);
        gunIndex++;
        if (gunIndex >= pickUpGuns.Count)
        {
            gunIndex = 0;
        }
        var pos = mainPos.position;
        pickUpGuns[gunIndex].transform.DOMove(new Vector3(pos.x, pos.y, pickUpGuns[gunIndex].transform.position.z), duration);
        SwitchGunInfo();
    }


    public void BackToPrevGun()
    {
        pickUpGuns[gunIndex].transform.position = new Vector3(minorPos.x, minorPos.y, pickUpGuns[gunIndex].transform.position.z);
        gunIndex--;
        if (gunIndex < 0)
        {
            gunIndex = pickUpGuns.Count - 1;
        }
        var pos = mainPos.position;
        pickUpGuns[gunIndex].transform.DOMove(new Vector3(pos.x, pos.y, pickUpGuns[gunIndex].transform.position.z), duration);
        SwitchGunInfo();
    }
    private void SetTextForGunNameTxt(string set)
    {
        gunNameTxt.text = set;
    }
    private void SetTextForPriceTxt(string set)
    {
        print($"gunpriice {set}");
        priceTxt.text = set;
    }
    public void Buy()
    {
        if (coinAmount < currentGun.gunPrice || coinAmount <= 0 || currentGun.gunState == GunState.EQUIPTED)
            return;
        coinAmount -= currentGun.gunPrice;
        SetCoinAmountTxt(coinAmount.ToString());
        currentGun.gunState = GunState.EQUIPTED;
        AssignNewInfoTOBuyBtn(equiptedBg, "ĐÃ TRANG BỊ");
        AddGunToBag();
    }
    private bool IsBought()
    {
        return currentGun.gunState == GunState.EQUIPTED;
    }
    private void SetCoinAmountTxt(string set)
    {
        coinAmountTxt.text = set;
        coinAmountTxtGlobal.text = set;
    }
    public void WatchAds()
    {
        print("WATCH ADS");
    }
    private void AddGunToBag()
    {
        if (currentGun.gunState != GunState.EQUIPTED)
            return;
        var gunName = currentGun.gunName;
        foreach (var weapon in weapons)
        {
            if (weapon.gunName == gunName)
            {
                boughtGuns.Add(weapon);
            }
        }
    }
    private void InitListWeapon()
    {
        foreach (var gun in pickUpGuns)
        {
            var key = gun.GetComponent<PickUpGunInFo>().gunName;
            Weapon newWeapon = new Weapon(key, gun);
            weapons.Add(newWeapon);
        }
    }
}
[Serializable]
public class Weapon
{
    public string gunName;
    public GameObject gun;
    public Weapon(string name, GameObject gun)
    {
        gunName = name;
        this.gun = gun;
    }
}
