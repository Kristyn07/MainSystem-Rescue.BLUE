using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LegCravatMiniTask;
using GameplayManager.Level;
using Score.System;

public class Stage07Mission : MonoBehaviour
{
	//All Task MissionComplete
	[SerializeField] bool StageComplete;
	[SerializeField] bool StageComplete_Done;
	[SerializeField] GameObject WinStatePanel;
	[SerializeField] float DelaySecs = 3f;
	[Header("Stage Complete Method/Scripts")]
	[SerializeField] LevelGameplayManagerScript MainLevel;
	[SerializeField] ScoreManagerScriptStages MainScoreStage;
	
	//first aid kit 
	[Header("First Aid Kit")]
	[SerializeField] bool mn1_isComplete;
	[SerializeField] Objectives T1IsCompleteScript;
	public TMPro.TextMeshProUGUI MN1_txt;
	public TMPro.TextMeshProUGUI MN1_count;
	[SerializeField] bool M1Done;

	//emergency kit
	[Header("Emergency Kit")]
	[SerializeField] bool mn2_isComplete;
	[SerializeField] Objectives T2IsCompleteScript;
	public TMPro.TextMeshProUGUI MN2_txt;
	public TMPro.TextMeshProUGUI MN2_count;
	[SerializeField] bool M2Done;


	//3 bandaging
	[Header("Bandaging")]
	[SerializeField] bool MN3_1_2_3_Done;
	public TMPro.TextMeshProUGUI MN3_txt;
	public TMPro.TextMeshProUGUI MN3_count;

	[Header("Hip Cravat")]
	[SerializeField] LegCravatStepsController T3_1CompleteScript;
	[SerializeField] bool MN3_1Done;
	
	[Header("Top Of The Head")]
	[SerializeField] TopOfTheHeadBandaging T3_2CompleteScript;
	[SerializeField] bool MN3_2Done;

	[Header("Sling Arm")]
	[SerializeField] SlingArmAnimationController T3_3CompleteScript;
	[SerializeField] bool MN3_3Done;

	//DCH
	[Header("Drop Cover Hold")]
	[SerializeField] bool mn4_isComplete;
	[SerializeField] DropCoverHoldTriggerTaskIsComplete T4IsCompleteScript;
	public TMPro.TextMeshProUGUI MN4_txt;
	public TMPro.TextMeshProUGUI MN4_count;
	[SerializeField] bool MN4_Done;

	[Header("Colliders")]
	[SerializeField] BoxCollider2D FirstAid;
	[SerializeField] BoxCollider2D EmergencyKit;
	[SerializeField] BoxCollider2D DCH;
	public void Check_Update()
	{
		if (StageComplete == false) {
			//Check Task Completion
			
			//Task1
			if (M1Done == false) 
			{
				if (T1IsCompleteScript.isComplete == true)
				{
					mn1_isComplete = true;
					MN1_txt.color = new Color32(0, 0, 0, 90);// lower opacity
					MN1_count.text = "1/1";
					MN1_count.color = new Color32(0, 0, 0, 90);// lower opacity
					FirstAid.enabled = false;
					M1Done = true;
				}
			}
			//Task2
			if (M2Done == false)
			{
				if (T2IsCompleteScript.isComplete == true)
				{
					mn2_isComplete = true;
					MN2_txt.color = new Color32(0, 0, 0, 90);// lower opacity
					MN2_count.text = "1/1";
					MN2_count.color = new Color32(0, 0, 0, 90);// lower opacity
					EmergencyKit.enabled = false;
					M2Done = true;
				}

			}

			if (MN3_1Done == false)
			{
				if (((T3_1CompleteScript.IsSuccess == true) && (T3_2CompleteScript.isSuccess == false) && (T3_3CompleteScript.isSuccess == false))
				|| ((T3_1CompleteScript.IsSuccess == false) && (T3_2CompleteScript.isSuccess == true) && (T3_3CompleteScript.isSuccess == false))
				|| ((T3_1CompleteScript.IsSuccess == false) && (T3_2CompleteScript.isSuccess == false) && (T3_3CompleteScript.isSuccess == true)))
				{
					MN3_count.text = "1/3";
					//Debug.Log("1111");
				}
				if (((T3_1CompleteScript.IsSuccess == true) && (T3_2CompleteScript.isSuccess == true) && (T3_3CompleteScript.isSuccess == false))
					|| ((T3_1CompleteScript.IsSuccess == true) && (T3_2CompleteScript.isSuccess == false) && (T3_3CompleteScript.isSuccess == true))
					|| ((T3_1CompleteScript.IsSuccess == false) && (T3_2CompleteScript.isSuccess == true) && (T3_3CompleteScript.isSuccess == true)))
				{
					MN3_count.text = "2/3";
					//Debug.Log("22222");
				}
				if ((T3_1CompleteScript.IsSuccess == true) && (T3_2CompleteScript.isSuccess == true) && (T3_3CompleteScript.isSuccess == true))
				{

					MN3_txt.color = new Color32(0, 0, 0, 90);// lower opacity
					MN3_count.text = "3/3";
					MN3_count.color = new Color32(0, 0, 0, 90);// lower opacity
															   //Debug.Log("33333");
					MN3_1_2_3_Done = true;
				}
			}
			
			//Task4
			if (MN4_Done == false)
			{
				if (T4IsCompleteScript.IsComplete == true)
				{
					mn4_isComplete = true;
					MN4_txt.color = new Color32(0, 0, 0, 90);// lower opacity
					MN4_count.text = "1/1";
					MN4_count.color = new Color32(0, 0, 0, 90);// lower opacity
					DCH.enabled = false;
					MN4_Done = true;
				}
			}
			CheckAllTaskCompletion();
		}
	}



	public void CheckAllTaskCompletion()
	{
		if (StageComplete_Done == false) { 
			if ((M1Done == true) && (M2Done == true) && (MN3_1_2_3_Done == true) && (MN4_Done == true))
			{
				Invoke("StageIsComplete", DelaySecs);
				//dissable reputation bar
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
	}
}
