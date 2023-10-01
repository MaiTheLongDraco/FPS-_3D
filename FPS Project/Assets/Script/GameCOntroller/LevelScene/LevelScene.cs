using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScene : SSController
{
    [SerializeField] private Text cointAmount;
    private new void Start()
    {
        LoadCoinFromData();
    }
    public void LoadHomeScene()
    {
        SSSceneManager.Instance.Screen("HomeScene");
    }

    private void LoadCoinFromData()
    {
        var coint = PlayerPrefs.GetInt("cointAmount");
        SetCoinAmountTxt(coint.ToString());
    }
    private void SetCoinAmountTxt(string set)
    {
        cointAmount.text = set;
    }
}
