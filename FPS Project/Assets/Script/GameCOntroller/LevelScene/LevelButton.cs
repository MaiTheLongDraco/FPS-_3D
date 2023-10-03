using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int key;
    [SerializeField] private Button levelButton;
    [SerializeField] private GameObject levelUI;
    [SerializeField] private LevelData levelData;

    // Start is called before the first frame update
    void Start()
    {
        levelButton = GetComponent<Button>();
        levelData = FindObjectOfType<LevelData>();
    }

    // Update is called once per frame
    public int GetKey()
    {
        return key;
    }
    public void SetKey(int set)
    {
        key = set;
    }
    public void LoadScene()
    {
        levelData.SetSelectLevel(key);
        levelUI.gameObject.SetActive(false);
        // SceneManager.LoadScene($"Level{key}");
        SSSceneManager.Instance.Screen($"Level{key}");
        // SceneManager.LoadScene($"GamePlay");
    }

}
