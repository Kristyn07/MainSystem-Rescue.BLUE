using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM_SliderContoller : MonoBehaviour
{
    [Tooltip ("Slider in Mainmenu")]
    public Slider sliderBGM;
    //[Tooltip("Slider in Gameplay")]
    //public Slider sliderBGM_pause;

    public float sliderValueBGM;

	

	public void Start()
    {
        sliderValueBGM = PlayerPrefs.GetFloat("save_BGM_Value");
        sliderBGM.value = sliderValueBGM;
        //sliderBGM_pause.value = sliderValueBGM;

    }

    public void Update()
    {
        
        PlayerPrefs.SetFloat("save_BGM_Value", sliderValueBGM);
    }

    public void ChangeSlider(float value)
	{
        sliderValueBGM = value;

    }
}
