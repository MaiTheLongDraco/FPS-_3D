using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] public int selectedLevel;
    [SerializeField] private List<LevelButton> levelButtons;
    [SerializeField] private List<int> activeBtns = new List<int>();

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetSelectLevel(int set)
    {
        selectedLevel = set;
    }
    public int GetSelectedLevel()
    {
        return selectedLevel;
    }
    public void SetListBtn(List<LevelButton> newList)
    {
        levelButtons = newList;
    }
    public void SetButtonStateWithKey(int key, ButtonState buttonState)
    {
        foreach (var lv in levelButtons)
        {
            if (lv.GetKey() == key)
            {
                lv.SetButtonState(buttonState);
            }
        }
    }
    public void AddKeyToActiveBtn(int key)
    {
        activeBtns.Add(key);
    }
    public List<int> GetLevelKey()
    {
        return activeBtns;
    }
}
public class LevelJsonData
{
    public List<int> levelUnlockKey = new List<int>();
    public int currentLevel;

    public LevelJsonData(List<int> newData, int currentLevel)
    {
        levelUnlockKey = newData;
        this.currentLevel = currentLevel;
    }
}
