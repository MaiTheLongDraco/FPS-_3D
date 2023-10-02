using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] public int selectedLevel;
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
}
