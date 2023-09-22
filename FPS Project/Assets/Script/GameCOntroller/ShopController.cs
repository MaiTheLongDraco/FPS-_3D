using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] private List<GameObject> pickUpGuns;
    [SerializeField] private int gunIndex;
    [SerializeField] private Transform mainPos;
    [SerializeField] private Vector3 minorPos;
    [SerializeField] private float duration;
    [SerializeField] private PickUpGunInFo currentGun;
    [SerializeField] private Text gunNameTxt;
    [SerializeField] private Text priceTxt;
    [SerializeField] private Text coinAmountTxt;

    [SerializeField] private int coinAmount;


    // Start is called before the first frame update
    void Start()
    {
        minorPos = mainPos.position + Vector3.right * 5;
        SwitchGunInfo();
        SetCoinAmountTxt(coinAmount.ToString());
    }

    // Update is called once per frame
    void Update()
    {

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
        if (coinAmount < currentGun.gunPrice || coinAmount <= 0)
            return;
        coinAmount -= currentGun.gunPrice;
        SetCoinAmountTxt(coinAmount.ToString());
        currentGun.gunState = GunState.EQUIPTED;
    }
    private void SetCoinAmountTxt(string set)
    {
        coinAmountTxt.text = set;
    }
}