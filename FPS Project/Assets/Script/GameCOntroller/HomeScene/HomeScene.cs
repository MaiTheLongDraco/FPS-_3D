using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScene : SSController
{
    public void LoadShopScene()
    {
        SSSceneManager.Instance.Screen("ShopScene");
    }
    public void LoadGamePlayScene()
    {
        SSSceneManager.Instance.Screen("GamePlay");
    }
}
