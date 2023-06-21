using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
using Score.System;

public class Stage02Complete : MonoBehaviour
{
    //public TaskIsComplete taskIsComplete;
    //public Objectives objectives;

    public GameObject WinCondition;
    //public GameObject LoseCondition;
    public float DelaySeconds;

    [SerializeField]
    bool subtaskComplete;

    [SerializeField]
    Level02GameplayManagerScript MainControl;
    /*[SerializeField]
    ScoreManagerScript MainScore;*/
    //[SerializeField] ScoreManagerScript MainScoreStage;
    [SerializeField] ScoreManagerScriptStages MainScoreStage;


    public int MissionCount;
    public SubTasksIsSuccess _subTasksIsSuccess;

    // Update is called once per frame
    /*void Update()
    {
        CheckCompletion();
    }*/


   

    public void CheckCompletion()
	    {
            //if (taskIsComplete.isComplete == true && objectives.isComplete == true)
            if (MissionCount >=3)
		    {
            subtaskComplete = true;
            MainControl.StartGameplay = false;
            //MainScore.ReputationGame = false;
            MainScoreStage.AddUpTotalScore();
            //Invoke("WinState", DelaySeconds);
        }

           /*if (subtaskComplete == true)
            {
            Invoke("WinState", DelaySeconds);
            }*/

            if (_subTasksIsSuccess.MiniTask1Complete &&
                _subTasksIsSuccess.MiniTask2Complete &&
                _subTasksIsSuccess.MiniTask3Complete )
		        {
                    subtaskComplete = true;
                    MainControl.StartGameplay = false;
                    MainScoreStage.AddUpTotalScore();
                    //MainScore.ReputationGame = false;
                }

            if (subtaskComplete == true)
            {
                Invoke("WinState", DelaySeconds);
                MainControl.StartGameplay = false;
                MainScoreStage.AddUpTotalScore();
                //MainScore.ReputationGame = false;

            }

    }

    void WinState()
	{
        WinCondition.SetActive(true);
    }

}
