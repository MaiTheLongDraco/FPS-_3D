using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetTextForEnemy : MonoBehaviour
{
    [SerializeField] private int totalEnmeny;
    [SerializeField] private int killedEnmeny;
    [SerializeField] private int rewardCoin;
    [SerializeField] private Text rewarCoinTxt;

    [SerializeField] private Text totalEnmenyTXT;
    [SerializeField] private Text killedEnmenyTXT;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private ShopController shop;
    [SerializeField] private LevelData levelData;
    [SerializeField] private GamePlayScene gamePlayScene;


    // Start is called before the first frame update
    void Start()
    {
        totalEnmeny = GetComponentsInChildren<Enemy>().Count();
        SetTotalEnemy(totalEnmeny.ToString());
        SetKilledEnemy(killedEnmeny.ToString());
        SetActiveWinPanel(false);
    }
    private void OnEnable()
    {
        levelData = FindObjectOfType<LevelData>();
    }
    private void Awake()
    {
        shop = FindObjectOfType<ShopController>();
        gamePlayScene = FindObjectOfType<GamePlayScene>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void SetTotalEnemy(string set)
    {
        totalEnmenyTXT.text = set;
    }
    private void SetKilledEnemy(string set)
    {
        killedEnmenyTXT.text = set;
    }
    public void IncreaseKillEnenmy()
    {
        killedEnmeny++;
        SetKilledEnemy(killedEnmeny.ToString());
        if (killedEnmeny >= totalEnmeny)
        {
            SetLevelData();
            Invoke("WinGame", 2f);
        }
    }

    private void SetLevelData()
    {
        levelData.SetButtonStateWithKey(gamePlayScene
                    .GetLevelDataKey(), ButtonState.UNLOCKED);
        levelData.AddKeyToActiveBtn(levelData.selectedLevel);
        LevelJsonData levelJsonData = new LevelJsonData(levelData.GetLevelKey(), levelData.selectedLevel + 1);
        var json = JsonUtility.ToJson(levelJsonData);
        File.WriteAllText(Application.persistentDataPath + $"/levelData.json", json);
    }

    private void WinGame()
    {
        if (shop)
        {
            shop.AddCoint(rewardCoin);
        }
        else
        {
            var currentCoin = PlayerPrefs.GetInt("cointAmount");
            currentCoin += rewardCoin;
            PlayerPrefs.SetInt("cointAmount", currentCoin);
            PlayerPrefs.Save();
        }
        SetActiveWinPanel(true);
        rewarCoinTxt.text = rewardCoin.ToString();
    }

    private void SetActiveWinPanel(bool set)
    {
        winPanel.SetActive(set);
    }
}
