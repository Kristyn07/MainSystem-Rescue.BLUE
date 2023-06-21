using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using GameplayManager.Level;

public class Stage05Complete : MonoBehaviour
{
    public GameObject WinCondition;
    //public GameObject LoseCondition;
    //public float DelaySeconds;

    //[SerializeField]
    //bool subtaskComplete;
    [SerializeField]
    LevelGameplayManagerScript levelGameplayManagerScript;
    [SerializeField]
    CentralizeLevel05GameplayManagerScript MainControl;
    //[SerializeField]
    //ScoreManagerScript MainScore;
    [SerializeField] Mission05ControlScript _mission05ControlScript;
    [SerializeField] ScoreManagerScriptStages MainScoreStages;
    


    // Update is called once per frame
    void Update()
    {
        CheckCompletion();
    }




    public void CheckCompletion()
    {

        if (_mission05ControlScript.StageComplete)
        {
            MainScoreStages.AddUpTotalScore();
            StartCoroutine(DisplayWin());
        }
       

    }

    public void WinState()
    {
        levelGameplayManagerScript.StartGameplay = false;
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


