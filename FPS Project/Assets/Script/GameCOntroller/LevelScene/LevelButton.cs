using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int key;
    [SerializeField] private Button levelButton;
    [SerializeField] private Image BgIMG;
    [SerializeField] private Image lockIcon;
    [SerializeField] private GameObject levelUI;
    [SerializeField] private LevelData levelData;
    [SerializeField] public ButtonState buttonState;

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
    public void SetButtonState(ButtonState newState)
    {
        buttonState = newState;
    }
    public void LoadScene()
    {
        levelData.SetSelectLevel(key);
        levelUI.gameObject.SetActive(false);
        // SceneManager.LoadScene($"Level{key}");
        SSSceneManager.Instance.Screen($"Level{key}");
        // SceneManager.LoadScene($"GamePlay");
    }
    public void ChangeBGButtoon(Sprite newBg)
    {
        BgIMG.sprite = newBg;
    }
    public void ChangeLockIcon(Sprite newBg = null)
    {
        lockIcon.sprite = newBg;
    }

}
public enum ButtonState
{
    LOCK,
    UNLOCKED,
    CURRENT
}