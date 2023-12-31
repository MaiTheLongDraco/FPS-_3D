using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    #region public var
    public bool IsTakeDamage { get { return isTakeDamage; } private set { isTakeDamage = value; } }
    public GameObject SplashScreen { get { return _splashScreen; } }
    #endregion

    #region private var
    [SerializeField] private int _heath;
    private bool isTakeDamage;
    [SerializeField] private GameObject _splashScreen;
    [SerializeField] private Image heathBar;
    [SerializeField] private UnityEvent onPlayDie;
    [SerializeField] private float _timeToDisActive;
    [SerializeField] private GamePlayScene gamePlayScene;
    [SerializeField] private AudioClip painSound;


    private Color originalColor;
    private Color targetColor;
    private float elapsedTime;
    #endregion
    private void Start()
    {
        gamePlayScene = FindObjectOfType<GamePlayScene>();
        originalColor = _splashScreen.GetComponent<RawImage>().color;
        targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }
    public void TakeDamage(int damage)
    {
        _heath -= damage;
        StartCoroutine(SplashScreenHandle());
        gamePlayScene.PlaySound(painSound);
        SetFillAmountOfHeath();
        if (_heath <= 0)
        {
            onPlayDie?.Invoke();
        }
    }
    private void SetFillAmountOfHeath()
    {
        print($"deacre heath {_heath}");

        float fillAmount = (float)_heath / 100;
        print($"fillamount {fillAmount}");
        heathBar.fillAmount = fillAmount;
    }
    private void HandleIfDead()
    {
        Debug.Log("Player died");
    }
    private void CheckIfDead()
    {
        if (_heath <= 0)
        {
            HandleIfDead();
        }
    }
    private void Update()
    {
        CheckIfDead();
    }
    private void SplashScreenSetActive(bool isActive)
    {
        _splashScreen.SetActive(isActive);
    }
    public IEnumerator SplashScreenHandle()
    {
        elapsedTime += Time.deltaTime;
        var t = Mathf.Clamp01(elapsedTime / _timeToDisActive);
        // t=ResetTValue(t);
        Debug.Log("t value" + t);
        SplashScreenSetActive(true);
        _splashScreen.GetComponent<RawImage>().color = Color.Lerp(originalColor, targetColor, t);
        yield return new WaitForSeconds(_timeToDisActive);
        SplashScreenSetActive(false);

    }
    private float ResetTValue(float t)
    {
        if (t == 1)
        {
            t = 0;
        }
        return t;
    }

}
