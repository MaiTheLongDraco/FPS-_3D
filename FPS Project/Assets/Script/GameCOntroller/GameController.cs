
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pauseGamePanel;
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
}
