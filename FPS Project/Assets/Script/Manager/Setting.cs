using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject creditUI;
    [SerializeField] private GameObject settingUI;
    [SerializeField] private GameObject ratingUI;
    [SerializeField] private RectTransform ratingRect;
    [SerializeField] private float random;
    [SerializeField] private float transitionPointDown;
    [SerializeField] private float transitionPointUp;



    // Start is called before the first frame update
    void Start()
    {
        ratingRect = ratingUI.GetComponent<RectTransform>();
        SetActiveRandomRating();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void SetActiveRandomRating()
    {
        var randomNB = Random.value;
        random = randomNB;
        if (randomNB <= 0.5f)
        {
            SetActiveRatingUI(true);
        }
    }
    public void SetActiveRatingUI(bool set)
    {
        switch (set)
        {
            case true:
                {
                    ratingUI.GetComponent<RectTransform>().DOMoveY(transitionPointDown, 0.5f);
                    ratingUI.SetActive(set);
                }
                break;
            case false:
                {
                    ratingUI.GetComponent<RectTransform>().DOMoveY(transitionPointUp, 0.7f);
                    StartCoroutine(RatingClose(0.7f, ratingUI));
                }
                break;

        }
    }
    private IEnumerator RatingClose(float time, GameObject ratingPanel)
    {
        yield return new WaitForSeconds(time);
        ratingPanel.SetActive(false);
    }
    public void SetActiveCredit(bool set)
    {
        creditUI.SetActive(set);
    }
    public void SetActiveSetting(bool set)
    {
        settingUI.SetActive(set);
    }
}
