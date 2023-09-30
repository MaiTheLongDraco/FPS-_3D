using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private List<Button> _levelBtn;
    [SerializeField] private int _startNumber;
    // Start is called before the first frame update
    void Start()
    {
        _levelBtn = GetComponentsInChildren<Button>().ToList();
        SetAllText();
    }

    // Update is called once per frame
    private void SetAllText()
    {
        var setNumber = _startNumber;
        for (int i = 0; i < _levelBtn.Count; i++)
        {
            if (i == 0)
            {
                SetBtnText(_levelBtn[i], setNumber.ToString());
            }
            SetBtnText(_levelBtn[i], setNumber.ToString());
            setNumber++;
        }
    }
    private void SetBtnText(Button button, string levelNumber)
    {
        button.GetComponentInChildren<Text>().text = levelNumber;
    }
}
