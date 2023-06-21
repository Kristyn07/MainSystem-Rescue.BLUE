using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Score.System;
using GameplayManager.Level;

public class TaskIsComplete : MonoBehaviour // this is for bandaging minigame check completion
{
    public StepByStepBandaging _stepByStepBandaging;
    public bool isComplete = false;
    public GameObject currentWindow;
    public GameObject OverWorldCanvas;
    [SerializeField]
    Button InspectButton;
    [SerializeField]
    Canvas PlayerCanvas;
    [SerializeField]
    Canvas MiniGameCanvas;
    //[SerializeField]
    //ScoreManagerScript MainScore;
    
    [SerializeField]
    bool Stage01;

    [SerializeField]
    bool Stage02;

    [Header("Stage 04 Bandaging ")]
    [SerializeField]
    bool Stage04;
    [SerializeField] CentralizeLevel04GameplayManagerScript Level04Main;

    [SerializeField]
    Stage02Complete Stage02Main;
    bool IncreaseCount;
    [SerializeField]
    BoxCollider2D Col;

    [SerializeField] GameObject CompleteAnim;
    [SerializeField] float DelaySec;

    [Header("Stage05")]
    [SerializeField] bool Stage05;
    [SerializeField] CentralizeLevel05GameplayManagerScript _centralizeLevel05Gameplay;

    bool methodCalled = false;
    /*private void Update()
	{
        Completed();
    }*/
	public void Completed()
	{
        var completeAnim = CompleteAnim.GetComponent<Animator>();

        if (Stage01 == true)
        {
            if (_stepByStepBandaging.isSuccess == true)
            {
                CompleteAnim.SetActive(true);
                isComplete = true;
                //completeAnim.SetBool("Completed", true);
                /*if (completeAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    //InspectButton.interactable = false;
                    CompleteAnim.SetActive(false);
                    //PlayerCanvas.enabled = true;
                    //completeAnim.SetBool("Completed", false);
                    //currentWindow.SetActive(false);
                   
                    Debug.Log("not playing");
                }
				else
				{*/
                    
                    //MainScore.DisableTimer();
                //Debug.Log("playing");
                //}
                Invoke("CloseWindow", DelaySec);


            }
        }
       
        if (Stage02 == true)
        {

            /*if (_stepByStepBandaging.isSuccess == true)
            {
                
            //Stage02CountMission += 1;
                OverWorldCanvas.SetActive(true);
                MainScore.DisableTimer();
                PlayerCanvas.enabled = true;
                
                Col.enabled = false;
                //isComplete = true;

                if (currentWindow.activeSelf == true)
                {
                    IncreaseStage02Count();
                }
                currentWindow.SetActive(false);
            }*/


            if (_stepByStepBandaging.isSuccess == true)
            {
                CompleteAnim.SetActive(true);
                isComplete = true;
                
                //completeAnim.SetBool("Completed", true);
                /*if (completeAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    //InspectButton.interactable = false;
                    CompleteAnim.SetActive(false);
                    //PlayerCanvas.enabled = true;
                    //completeAnim.SetBool("Completed", false);
                    //currentWindow.SetActive(false);
                   
                    Debug.Log("not playing");
                }
				else
				{*/

                //MainScore.DisableTimer();
                //Debug.Log("playing");
                //}
                //Invoke("CloseWindow", DelaySec);


            }
        }

        if (Stage04 == true)
        {
            if (_stepByStepBandaging.isSuccess == true)
            {
                CompleteAnim.SetActive(true);
                isComplete = true;
                //MainScore.DisableTimer();
                Invoke("CloseWindow", DelaySec);
                Invoke("MethodToCallOnce", DelaySec);

            }
        }

        if(Stage05 == true)
		{
           /* if (_mission05Control.StageComplete == true)
			{
                CompleteAnim.SetActive(true);
                isComplete = true;
                MainScore.DisableTimer();
                Invoke("CloseWindow", DelaySec);
                Invoke("MethodToCallOnce", DelaySec);
            }*/
		}



    }


    public void CloseWindow()
    {
        currentWindow.SetActive(false);
        Debug.Log("CloseWindow");
        PlayerCanvas.enabled = true;
        OverWorldCanvas.SetActive(true);
        InspectButton.interactable = false;
        MiniGameCanvas.enabled = false;
        //Level04Main.FinishStage();


    }

    public void DelayCompleteAnim()// for some reason
	{
        CompleteAnim.SetActive(true);
    }


    void IncreaseStage02Count()
    {
        Stage02Main.MissionCount += 1;
    }

    void MethodToCallOnce()
    {
        if (methodCalled) return;
        methodCalled = true;
        Level04Main.FinishStage();
        // Method code here
    }
}
