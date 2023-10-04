using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : SSController
{
    [SerializeField] private RectTransform loadingRect;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float loadTime;

    private new void Start()
    {
        StartCoroutine(LoadHomeScene());
    }
    private void Update()
    {
        RotateLoading();
    }
    private void RotateLoading()
    {
        loadingRect.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
    }
    private IEnumerator LoadHomeScene()
    {
        yield return new WaitForSeconds(loadTime);
        print("Load home");
        SSSceneManager.Instance.PopUp("HomeScene");
    }
}
