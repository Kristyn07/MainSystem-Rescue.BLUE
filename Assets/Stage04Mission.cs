using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LegCravatMiniTask;
using GameplayManager.Level;
using Score.System;

public class Stage04Mission : MonoBehaviour
{

    [SerializeField]
    bool Stage04_Complete;

    [Header("Task1")]
    public TMPro.TextMeshProUGUI MN1_txt;
    public TMPro.TextMeshProUGUI MN1_count;
    [SerializeField]
    bool mn1_isComplete;
    public Objectives _objectives;



    [Header("Task2")]
    public TMPro.TextMeshProUGUI MN2_txt;
    public TMPro.TextMeshProUGUI MN2_count;
    [SerializeField]
    bool mn2_isComplete;
    public FireExtinguisher.Animation.FireExtinguisherAnimationScript _fireExtinguisherAnimationScript;

    [Header("Task3")]
    public TMPro.TextMeshProUGUI MN3_txt;
    public TMPro.TextMeshProUGUI MN3_count;
    [SerializeField]
    bool mn3_isComplete;
    [SerializeField] LegCravatStepsController _legCravatStepsController;
    [SerializeField] BoxCollider2D PalmCravatCol;
    [SerializeField] BoxCollider2D FirstAidKit;
    [SerializeField] BoxCollider2D FireExtinguisher;
    [Header("WinCollection")]

    //All Task MissionComplete
    [SerializeField] bool StageComplete;
    [SerializeField] bool StageComplete_Done;
    [SerializeField] GameObject WinStatePanel;
    [SerializeField] float DelaySecs = 3f;
    [Header("Stage Complete Method/Scripts")]
    [SerializeField] LevelGameplayManagerScript MainLevel;
    [SerializeField] ScoreManagerScriptStages MainScoreStage;


    // Update is called once per frame
    public void Check_Update()
    {
        SubTaskCheckComplition();
    }

    void SubTaskCheckComplition()
    {
        //Task1
        if (_objectives.isComplete == true)
        {
            mn1_isComplete = true;
            MN1_txt.color = new Color32(0, 0, 0, 90);// lower opacity
            MN1_count.text = "1/1";
            MN1_count.color = new Color32(0, 0, 0, 90);// lower opacity
            FirstAidKit.enabled = false;
        }
        //Task2
        if (_fireExtinguisherAnimationScript.TaskIsDone == true)
        {
            mn2_isComplete = true;
            MN2_txt.color = new Color32(0, 0, 0, 90);// lower opacity
            MN2_count.text = "1/1";
            MN2_count.color = new Color32(0, 0, 0, 90);// lower opacity
            FireExtinguisher.enabled = false;
        }
        //Task3
        if (_legCravatStepsController.IsSuccess == true)
        {
            mn3_isComplete = true;
            MN3_txt.color = new Color32(0, 0, 0, 90);// lower opacity
            MN3_count.text = "1/1";
            MN3_count.color = new Color32(0, 0, 0, 90);// lower opacity
            PalmCravatCol.enabled = false;
        }

        CheckAllTaskCompletion();
    }

    public void CheckAllTaskCompletion()
    {
        if (StageComplete_Done == false)
        {
            if (mn1_isComplete == true && mn2_isComplete == true && mn3_isComplete == true)
            {
                Invoke("StageIsComplete", DelaySecs);
                MainLevel.StartGameplay = false;
                //send score to playerprefs if online send to leaderboard also
                MainScoreStage.AddUpTotalScore();
                StageComplete_Done = true;
                StageComplete = true;

            }
        }
    }

    public void StageIsComplete()
    {
        WinStatePanel.SetActive(true);
        Stage04_Complete = true;
    }

}

