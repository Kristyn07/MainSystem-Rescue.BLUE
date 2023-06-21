using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainScene.Manager;
using PlayFab.ClientModels;
using TMPro;
using Network.Manager;
public class NewPlayer : MonoBehaviour
{
	public GameObject[] ContinueButton;
	[SerializeField] GameObject PopUpOveriteGame;

	[Header("Start New Game")]
	[SerializeField] SceneLoader _sceneLoader;
	[SerializeField] Reply _reply;
	[SerializeField] StageMenu _stageMenu;
	[SerializeField] MainMenuManagerScript _mainMenuManagerScript;
	[SerializeField] PlayfabLatestStage _latestStage;
	public void Start()
	{
		if (PlayerPrefs.GetInt("StageSelection") == 0)
		{
			PlayerPrefs.SetInt("NewPlayer", 0);
		}
		else if (PlayerPrefs.GetInt("StageSelection") < 0)
		{
			PlayerPrefs.SetInt("NewPlayer", 1);
		}


		if (PlayerPrefs.GetInt("NewPlayer") == 0) // new user
		{
			//unhide ContinueButton
			foreach(GameObject obj in ContinueButton)
			{
				obj.SetActive(false);
			}


		}
		else if (PlayerPrefs.GetInt("NewPlayer") == 1) // not a new user
		{
			foreach (GameObject obj in ContinueButton)
			{
				obj.SetActive(true);
			}
		}
	}

	public void PlayerIsNotANewUser()
	{
		PopUpOveriteGame.SetActive(true);
		
	}

	public void PlayerIsNewUser()
	{
		_sceneLoader.LoadScene(2);
		_reply.SetIntReply(0);
		_stageMenu.SetLatestStageNumber(1);
		_mainMenuManagerScript.ContiueButton();
		PlayerPrefs.SetInt("NewPlayer", 1);
	}

	public void StartButton()
	{
		if (PlayerPrefs.GetInt("NewPlayer") == 0) //new player
		{
			PlayerIsNewUser();
		}
		else if (PlayerPrefs.GetInt("NewPlayer") == 1) // not a new player
		{
			PlayerIsNotANewUser();
		}
	}
}
