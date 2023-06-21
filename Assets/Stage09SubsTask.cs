using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;
using Score.System;
using Flooding;
public class Stage09SubsTask : MonoBehaviour
{
	//All Task MissionComplete
	[SerializeField] bool StageComplete;
	[SerializeField] bool StageComplete_Done;
	[SerializeField] GameObject WinStatePanel;
	[SerializeField] float DelaySecs = 3f;
	[Header("Stage Complete Method/Scripts")]
	[SerializeField] LevelGameplayManagerScript MainLevel;
	[SerializeField] ScoreManagerScriptStages MainScoreStage;

	//Drainage
	[Header("Drinaige")]
	[SerializeField] bool mn1_isComplete;
	[SerializeField] TaskCompleteDrainage T1_CompleteScript;
	public TMPro.TextMeshProUGUI MN1_txt;
	public TMPro.TextMeshProUGUI MN1_count;
	[SerializeField] bool M1Done;

	[Header("TV and Fan")]
	[SerializeField] bool mn2_isComplete;
	[SerializeField] TaskCompletePlugOnly T2_1_CompleteScript;
	[SerializeField] TaskCompletePlugOnly T2_2_CompleteScript;
	public TMPro.TextMeshProUGUI MN2_txt;
	public TMPro.TextMeshProUGUI MN2_count;
	[SerializeField] bool M2Done;
	

	[Header("Phone and Flashlight")]
	[SerializeField] bool mn3_isComplete;
	[SerializeField] GameObject MainController;
	[SerializeField] bool PhoneAlreadyAcquired;
	[SerializeField] GameObject PhoneCollected;
	[SerializeField] bool FlashLightAlreadyAcquired;
	[SerializeField] GameObject FlashLightCollected;
	[SerializeField] TaskCompleteCargingPhone T3_1_CompleteScript;
	[SerializeField] TaskCompleteCargingPhone T3_2_CompleteScript;
	public TMPro.TextMeshProUGUI MN3_txt;
	public TMPro.TextMeshProUGUI MN3_count;
	[SerializeField] bool M3Done;
	[SerializeField] GameObject LightsideButton;
	[SerializeField] GameObject PhonesideButton;
	[SerializeField] GameObject PhoneOW;
	[SerializeField] GameObject FlashLightOW;
	[Header("StartTyphoon")]
	[SerializeField] bool StartTyphoonNewGamePlay;
	[SerializeField] GameObject StartAnimation;
	[SerializeField] Image DissablePhone;
	[SerializeField] Image DissableStorage;

	public void Check_Update()
	{
		if (StageComplete == false)
		{
			//Check Task Completion

			//Task1
			if (StartTyphoonNewGamePlay == false)
			{
				if (M1Done == false)
				{
					if (T1_CompleteScript.TaskIsDone == true)
					{
						mn1_isComplete = true;
						MN1_txt.color = new Color32(0, 0, 0, 90);// lower opacity
						MN1_count.text = "1/1";
						MN1_count.color = new Color32(0, 0, 0, 90);// lower opacity
						M1Done = true;
					}
				}

				if (M2Done == false)
				{
					if (T2_1_CompleteScript.TaskIsDone == true && T2_2_CompleteScript.TaskIsDone == true)
					{
						mn2_isComplete = true;
						MN2_txt.color = new Color32(0, 0, 0, 90);// lower opacity
						MN2_count.text = "2/2";
						MN2_count.color = new Color32(0, 0, 0, 90);// lower opacity
						M2Done = true;
					}
					else if ((T2_1_CompleteScript.TaskIsDone == true && T2_2_CompleteScript.TaskIsDone == false)
						|| (T2_1_CompleteScript.TaskIsDone == false && T2_2_CompleteScript.TaskIsDone == true))
					{
						MN2_count.text = "1/2";
					}
				}

				if (M3Done == false)
				{
					if (!PhoneAlreadyAcquired)
					{
						if (T3_1_CompleteScript.TaskIsDone)
						{
							MainController.SetActive(false);
							PhoneCollected.SetActive(true);
							StartCoroutine(ObtainPhone());
							
						}
					}
					if (!FlashLightAlreadyAcquired)
					{
						if (T3_2_CompleteScript.TaskIsDone)
						{
							MainController.SetActive(false);
							FlashLightCollected.SetActive(true);
							StartCoroutine(ObtainFlashLight());

						}
					}

					if (T3_1_CompleteScript.TaskIsDone == true && T3_2_CompleteScript.TaskIsDone == true)
					{
						mn3_isComplete = true;
						MN3_txt.color = new Color32(0, 0, 0, 90);// lower opacity
						MN3_count.text = "2/2";
						MN3_count.color = new Color32(0, 0, 0, 90);// lower opacity
						M3Done = true;
					}
					else if ((T3_1_CompleteScript.TaskIsDone == true && T3_2_CompleteScript.TaskIsDone == false)
						|| (T3_1_CompleteScript.TaskIsDone == false && T3_2_CompleteScript.TaskIsDone == true))
					{
						MN3_count.text = "1/2";
					}
				}

				if (M1Done == true && M2Done == true && M3Done == true)
				{
					StartCoroutine(StartNewGamePlay());
				}
			}
			

			//CheckAllTaskCompletion();
		}
	}


	IEnumerator StartNewGamePlay()
	{
		DissableStorage.enabled = true;
		DissablePhone.enabled = true;
		yield return new WaitForSeconds(5f);
		StartAnimation.SetActive(true);
		StartTyphoonNewGamePlay = true;

		
	}

	IEnumerator ObtainFlashLight()
	{
		yield return new WaitForSeconds(5f);
		LightsideButton.SetActive(true);
		FlashLightOW.SetActive(false);
		MainController.SetActive(true);
		Destroy(FlashLightCollected);
		FlashLightAlreadyAcquired = true;
	}

	IEnumerator ObtainPhone()
	{
		yield return new WaitForSeconds(5f);
		PhonesideButton.SetActive(true);
		PhoneOW.SetActive(false);
		MainController.SetActive(true);
		Destroy(PhoneCollected);
		PhoneAlreadyAcquired = true;
	}
}
