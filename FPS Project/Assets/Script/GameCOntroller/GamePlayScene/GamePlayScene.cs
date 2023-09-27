using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScene : SSController
{
    [SerializeField] private Text winCoinTxt;
    [SerializeField] private ShopController shopController;

    private new void Start()
    {
        GetCoinData();
    }
    private new void OnEnable()
    {
        shopController = FindObjectOfType<ShopController>();
        GetCoinData();
    }
    public void LoadHomeScene()
    {
        SSSceneManager.Instance.Screen("HomeScene");
    }
    public void LoadShopScene()
    {
        SSSceneManager.Instance.Screen("ShopScene");
    }
    private void GetCoinData()
    {
        var coinAmount = shopController.CoinAmount;
        winCoinTxt.text = coinAmount.ToString();
    }

}
