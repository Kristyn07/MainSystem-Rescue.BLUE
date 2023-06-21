using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX_SliderContoller : MonoBehaviour
{
    public Slider sliderSFX;
    public float sliderValueSFX;
    


    public void Start()
    {
        sliderValueSFX = PlayerPrefs.GetFloat("save_SFX_Value");
        sliderSFX.value = sliderValueSFX;
        //sliderSFX_pause.value = sliderValueSFX;

    }

    public void Update()
    {

        PlayerPrefs.SetFloat("save_SFX_Value", sliderValueSFX);
        

    }

    public void ChangeSlider(float value)
    {
        sliderValueSFX = value;
    }

  
}
