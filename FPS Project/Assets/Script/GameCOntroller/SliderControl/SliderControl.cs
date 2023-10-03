using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    [SerializeField] private Text sliderTxt;
    [SerializeField] private Slider slider;
    [SerializeField] private float defaultSensitive;
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(SetSliderText);
        SetDefaultSliderValue();
    }
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetSliderText(float sliderValue)
    {
        sliderTxt.text = (sliderValue / 10).ToString();
    }
    public void SetDefaultSliderValue()
    {
        slider.value = defaultSensitive;
        SetSliderText(slider.value);
    }
}
