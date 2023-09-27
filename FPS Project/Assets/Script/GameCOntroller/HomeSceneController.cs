using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneController : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        SetCointTextStart();
    }
    private void OnEnable()
    {
        SetCointTextStart();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetCointTextStart()
    {
        var cointAmount = PlayerPrefs.GetInt("cointAmount");
        // var cointAmount = FindObjectOfType<ShopController>().CoinAmount;
        coinText.text = cointAmount.ToString();
    }
    public void SetActiveSetting(bool set)
    {
        setting.SetActive(set);
    }
}
