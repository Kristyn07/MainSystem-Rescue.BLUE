using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;
using Score.System;
using Flooding;
using FireExtinguisher.Animation;

public class Stage10SubsTask : MonoBehaviour
{
	//All Task MissionComplete
	[SerializeField] bool StageComplete;
	[SerializeField] bool StageComplete_Done;
	[SerializeField] GameObject WinStatePanel;
	[SerializeField] float DelaySecs = 3f;
	[Header("Stage Complete Method/Scripts")]
	[SerializeField] LevelGameplayManagerScript MainLevel;
	[SerializeField] ScoreManagerScriptStages MainScoreStage;

	[Header("Puzzle")]
	[SerializeField] bool DoneT1;
	[SerializeField] bool Task1;
	[SerializeField] bool Task1_1;
	[SerializeField] Objectives _T1_MNFirstAidComplete;
	[SerializeField] Objectives _T2_MNFirstAidComplete;
	[Header("FirstAidKit_TMP")]
	public TMPro.TextMeshProUGUI FirstAidKitTxt;
	public TMPro.TextMeshProUGUI FirstAidKitCount;


	[Header("Bandage")]
	[SerializeField] bool DoneT2;
	[SerializeField] bool Task2;
	[SerializeField] bool Task2_1;
	[SerializeField] CravatNarrowFolding _cravatNarrowFolding;
	[SerializeField] StepByStepBandaging _stepByStepBandaging;
	[Header("Bandage")]
	public TMPro.TextMeshProUGUI Task2T;
	public TMPro.TextMeshProUGUI Task2C;


	[Header("Flood")]
	[SerializeField] bool DoneT3;
	[SerializeField] bool Task3;
	[SerializeField] bool Task3_1;
	[SerializeField] TaskCompleteDrainage _taskCompleteDrainage;
	[SerializeField] CheckAnswerFloodingCauses _checkAnswerFloodingCauses;
	[Header("Flood")]
	public TMPro.TextMeshProUGUI Task3T;
	public TMPro.TextMeshProUGUI Task3C;

	[Header("Fire")]
	[SerializeField] bool DoneT4;
	[SerializeField] bool Task4;
	[SerializeField] bool Task4_1;
	[SerializeField] FireExtinguisherAnimationScript _fireExtinguisherAnimationScript;
	[SerializeField] ExtinguisherClassesDragAndDrop _extinguisherClassesDragAndDrops;
	[Header("Fire")]
	public TMPro.TextMeshProUGUI Task4T;
	public TMPro.TextMeshProUGUI Task4C;
	[SerializeField] GameObject ForeOW;

	[Header("DCH")]
	[SerializeField] bool DoneT5;
	[SerializeField] bool Task5;
	[SerializeField] DropCoverHoldTriggerTaskIsComplete _dropCoverHoldTriggerTaskIsComplete;
	[Header("DCH")]
	public TMPro.TextMeshProUGUI Task5T;
	public TMPro.TextMeshProUGUI Task5C;

	[Header("Col")]
	[SerializeField] BoxCollider2D T1_1;
	[SerializeField] BoxCollider2D T1_2;
	[SerializeField] BoxCollider2D T2_1;
	[SerializeField] BoxCollider2D T2_2;
	[SerializeField] BoxCollider2D T3_1;
	[SerializeField] BoxCollider2D T3_2;
	[SerializeField] BoxCollider2D T4_1;
	[SerializeField] BoxCollider2D T4_2;
	[SerializeField] BoxCollider2D T5_1;
	[SerializeField] BoxCollider2D DCH;
	//[SerializeField] GameObject Fire;
	public void Check_Update()
	{
		//task 1
		if (DoneT1 == false)
		{
			if (_T1_MNFirstAidComplete.isComplete ^ _T2_MNFirstAidComplete.isComplete == true)
			{
				FirstAidKitCount.text = "1/2";
				if (_T1_MNFirstAidComplete.isComplete == true)
				{
					Task1 = true;
					
					T1_1.enabled = false;
					DCH.enabled = true;

				}
				else if (_T2_MNFirstAidComplete.isComplete == true)
				{
					Task1_1 = true;
					T1_2.enabled = false;
					DCH.enabled = true;
				}
			}
			else if ((_T1_MNFirstAidComplete.isComplete == true) && (_T2_MNFirstAidComplete.isComplete == true))
			{
				Task1 = true;
				Task1_1 = true;
				T1_1.enabled = false;
				T1_2.enabled = false;
				FirstAidKitTxt.color = new Color32(0, 0, 0, 90);// lower opacity
				FirstAidKitCount.color = new Color32(0, 0, 0, 90);// lower opacity
				FirstAidKitCount.text = "2/2";
				DCH.enabled = true;
				DoneT1 = true;
			}
		}
		if (DoneT2 == false)
		{
			if (_cravatNarrowFolding.isSuccess ^ _stepByStepBandaging.isSuccess == true)
			{
				Task2C.text = "1/2";
				if (_cravatNarrowFolding.isSuccess == true)
				{
					Task2 = true;
					T2_1.enabled = false;

				}
				else if (_stepByStepBandaging.isSuccess == true)
				{
					Task2_1 = true;
					T2_2.enabled = false;
				}
			}
			else if ((_cravatNarrowFolding.isSuccess == true) && (_stepByStepBandaging.isSuccess == true))
			{
				Task2 = true;
				Task2_1 = true;
				T2_1.enabled = false;
				T2_2.enabled = false;
				Task2T.color = new Color32(0, 0, 0, 90);// lower opacity
				Task2C.color = new Color32(0, 0, 0, 90);// lower opacity
				Task2C.text = "2/2";
				DoneT2 = true;
			}
		}
		if (DoneT3 == false)
		{
			if (_taskCompleteDrainage.TaskIsDone ^ _checkAnswerFloodingCauses.TaskComplete == true)
			{
				Task3C.text = "1/2";
				if (_taskCompleteDrainage.TaskIsDone == true)
				{
					Task3 = true;
					T3_1.enabled = false;
				}
				else if (_checkAnswerFloodingCauses.TaskComplete == true)
				{
					Task3_1 = true;
					T3_2.enabled = false;
				}
			}
			else if ((_taskCompleteDrainage.TaskIsDone == true) && (_checkAnswerFloodingCauses.TaskComplete == true))
			{
				Task3 = true;
				Task3_1 = true;
				T3_1.enabled = false;
				T3_2.enabled = false;
				Task3T.color = new Color32(0, 0, 0, 90);// lower opacity
				Task3C.color = new Color32(0, 0, 0, 90);// lower opacity
				Task3C.text = "2/2";
				DoneT3 = true;
			}
		}
		if (DoneT4 == false)
		{
			if (_fireExtinguisherAnimationScript.TaskIsDone ^ _extinguisherClassesDragAndDrops.Completed == true)
			{
				Task4C.text = "1/2";
				if (_fireExtinguisherAnimationScript.TaskIsDone == true)
				{
					Task4 = true;
					ForeOW.SetActive(false);
					T4_1.enabled = false;
				}
				else if (_extinguisherClassesDragAndDrops.Completed == true)
				{
					Task4_1 = true;
					T4_2.enabled = false;
				}
			}
			else if ((_fireExtinguisherAnimationScript.TaskIsDone == true) && (_extinguisherClassesDragAndDrops.Completed == true))
			{
				Task4 = true;
				Task4_1 = true;
				T4_1.enabled = false;
				T4_2.enabled = false;
				ForeOW.SetActive(false);
				Task4T.color = new Color32(0, 0, 0, 90);// lower opacity
				Task4C.color = new Color32(0, 0, 0, 90);// lower opacity
				Task4C.text = "2/2";
				DoneT4 = true;
			}
		}
		if (DoneT5 == false)
		{	
			if (_dropCoverHoldTriggerTaskIsComplete.IsComplete == true)
			{
				Task5 = true;
				Task5T.color = new Color32(0, 0, 0, 90);// lower opacity
				Task5C.color = new Color32(0, 0, 0, 90);// lower opacity
				Task5C.text = "1/1";
				T5_1.enabled = false;
				DoneT5 = true;
			}
		}//
		CheckAllTaskCompletion();
	}


	public void CheckAllTaskCompletion()
	{
		if (StageComplete_Done == false)
		{
			if ((DoneT1 == true) && (DoneT2 == true) && (DoneT3 == true) && (DoneT4 == true) && (DoneT5 == true))
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
	}
}
