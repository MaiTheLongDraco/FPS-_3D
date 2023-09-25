
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pauseGamePanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject Shop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RePlay()
    {
        SceneManager.LoadScene("GamePlay");
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
}
