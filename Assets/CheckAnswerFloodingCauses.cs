using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;
using Stage080910;

namespace Flooding
{
	public class CheckAnswerFloodingCauses : MonoBehaviour
	{
		public bool TaskComplete;
		[SerializeField] int TaskCount;
		[Header("Result")]
		[SerializeField] Text ResultText;
		[SerializeField] Button SubmitButton;
		[SerializeField] GameObject CompleteAnim;
		[SerializeField] LevelGameplayManagerScript MainLevel;
		[SerializeField] CentralizeLevel08GameplayManagerScript CentralizeStage08;

		[Header ("Toggle")]
		[Tooltip("Check")] [SerializeField] Toggle A1;
		[Tooltip("Check")] [SerializeField] Toggle B1;
		[Tooltip("Check")] [SerializeField] Toggle C1;

		[Tooltip("Wrong")] [SerializeField] Toggle A2;
		[Tooltip("Wrong")] [SerializeField] Toggle B2;
		[Tooltip("Wrong")] [SerializeField] Toggle C2;

		[SerializeField] bool Stage10;
		[SerializeField] CentralizeLevel10GamePlayManagerScript CentralizeStage10;
		public void Start()
		{
			ResultText.enabled = false;
		}

		public void Checker()
		{
			if ((A1.isOn == true ) && (B1.isOn == true) && (C1.isOn == true) 
				&& (A2.isOn == false) && (B2.isOn == false) && (C2.isOn == false))
			{
				// CORRECT
				SubmitButton.interactable = false;
				ResultText.text = "Excellent";
				ResultText.enabled = true;
				Invoke("Delay", 2f);
				TaskComplete = true;
				Invoke("TaskCompletedMethodCollection",2f);
			}
			else
			{
				//INCORRECT
				SubmitButton.interactable = false;
				ResultText.text = "Oops, try again";
				ResultText.enabled = true;
				Invoke("Delay", 2f);
				Invoke("ResetOptionState", 2f);
				//TaskComplete = false;
			}
		}

		public void Delay()
		{
			ResultText.enabled = false;
			SubmitButton.interactable = true;

		}
		public void ResetOptionState()
		{
			A1.isOn = false;
			A2.isOn = false;
			B1.isOn = false;
			B2.isOn = false;
			C1.isOn = false;
			C2.isOn = false;
		}

		public void TaskCompletedMethodCollection()
		{
			StartCoroutine(DoThisWhenComplete());
		}

		IEnumerator DoThisWhenComplete()
		{
			CompleteAnim.SetActive(true);
			if (Stage10)
			{
				//CentralizeStage10.MissionCol[TaskCount].enabled = false;
				//MainLevel.PopUpMission[TaskCount].SetActive(false);
			}
			else
			{
				CentralizeStage08.MissionCol[TaskCount].enabled = false;
				MainLevel.PopUpMission[TaskCount].SetActive(false);
			}
			
			
			yield return new WaitForSeconds(2.9f);
			gameObject.SetActive(false);
			MainLevel.HideInspectMission();
		}

	}
}
