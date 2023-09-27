using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        totalEnmeny = GetComponentsInChildren<Enemy>().Count();
        SetTotalEnemy(totalEnmeny.ToString());
        SetKilledEnemy(killedEnmeny.ToString());
        SetActiveWinPanel(false);
    }
    private void Awake()
    {
        shop = FindObjectOfType<ShopController>();
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
            Invoke("WinGame", 2f);
        }
    }

    private void WinGame()
    {
        shop.AddCoint(rewardCoin);
        SetActiveWinPanel(true);
        rewarCoinTxt.text = rewardCoin.ToString();
    }

    private void SetActiveWinPanel(bool set)
    {
        winPanel.SetActive(set);
    }
}
