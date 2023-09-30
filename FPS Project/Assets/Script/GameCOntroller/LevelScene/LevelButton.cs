using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int key;
    [SerializeField] private Button levelButton;

    // Start is called before the first frame update
    void Start()
    {
        levelButton = GetComponent<Button>();
    }

    // Update is called once per frame
    public int GetKey()
    {
        return key;
    }
    public void Test()
    {
        print($"key {key}");
    }
    public void LoadScene()
    {
        SceneManager.LoadScene($"Level{key}");
    }

}
