using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ReputationBarTextUpdate : MonoBehaviour
{
    [SerializeField] Slider ReputationBar;
    [SerializeField] Text ReputationSliderValue;
    [SerializeField] float SliderValue;
    [SerializeField] int Value;

    public bool ChangeToHealthBar;
    void Update()
    {
        if (ChangeToHealthBar)
		{
            SliderValue = ReputationBar.value;
            Value = Convert.ToInt32(SliderValue);
            ReputationSliderValue.text = Value.ToString();
        }
		else
		{
            SliderValue = ReputationBar.value * 100;
            Value = Convert.ToInt32(SliderValue);
            ReputationSliderValue.text = Value.ToString();
		}
        
    }
}
