using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainScene.Manager;
using UnityEngine.UI;
public class StageMenu : MonoBehaviour
{
	//[SerializeField] MainMenuManagerScript _mainMenuManagerScript;
	[SerializeField] Button[] StagesBTN;
	[SerializeField] GameObject[] LockStage;
	[SerializeField] int StagesCount;
	//[SerializeField] int SetStageCount;
	[SerializeField] int GetStageCount;
	[SerializeField] int SetStageCount;
	//int stage;
	//[SerializeField] int[] StagesNo;
	private void Awake()//need to set new playerPrefs
	{
		StagesCount = PlayerPrefs.GetInt("Continue");
		StagesComponent();
		SetStageCount = PlayerPrefs.GetInt("StageSelection");
	}

	private void Start()
	{
		SetLatestStageNumber(SetStageCount);
	}

	
	public void SetLatestStageNumber(int SetStageCount)
	{
		GetStageCount = PlayerPrefs.GetInt("StageSelection");
		int GetContinue = (PlayerPrefs.GetInt("Continue")-1);

		if (GetStageCount < GetContinue)
		{
			SetStageCount = GetContinue;
			PlayerPrefs.SetInt("StageSelection", SetStageCount);
			PlayerPrefs.Save();
		}
		else
		{
			//SetStageCount = GetStageCount;
			PlayerPrefs.SetInt("StageSelection", SetStageCount);
			PlayerPrefs.Save();
		}



	}

	public void StagesComponent()
	{
		GetStageCount = PlayerPrefs.GetInt("StageSelection");
		int UnlockStage = GetStageCount;
		switch (UnlockStage)
		{
			case 0:
				foreach (GameObject obj in LockStage)
				{
					obj.SetActive(true);
				}
				foreach (Button btn in StagesBTN)
				{
					btn.interactable = false;
				}
				break;
			case 1:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(true);
				LockStage[2].SetActive(true);
				LockStage[3].SetActive(true);
				LockStage[4].SetActive(true);
				LockStage[5].SetActive(true);
				LockStage[6].SetActive(true);
				LockStage[7].SetActive(true);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = false;
				StagesBTN[2].interactable = false;
				StagesBTN[3].interactable = false;
				StagesBTN[4].interactable = false;
				StagesBTN[5].interactable = false;
				StagesBTN[6].interactable = false;
				StagesBTN[7].interactable = false;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;

				break;
			case 2:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(true);
				LockStage[3].SetActive(true);
				LockStage[4].SetActive(true);
				LockStage[5].SetActive(true);
				LockStage[6].SetActive(true);
				LockStage[7].SetActive(true);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = false;
				StagesBTN[3].interactable = false;
				StagesBTN[4].interactable = false;
				StagesBTN[5].interactable = false;
				StagesBTN[6].interactable = false;
				StagesBTN[7].interactable = false;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;
				break;
			case 3:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(true);
				LockStage[4].SetActive(true);
				LockStage[5].SetActive(true);
				LockStage[6].SetActive(true);
				LockStage[7].SetActive(true);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = false;
				StagesBTN[4].interactable = false;
				StagesBTN[5].interactable = false;
				StagesBTN[6].interactable = false;
				StagesBTN[7].interactable = false;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;
				break;
			case 4:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(false);
				LockStage[4].SetActive(true);
				LockStage[5].SetActive(true);
				LockStage[6].SetActive(true);
				LockStage[7].SetActive(true);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = true;
				StagesBTN[4].interactable = false;
				StagesBTN[5].interactable = false;
				StagesBTN[6].interactable = false;
				StagesBTN[7].interactable = false;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;
				break;
			case 5:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(false);
				LockStage[4].SetActive(false);
				LockStage[5].SetActive(true);
				LockStage[6].SetActive(true);
				LockStage[7].SetActive(true);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = true;
				StagesBTN[4].interactable = true;
				StagesBTN[5].interactable = false;
				StagesBTN[6].interactable = false;
				StagesBTN[7].interactable = false;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;
				break;
			case 6:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(false);
				LockStage[4].SetActive(false);
				LockStage[5].SetActive(false);
				LockStage[6].SetActive(true);
				LockStage[7].SetActive(true);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = true;
				StagesBTN[4].interactable = true;
				StagesBTN[5].interactable = true;
				StagesBTN[6].interactable = false;
				StagesBTN[7].interactable = false;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;
				break;
			case 7:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(false);
				LockStage[4].SetActive(false);
				LockStage[5].SetActive(false);
				LockStage[6].SetActive(false);
				LockStage[7].SetActive(true);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = true;
				StagesBTN[4].interactable = true;
				StagesBTN[5].interactable = true;
				StagesBTN[6].interactable = true;
				StagesBTN[7].interactable = false;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;
				break;
			case 8:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(false);
				LockStage[4].SetActive(false);
				LockStage[5].SetActive(false);
				LockStage[6].SetActive(false);
				LockStage[7].SetActive(false);
				LockStage[8].SetActive(true);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = true;
				StagesBTN[4].interactable = true;
				StagesBTN[5].interactable = true;
				StagesBTN[6].interactable = true;
				StagesBTN[7].interactable = true;
				StagesBTN[8].interactable = false;
				StagesBTN[9].interactable = false;
				break;
			case 9:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(false);
				LockStage[4].SetActive(false);
				LockStage[5].SetActive(false);
				LockStage[6].SetActive(false);
				LockStage[7].SetActive(false);
				LockStage[8].SetActive(false);
				LockStage[9].SetActive(true);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = true;
				StagesBTN[4].interactable = true;
				StagesBTN[5].interactable = true;
				StagesBTN[6].interactable = true;
				StagesBTN[7].interactable = true;
				StagesBTN[8].interactable = true;
				StagesBTN[9].interactable = false;
				break;
			case 10:
				LockStage[0].SetActive(false);
				LockStage[1].SetActive(false);
				LockStage[2].SetActive(false);
				LockStage[3].SetActive(false);
				LockStage[4].SetActive(false);
				LockStage[5].SetActive(false);
				LockStage[6].SetActive(false);
				LockStage[7].SetActive(false);
				LockStage[8].SetActive(false);
				LockStage[9].SetActive(false);

				StagesBTN[0].interactable = true;
				StagesBTN[1].interactable = true;
				StagesBTN[2].interactable = true;
				StagesBTN[3].interactable = true;
				StagesBTN[4].interactable = true;
				StagesBTN[5].interactable = true;
				StagesBTN[6].interactable = true;
				StagesBTN[7].interactable = true;
				StagesBTN[8].interactable = true;
				StagesBTN[9].interactable = true;
				break;
		}






	}







}
