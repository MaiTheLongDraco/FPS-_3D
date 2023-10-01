using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShopScene : SSController
{
    public void LoadHomeScene()
    {
        SSSceneManager.Instance.Screen("HomeScene");
    }

}
