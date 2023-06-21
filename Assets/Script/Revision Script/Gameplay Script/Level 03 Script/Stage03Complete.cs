using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
using Score.System;
using MiniGame.Manager;
public class Stage03Complete : MonoBehaviour
{
    //public TaskIsComplete taskIsComplete;
    //public Objectives objectives;

    public GameObject WinCondition;
    //public GameObject LoseCondition;
    //public float DelaySeconds;

    //[SerializeField]
    //bool subtaskComplete;

    [SerializeField]
    Level02GameplayManagerScript MainControl;
    //[SerializeField]
    //ScoreManagerScript MainScore;

    [Header("Stage State")]
    [SerializeField] FireExtinguisherScript _fireExtinguisherScript;
    [SerializeField] ExtinguisherClassesDragAndDrop _extinguisherClassesDragAndDrop;

    public int MissionCount;


    [Header("MissionUpdate")]
    [SerializeField] Stage3Missions _stage3Missions;

    [Header("Update Score")]
    [SerializeField] ScoreManagerScriptStages MainScoreStage;


    // Update is called once per frame
    void Update()
    {
        //CheckCompletion();
    }


   

    public void CheckCompletion()
	{

           if (_fireExtinguisherScript.Completed == true && _extinguisherClassesDragAndDrop.Completed == true)
		    {
                StartCoroutine(DisplayWin());
            MainScoreStage.AddUpTotalScore();
            }
        _stage3Missions.SubTaskSucess();

    }

    public void WinState()
	{
        MainControl.StartGameplay = false;
        //MainScore.ReputationGame = false;
        
    }


    IEnumerator DisplayWin()
    {
        WinState();
        //MainScore.DisableTimer();
        yield return new WaitForSeconds(5f);
        WinCondition.SetActive(true);

    }

}
