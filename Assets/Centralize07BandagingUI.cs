using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LegCravatMiniTask;
using GameplayManager.Level;

public class Centralize07BandagingUI : MonoBehaviour
{
    [SerializeField] LevelGameplayManagerScript MainLevel07;
    [SerializeField] float Timer; // counter
    [SerializeField] float Timer2;
    [SerializeField] float Timer3;
    [SerializeField] float OtherTimer;

    [SerializeField] float MaxTimer;
    [SerializeField] Color newColor;
    [SerializeField] bool Task1;
    [SerializeField] bool Task2;
    [SerializeField] bool Task3;
    [Header("Task 01 Hip")]
    [SerializeField] Image MainImage;
    [SerializeField] Slider slider;
    [SerializeField] LegCravatStepsController HipIsComplete;

    [Header("Task 02 TopOfTheHead")]
    [SerializeField] Image MainImage2;
    [SerializeField] Slider slider2;
    [SerializeField] TopOfTheHeadBandaging TopOfTheHeadIsComplete;

    [Header("Task 03 SlingArm")]
    [SerializeField] Image MainImage3;
    [SerializeField] Slider slider3;
    [SerializeField] SlingArmAnimationController SlingArmIsComplete;


    [Header("Other")]
    [SerializeField] Slider[] otherslider;
    

    public void Start()
	{
        //slider.maxValue = MaxTimer;
        //slider.minValue = 0;

    }

	public void Update()
	{
        HealthBarStartUI();

    }
	public void HealthBarStartUI()
    {
        if (MainLevel07.StartGameplay == true)
        {
            if (Task1 == false)
            {
                if (HipIsComplete.IsSuccess == false)
                {
                    if (Timer < MaxTimer)
                    {
                        slider.value = Timer / MaxTimer;
                        Timer += Time.deltaTime;
                    } // else lose condition
                }
                else if (HipIsComplete.IsSuccess == true)
                {
                    if (Timer > 0)
                    {
                        MainImage.color = newColor;
                        slider.value = Timer / MaxTimer;
                        Timer -= Time.deltaTime;
                    }

                    else
                    {
                        Task1 = true;
                    }
                }
            }
            if (Task2 == false)
            {
                if (TopOfTheHeadIsComplete.isSuccess == false)
                {
                    if (Timer2 < MaxTimer)
                    {
                        slider2.value = Timer2 / MaxTimer;
                        Timer2 += Time.deltaTime;
                    } // else lose condition
                }
                else if (TopOfTheHeadIsComplete.isSuccess == true)
                {
                    if (Timer2 > 0)
                    {
                        MainImage2.color = newColor;
                        slider2.value = Timer2 / MaxTimer;
                        Timer2 -= Time.deltaTime;
                    }

                    else
                    {
                        Task2 = true;
                    }
                }
            }
            if (Task3 == false)
            {
                if (SlingArmIsComplete.isSuccess == false)
                {
                    if (Timer3 < MaxTimer)
                    {
                        slider3.value = Timer3 / MaxTimer;
                        Timer3 += Time.deltaTime;
                    } // else lose condition
                }
                else if (SlingArmIsComplete.isSuccess == true)
                {
                    if (Timer3 > 0)
                    {
                        MainImage3.color = newColor;
                        slider3.value = Timer3 / MaxTimer;
                        Timer3 -= Time.deltaTime;
                    }

                    else
                    {
                        Task3 = true;
                    }
                }
            }


            if (OtherTimer < MaxTimer)
            {

                OtherTimer += Time.deltaTime;

                foreach (Slider sliderother in otherslider)
                {
                    sliderother.value = OtherTimer / MaxTimer;
                }
            }
            


        }
    }
}
