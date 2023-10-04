using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScene : SSController
{
    [SerializeField] private Button _fpsBtn;
    [SerializeField] private bool isFpsChange;
    [SerializeField] private Sprite defaulFps;
    [SerializeField] private Sprite highFps;
    string[] exceptList = { "HomeScene", "ShopScene" };
    public void LoadShopScene()
    {

        SSSceneManager.Instance.Screen("ShopScene");
    }
    public void LoadLevelScene()
    {
        SSSceneManager.Instance.DestroyInactiveScenes(exceptList);
        SSSceneManager.Instance.Screen("LevelScene");
    }
    public void LoadTestScene()
    {
        SSSceneManager.Instance.Screen("TestScene");
    }
    public void SetFpsChange()
    {
        isFpsChange = !isFpsChange;
        HandlBgAndTxt(_fpsBtn, isFpsChange);
    }
    private void HandlBgAndTxt(Button button, bool isFpsChange)
    {
        switch (isFpsChange)
        {
            case true:
                {
                    SetTextForBtn(button, "60");
                    SetBgForBtn(button, highFps);
                }
                break;
            case false:
                {
                    SetTextForBtn(button, "30");
                    SetBgForBtn(button, defaulFps);
                }
                break;

        }
    }
    private void SetTextForBtn(Button button, string set)
    {
        button.GetComponentInChildren<Text>().text = set;
    }
    private void SetBgForBtn(Button button, Sprite sprite)
    {
        button.GetComponent<Image>().sprite = sprite;
    }
}
