using System.Globalization;
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShopController : MonoBehaviour
{
    public static ShopController Instance;
    [SerializeField] private List<GameObject> pickUpGuns;
    [SerializeField] private List<Weapon> boughtGuns;
    [SerializeField] private int gunIndex;
    [SerializeField] private Transform mainPos;
    [SerializeField] private Transform minorPos;
    [SerializeField] private float duration;
    [SerializeField] private PickUpGunInFo currentGun;
    [SerializeField] private List<Weapon> weapons;
    #region TextRegion
    [SerializeField] private Text gunNameTxt;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Text coinAmountTxt;
    // [SerializeField] private Text coinAmountTxtGlobal;

    #endregion
    #region Button Region
    [SerializeField] private Button buyBtn;
    [SerializeField] private Button addCoinBtn;
    #endregion
    [SerializeField] private int coinAmount;
    [SerializeField] private Sprite equiptedBg;
    [SerializeField] private Sprite unPurchaseBg;
    [SerializeField] private Sprite unequiptBG;
    [SerializeField] private Text buyTxt;
    [SerializeField] private List<string> listString;

    public int CoinAmount { get => coinAmount; set => coinAmount = value; }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        InitListWeapon();
        SwitchGunInfo();
        LoadCoinFromData();
    }
    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadCoinFromData();
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        ReadJsonToData();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LoadCoinFromData()
    {
        var coint = PlayerPrefs.GetInt("cointAmount");
        coinAmount = coint;
        SetCoinAmountTxt(coinAmount.ToString());
    }
    public void AddCoint(int extraCoin)
    {
        coinAmount += extraCoin;
        PlayerPrefs.SetInt("cointAmount", coinAmount);
        PlayerPrefs.Save();
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
        switch (currentGun.gunState)
        {
            case GunState.UN_PURCHASED:
                {
                    AssignNewInfoTOBuyBtn(unPurchaseBg, "MUA");
                }
                break;
            case GunState.EQUIPTED:
                {
                    AssignNewInfoTOBuyBtn(equiptedBg, "ĐÃ TRANG BỊ");
                }
                break;
            case GunState.UN_EQUIPTED: break;
        }
    }
    public void MoveToNextGun()
    {
        var minorPos1 = minorPos.transform.position;
        pickUpGuns[gunIndex].transform.position = new Vector3(minorPos1.x, minorPos1.y, pickUpGuns[gunIndex].transform.position.z);
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
        var minorPos1 = minorPos.transform.position;
        pickUpGuns[gunIndex].transform.position = new Vector3(minorPos1.x, minorPos1.y, pickUpGuns[gunIndex].transform.position.z);
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
        // coinAmountTxtGlobal.text = set;
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
                if (boughtGuns.Contains(weapon)) return;
                boughtGuns.Add(weapon);
                ListData listData = new ListData(boughtGuns);
                WriteDataToJson(listData);
            }
        }
    }
    private void WriteDataToJson(object obj)
    {
        print($"add gun data {Application.persistentDataPath}");
        string jsonData = JsonUtility.ToJson(obj);
        File.WriteAllText(Application.persistentDataPath + $"/gunData.json", jsonData);
    }
    private void ReadJsonToData()
    {
        var filePath = Application.persistentDataPath + $"/gunData.json";
        if (!File.Exists(filePath)) return;
        string jsonData = File.ReadAllText(Application.persistentDataPath + $"/gunData.json");
        var gunData = JsonUtility.FromJson<ListData>(jsonData);
        print($"gunda count {gunData.listWeapon.Count}");
        foreach (var gun in gunData.listWeapon)
        {
            boughtGuns.Add(gun);
            gun.gun.GetComponent<PickUpGunInFo>().gunState = GunState.EQUIPTED;
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
public class ListData
{
    public List<Weapon> listWeapon;
    public ListData(List<Weapon> listWeapon)
    {
        this.listWeapon = listWeapon;
    }
}

