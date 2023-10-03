
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiTestControl : SSController
{
    [SerializeField] private GameObject testUI;
    private new void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void LoadCurrenScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SSSceneManager.Instance.Screen(current.name);
    }
    public void LoadShopScene()
    {
        SSSceneManager.Instance.Screen("ShopScene");
    }
    public void LoadGamePlayScene()
    {
        SSSceneManager.Instance.Screen("Level1");
    }
    public void LoadLevelScene()
    {
        SSSceneManager.Instance.Screen("LevelScene");
    }
    public void SetActiveTestScene(bool set)
    {
        testUI.SetActive(set);
    }
}
