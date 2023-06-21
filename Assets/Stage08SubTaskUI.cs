using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;
using Score.System;
using Flooding;
public class Stage08SubTaskUI : MonoBehaviour
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


	//3 Plug
	[Header("Plugging Electricical Devices")]
	[SerializeField] bool MN3_1_2_Done;
	
	public TMPro.TextMeshProUGUI MN3_txt;
	public TMPro.TextMeshProUGUI MN3_count;

	[Header("Phone")]
	[SerializeField] bool mn3_1_isComplete;
	[SerializeField] TaskCompleteCargingPhone T3_CompleteScript_1;

	[Header("FlashLight")]
	[SerializeField] bool mn3_2_isComplete;
	[SerializeField] TaskCompleteCargingPhone T3_CompleteScript_2;

	//Flooding
	[Header("Identify Flooding")]
	[SerializeField] bool mn4_isComplete;
	[SerializeField] CheckAnswerFloodingCauses T4_CompleteScript;
	public TMPro.TextMeshProUGUI MN4_txt;
	public TMPro.TextMeshProUGUI MN4_count;
	[SerializeField] bool M4Done;

	//Drainage
	[Header("Drinaige")]
	[SerializeField] bool mn5_isComplete;
	[SerializeField] TaskCompleteDrainage T5_CompleteScript;
	public TMPro.TextMeshProUGUI MN5_txt;
	public TMPro.TextMeshProUGUI MN5_count;
	[SerializeField] bool M5Done;


	public void StageUpdateMissionStat()
	{
		if (StageComplete == false)
		{
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
					M2Done = true;
					
				}
			}
			//Task3
			if (MN3_1_2_Done == false)
			{
				//check completion
				Debug.Log("a");
					if (T3_CompleteScript_1.TaskIsDone == true)
					{
						mn3_1_isComplete = true;
						Task3UpdateUI();
					Debug.Log("b");
					}
	
					if (T3_CompleteScript_2.TaskIsDone == true)
					{
						mn3_2_isComplete = true;
						Task3UpdateUI();
					}
			}
			if (M4Done == false)
			{
				if (T4_CompleteScript.TaskComplete == true)
				{
					mn4_isComplete = true;
					MN4_txt.color = new Color32(0, 0, 0, 90);// lower opacity
					MN4_count.text = "1/1";
					MN4_count.color = new Color32(0, 0, 0, 90);// lower opacity
					M4Done = true;
					
				}
			}
			if (M5Done == false)
			{
				if (T5_CompleteScript.TaskIsDone == true)
				{
					mn5_isComplete = true;
					MN5_txt.color = new Color32(0, 0, 0, 90);// lower opacity
					MN5_count.text = "1/1";
					MN5_count.color = new Color32(0, 0, 0, 90);// lower opacity
					M5Done = true;
					
				}
			}

			CheckAllTaskCompletion();
		}
	}


	public void Task3UpdateUI()
	{
		if (((mn3_1_isComplete == true) && (mn3_2_isComplete == false))
				|| ((mn3_1_isComplete == false) && (mn3_2_isComplete == true)))
				
		{
			MN3_count.text = "1/2";
			
		}
		
		if ((mn3_1_isComplete == true) && (mn3_2_isComplete == true))
		{

			MN3_txt.color = new Color32(0, 0, 0, 90);// lower opacity
			MN3_count.text = "2/2";
			MN3_count.color = new Color32(0, 0, 0, 90);// lower opacity
													   //Debug.Log("33333");
			MN3_1_2_Done = true;
		}
	}

	public void CheckAllTaskCompletion()
	{
		if (StageComplete_Done == false)
		{
			if ((M1Done == true) && (M2Done == true) && (MN3_1_2_Done == true) && (M4Done == true) && (M5Done == true))
			{
				Invoke("StageIsComplete", DelaySecs );
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
