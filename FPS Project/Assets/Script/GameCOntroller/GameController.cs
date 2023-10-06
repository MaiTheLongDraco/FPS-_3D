
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject _adsUI;
    [SerializeField] private GameObject _congratulationUI;
    [SerializeField] private LayerMask adsCullingMask;
    [SerializeField] private LayerMask defaulCullingMask;



    [SerializeField] private RewardedAdsButton rewardedAdsButton;
    public void ShowAdsUI(bool set)
    {
        if (Camera.main == null) return;
        if (set)
        {
            Camera.main.cullingMask = adsCullingMask;
        }
        else
        {
            Camera.main.cullingMask = defaulCullingMask;
        }
        _adsUI.SetActive(set);
    }
    public void RePlay()
    {
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.name);
        SetActiveLosePanel(false);
    }
    public void ReTry()
    {
        SetActivePauseGamePanel(false);
        Time.timeScale = 1;
        Scene active = SceneManager.GetActiveScene();
        SSSceneManager.Instance.Reset(active);
        // SSSceneManager.Instance.Screen(active.name);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        SetActivePauseGamePanel(true);
    }
    public void Continue()
    {
        SetActivePauseGamePanel(false);
        Time.timeScale = 1;
    }
    public void SetActivePauseGamePanel(bool set)
    {
        pauseGamePanel.SetActive(set);
    }
    public void SetActiveLosePanel(bool isActive)
    {
        losePanel.SetActive(isActive);
    }
    public void SetActiveCongratulationUI(bool set)
    {
        if (set)
        {
            Camera.main.cullingMask = adsCullingMask;
        }
        else
        {
            Camera.main.cullingMask = defaulCullingMask;
        }
        _congratulationUI.SetActive(set);
    }
    public void SetActiveShop(bool set)
    {
        Shop.SetActive(set);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void LoadAds()
    {
        rewardedAdsButton.LoadAd();
    }

}
