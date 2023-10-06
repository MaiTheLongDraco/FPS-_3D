using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ShopScene : SSController
{
    [SerializeField] private SoundManager soundManager;
    public void LoadHomeScene()
    {
        SSSceneManager.Instance.Screen("HomeScene");
    }
    private new void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void PlaySound(AudioClip audioClip)
    {
        soundManager.PlaySound(audioClip);
    }

}
