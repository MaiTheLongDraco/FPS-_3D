using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayScene : SSController
{
    [SerializeField] private Text winCoinTxt;
    [SerializeField] private ShopController shopController;
    [SerializeField]
    private LevelData levelData;
    [SerializeField] private Text levelText;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private AudioSource _bgMusic;
    [SerializeField] private float musicFadeSpeed;


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
        soundManager = FindObjectOfType<SoundManager>();
        _bgMusic = soundManager.GetMusicSource();
        GetCoinData();
        levelData = FindObjectOfType<LevelData>();
        SetLevelTxt(levelData.GetSelectedLevel().ToString());
    }
    public void PlaySound(AudioClip audioClip)
    {
        soundManager.PlaySound(audioClip);
    }
    public void LoadHomeScene()
    {
        Time.timeScale = 1;
        _bgMusic.volume = 1;
        SSSceneManager.Instance.DestroyScenesFrom("Level1");
        SSSceneManager.Instance.Screen("HomeScene");
    }
    public void LoadShopScene()
    {
        SSSceneManager.Instance.Screen("ShopScene");
    }
    public int GetLevelDataKey()
    {
        return levelData.GetSelectedLevel();
    }
    public void LoadTestScene()
    {
        SSSceneManager.Instance.Screen("TestScene");
    }
    public void LoadNextLevel()
    {
        SSSceneManager.Instance.Screen($"Level{levelData.GetSelectedLevel() + 1}");
        var nextLevel = levelData.GetSelectedLevel() + 1;
        levelData.SetSelectLevel(nextLevel);
        SetLevelTxt(levelData.GetSelectedLevel().ToString());
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
    private void Update()
    {
        MakeGroundMusicFade();
    }
    private void SetLevelTxt(string set)
    {
        levelText.text = set;
    }
    private void MakeGroundMusicFade()
    {
        if (_bgMusic.volume <= 0)
            return;
        _bgMusic.volume -= musicFadeSpeed * Time.deltaTime;
    }
}
