using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject creditUI;
    [SerializeField] private GameObject settingUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetActiveCredit(bool set)
    {
        creditUI.SetActive(set);
    }
    public void SetActiveSetting(bool set)
    {
        settingUI.SetActive(set);
    }
}
