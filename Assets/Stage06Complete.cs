using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using GameplayManager.Level;

public class Stage06Complete : MonoBehaviour
{
    public GameObject WinCondition;
    [SerializeField]
    LevelGameplayManagerScript levelGameplayManagerScript;
    [SerializeField]
    CentralizeLevel06GameplayManagerScript MainControl;
    //[SerializeField]
    //ScoreManagerScript MainScore;
    //[SerializeField] Mission05ControlScript _mission05ControlScript;
    [SerializeField] TriggerStageDone _triggerStageDone;
    [SerializeField] ScoreManagerScriptStages MainScoreStages;



    // Update is called once per frame
    public void Check_Update()
    {
        CheckCompletion();
    }




    public void CheckCompletion()
    {

        if (_triggerStageDone.StageIsDone)
        {
            StartCoroutine(DisplayWin());
            MainScoreStages.AddUpTotalScore();
        }


    }

    

    IEnumerator DisplayWin()
    {
        
        //MainScore.DisableTimer();
        yield return new WaitForSeconds(5f);
        WinCondition.SetActive(true);
        
    }

}


