
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject _adsUI;
    [SerializeField] private GameObject _congratulationUI;

    [SerializeField] private RewardedAdsButton rewardedAdsButton;
    public void ShowAdsUI(bool set)
    {
        _adsUI.SetActive(set);
    }
    public void RePlay()
    {
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.name);
        SetActiveLosePanel(false);
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
