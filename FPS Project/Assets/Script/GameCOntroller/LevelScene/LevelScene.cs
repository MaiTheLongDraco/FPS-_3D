using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelScene : SSController
{
    public static LevelScene Instance;
    [SerializeField] private List<LevelButton> listBtn;
    [SerializeField] private Sprite unlockedBg;
    [SerializeField] private Sprite lockedBg;
    [SerializeField] private Sprite currentBg;
    [SerializeField] private Sprite unlockIcon;
    [SerializeField] private LevelData levelData;

    [SerializeField] private Text cointAmount;
    private new void Start()
    {
        levelData = FindObjectOfType<LevelData>();
        LoadCoinFromData();
        listBtn = GetComponentsInChildren<LevelButton>().ToList();
        levelData.SetListBtn(listBtn);
        ReadLevelJsonData();
        ReSetUpButton();
    }
    private new void Awake()
    {
        levelData = FindObjectOfType<LevelData>();
        LoadCoinFromData();
        listBtn = GetComponentsInChildren<LevelButton>().ToList();
        levelData.SetListBtn(listBtn);
        ReadLevelJsonData();
        ReSetUpButton();
    }
    private new void OnDisable()
    {
        levelData.SetListBtn(listBtn);
    }
    private void ReadLevelJsonData()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + $"/levelData.json");
        if (jsonData == null) return;
        LevelJsonData levelJsonData = JsonUtility.FromJson<LevelJsonData>(jsonData);
        foreach (var key in levelJsonData.levelUnlockKey)
        {
            var activeBtn = listBtn.Find(btn => btn.GetKey() == key);
            activeBtn.buttonState = ButtonState.UNLOCKED;
        }
        foreach (var button in listBtn)
        {
            if (button.GetKey() == levelJsonData.currentLevel)
            {
                button.buttonState = ButtonState.CURRENT;

            }
        }
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
    private void SetUpBtn()
    {
        foreach (var level in listBtn)
        {
            if (level.GetKey() == 1)
            {
                level.ChangeBGButtoon(currentBg);
                level.ChangeLockIcon(unlockIcon);
                level.SetButtonState(ButtonState.CURRENT);
                level.GetComponent<Button>().interactable = true;
            }
            else
            {
                level.SetButtonState(ButtonState.LOCK);
                level.ChangeBGButtoon(lockedBg);
                level.GetComponent<Button>().interactable = false;
            }

        }
    }
    private void ReSetUpButton()
    {
        foreach (var level in listBtn)
        {
            if (level.buttonState == ButtonState.LOCK)
            {
                level.ChangeBGButtoon(lockedBg);
                level.GetComponent<Button>().interactable = false;
            }
            else if (level.buttonState == ButtonState.UNLOCKED)
            {
                level.ChangeLockIcon(unlockIcon);
                level.ChangeBGButtoon(unlockedBg);
                level.GetComponent<Button>().interactable = true;
            }
            else
            {
                level.ChangeLockIcon(unlockIcon);
                level.ChangeBGButtoon(currentBg);
                level.GetComponent<Button>().interactable = true;
            }

        }
    }


}
