using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScene : SSController
{
    [SerializeField] private Text winCoinTxt;
    [SerializeField] private ShopController shopController;
    [SerializeField]
    private LevelData levelData;
    [SerializeField] private Text levelText;

    private new void Start()
    {
        GetCoinData();
        levelData = FindObjectOfType<LevelData>();
        SetLevelTxt(levelData.GetSelectedLevel().ToString());
        // SetLevelTxt(LevelData.selectedLevel.ToString());
    }
    private new void OnEnable()
    {
        shopController = FindObjectOfType<ShopController>();
        GetCoinData();
        levelData = FindObjectOfType<LevelData>();
        SetLevelTxt(levelData.GetSelectedLevel().ToString());
    }
    public void LoadHomeScene()
    {
        SSSceneManager.Instance.Screen("HomeScene");
    }
    public void LoadShopScene()
    {
        SSSceneManager.Instance.Screen("ShopScene");
    }
    public void LoadTestScene()
    {
        SSSceneManager.Instance.Screen("TestScene");
    }
    private void GetCoinData()
    {
        if (shopController)
        {
            var coinAmount = shopController.CoinAmount;
            winCoinTxt.text = coinAmount.ToString();
        }
        else
        {
            var coinAmount = PlayerPrefs.GetInt("cointAmount");
            winCoinTxt.text = coinAmount.ToString();
        }
    }
    private void SetLevelTxt(string set)
    {
        levelText.text = set;
    }

}
