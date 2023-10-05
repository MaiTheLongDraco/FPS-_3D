using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public SoundManager Instance;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _SoundSource;
    [SerializeField] private Button musicBtn;
    [SerializeField] private Button soundBtn;
    [SerializeField] private Sprite onBg;
    [SerializeField] private Sprite offBg;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        LoadMusicAndSoundState();
    }
    private void OnEnable()
    {
        LoadMusicAndSoundState();
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
    public AudioSource GetMusicSource()
    {
        return _musicSource;
    }
    public void ToggleOnOffMusic()
    {
        _musicSource.mute = !_musicSource.mute;
        PlayerPrefs.SetInt("musicState", Convert.ToInt32(_musicSource.mute));
        PlayerPrefs.Save();
        HandlBgAndTxt(musicBtn, _musicSource.mute);
        print($"musics mute++++ {_musicSource.mute}");
    }
    private void LoadMusicAndSoundState()
    {
        var music = PlayerPrefs.GetInt("musicState") == 1 ? true : false;
        var sound = PlayerPrefs.GetInt("soundState") == 1 ? true : false;
        _musicSource.mute = music;
        _SoundSource.mute = sound;
        HandlBgAndTxt(musicBtn, music);
        HandlBgAndTxt(soundBtn, sound);
    }
    public void ToggleOnOffSound()
    {
        _SoundSource.mute = !_SoundSource.mute;
        PlayerPrefs.SetInt("soundState", Convert.ToInt32(_SoundSource.mute));
        PlayerPrefs.Save();
        HandlBgAndTxt(soundBtn, _SoundSource.mute);
        print($"sound mute++++ {_SoundSource.mute}");
    }
    private void HandlBgAndTxt(Button button, bool isMute)
    {
        switch (isMute)
        {
            case true:
                {
                    SetTextForBtn(button, "OFF");
                    SetBgForBtn(button, offBg);
                    // button.GetComponentInChildren<Text>().color = Color.white;
                }
                break;
            case false:
                {
                    SetTextForBtn(button, "ON");
                    SetBgForBtn(button, onBg);
                }
                break;

        }
    }
    private void SetTextForBtn(Button button, string set)
    {
        button.GetComponentInChildren<Text>().text = set;
    }
    private void SetBgForBtn(Button button, Sprite sprite)
    {
        button.GetComponent<Image>().sprite = sprite;
    }
}
