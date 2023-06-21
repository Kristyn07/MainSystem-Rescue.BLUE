using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Score.System;
using GameplayManager.Level;

public class Objectives : MonoBehaviour
{
    [SerializeField] LevelGameplayManagerScript MainLevel;
    [SerializeField] int TaskCount;

    public GameObject obj;
    public bool isComplete;
    [SerializeField]
    Button InspectButton;
    [SerializeField]
    Canvas PlayerCanvas;
    [SerializeField]
    Canvas MiniGameCanvas;
    //[SerializeField]
    //ScoreManagerScript MainScore;

    [SerializeField]
    bool AdditionalTask;

    [Header("Stage 4")]
    [SerializeField]
    bool Stage04;
    CentralizeLevel04GameplayManagerScript MainLevel04;
    /*[SerializeField] GameObject CompleteAnimation;
    [SerializeField] Animator CompletedAnimation;*/

    [Header("Stage 5")]
    [SerializeField] bool Stage05;
    [SerializeField] CentralizeLevel05GameplayManagerScript MainLevel05;

    [Header("Stage 5")]
    [SerializeField] bool Stage06;
    [SerializeField] CentralizeLevel06GameplayManagerScript MainLevel06;

    [Header("Stage 8")]
    [SerializeField] bool Stage08;
    [SerializeField] CentralizeLevel08GameplayManagerScript CentralizeStage08;
    [Header("Stage 10")]
    [SerializeField] bool Stage10;
    [SerializeField] CentralizeLevel10GamePlayManagerScript CentralizeStage10;

    [Header("Instructions")]
    [SerializeField] DissableInstructionWhenTaskComplete _disableInstruction;

    
    public void AutoComplete()
    {
        Debug.Log("Test Objective autocompleted.");

        //MainScore.DisableTimer();
        InspectButton.interactable = false;
        isComplete = true;

        if (isComplete == true)
        {
            //HideInspectMission();
            //PlayerCanvas.enabled = true;
            //MiniGameCanvas.enabled = false;
            if (AdditionalTask == true)
            {
                if (Stage04 == true)
                {
                    MainLevel04 = GameObject.FindObjectOfType<CentralizeLevel04GameplayManagerScript>();
                    MainLevel04.FinishStage();
                }
                if (Stage05 == true)
                {
                    MainLevel05 = GameObject.FindObjectOfType<CentralizeLevel05GameplayManagerScript>();
                    MainLevel05.FinishStage();
                    _disableInstruction.DisableInstruction();
                }
                if (Stage06 == true)
                {
                    MainLevel06 = GameObject.FindObjectOfType<CentralizeLevel06GameplayManagerScript>();
                    MainLevel06.FinishStage();
                    _disableInstruction.DisableInstruction();
                }
                if (Stage08 == true)
                {
                    //CentralizeStage08 = GameObject.FindObjectOfType<CentralizeLevel08GameplayManagerScript>();
                    CentralizeStage08.MissionCol[TaskCount].enabled = false;
                    MainLevel.PopUpMission[TaskCount].SetActive(false);
                    //CentralizeStage08.FinishStage();
                    _disableInstruction.DisableInstruction();

                }
                if (Stage10 == true)
                {
                    //CentralizeStage08 = GameObject.FindObjectOfType<CentralizeLevel08GameplayManagerScript>();
                    //MainLevel10 = GameObject.FindObjectOfType<CentralizeLevel10GamePlayManagerScript>();
                    CentralizeStage10.MissionCol[TaskCount].enabled = false;
                    MainLevel.PopUpMission[TaskCount].SetActive(false);
                    //CentralizeStage08.FinishStage();
                    _disableInstruction.DisableInstruction();

                }

            }

            if (Stage08 == true)
            {
                //CentralizeStage08 = GameObject.FindObjectOfType<CentralizeLevel08GameplayManagerScript>();
                CentralizeStage08.MissionCol[TaskCount].enabled = false;
                MainLevel.PopUpMission[TaskCount].SetActive(false);
                _disableInstruction.DisableInstruction();

               
            }
            if (Stage10 == true)
            {
                //CentralizeStage08 = GameObject.FindObjectOfType<CentralizeLevel08GameplayManagerScript>();
                CentralizeStage10.MissionCol[TaskCount].enabled = false;
                MainLevel.PopUpMission[TaskCount].SetActive(false);
                //CentralizeStage08.FinishStage();
                _disableInstruction.DisableInstruction();

            }
        }

        
    }
}
