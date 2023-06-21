using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
using Score.System;

public class StageComplete : MonoBehaviour
{
    public TaskIsComplete taskIsComplete;
    public Objectives objectives;

    public GameObject WinCondition;
    //public GameObject LoseCondition;
    public float DelaySeconds;

    [SerializeField]
    bool subtaskComplete;

    [SerializeField]
    LevelGameplayManagerScript MainControl;
    //[SerializeField]
   //ScoreManagerScript MainScore;
    [SerializeField]
    bool AdditionalTask;
    public int MissionCount;
    [SerializeField]
    int MaxMissionCount;

    [SerializeField] ScoreManagerScriptStages MainScoreStage;

    // Update is called once per frame
   /* void Update()
    {
        CheckCompletion();
    }*/


   

    public void CheckCompletion()
	{
        if (AdditionalTask == true)
        {
            if (MissionCount == MaxMissionCount)
            {
                subtaskComplete = true;
                MainControl.StartGameplay = false;
                //MainScore.ReputationGame = false;
                //Invoke("WinState", DelaySeconds);
            }

            if (subtaskComplete == true)
            {
                Invoke("WinState", DelaySeconds);
                MainScoreStage.AddUpTotalScore();
            }
        }
        if (AdditionalTask == false)
        {
            if (taskIsComplete.isComplete == true && objectives.isComplete == true)
            {
                subtaskComplete = true;
                MainControl.StartGameplay = false;
               
                //MainScore.ReputationGame = false;
                //Invoke("WinState", DelaySeconds);
            }

            if (subtaskComplete == true)
            {
                Invoke("WinState", DelaySeconds);
                MainScoreStage.AddUpTotalScore();
            }
        }
           
	}

    void WinState()
	{
        WinCondition.SetActive(true);
        
    }

}
