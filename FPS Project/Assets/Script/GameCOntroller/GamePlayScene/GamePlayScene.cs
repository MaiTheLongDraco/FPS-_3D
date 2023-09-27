using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScene : SSController
{
    [SerializeField] private Text winCoinTxt;
    private new void Start()
    {
        GetCoinData();
    }
    private new void OnEnable()
    {
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
        var coinAmount = PlayerPrefs.GetInt("coinAmount");
        winCoinTxt.text = coinAmount.ToString();
    }

}
