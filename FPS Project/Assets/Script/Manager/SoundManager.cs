using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundManager Instance;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _SoundSource;
    [SerializeField] private AudioClip clickingSound;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void PlayMusic(AudioClip audioClip)
    {
        _musicSource.PlayOneShot(audioClip);
    }
    public void PlaySound(AudioClip sound)
    {
        _SoundSource.PlayOneShot(sound);
    }

}
