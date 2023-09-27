using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayScene : SSController
{
    public void LoadHomeScene()
    {
        SSSceneManager.Instance.Screen("HomeScene");
    }
    public void LoadShopScene()
    {
        SSSceneManager.Instance.Screen("ShopScene");
    }
}
