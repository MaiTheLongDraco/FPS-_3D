using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSoundInfo : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioClip fire;
    [SerializeField] private AudioClip ready;
    [SerializeField] private AudioClip reload;
    [SerializeField] private AudioClip hitOther;


    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void PlayFire()
    {
        soundManager.PlaySound(fire);
    }
    public void PlayReady()
    {
        soundManager.PlaySound(ready);
    }
    public void PlayReload()
    {
        soundManager.PlaySound(reload);
    }
    public void PlayHitOther()
    {
        soundManager.PlaySound(hitOther);
    }
}
