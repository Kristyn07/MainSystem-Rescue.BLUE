using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainScene.Manager;
using PlayFab;
using PlayFab.ClientModels;
using Network.LeaderBoard;

namespace Centralize.Button
{
	public class CentralizeStartNewGameButton : MonoBehaviour
	{
		[Header ("Main Menu Manager")]
		[SerializeField] SceneLoader _sceneLoader;
		[SerializeField] Reply _replyAccessToturial;
		[SerializeField] StageMenu _stageMenu;
		[SerializeField] MainMenuManagerScript _mainMenuManger;
		[Header("Set 0 LeaderBoard")]
		[SerializeField] PlayfabLeaderBoardManagerScript _leaderBoardManager;


		public void NewGameButton()
		{
			MainMenuManager();
			ResetPlayerScorePlayerPrefs();
			ResetPlayrScoreInLeaderBoard();
		}

		public void MainMenuManager()
		{
			_sceneLoader.LoadScene(2);//load to stage 1
			_replyAccessToturial.SetIntReply(0); // start on Toturial
			_stageMenu.SetLatestStageNumber(1);//Set Stage 1 as the Latest or unlock stage 1 only
			//_mainMenuManger.ContiueButton();
		}

		public void ResetPlayerScorePlayerPrefs()
		{
			PlayerPrefs.SetInt("MainTotalScore_ALLSTAGES", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_1", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_2", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_3", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_4", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_5", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_6", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_7", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_8", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_9", 0);
			PlayerPrefs.SetInt("MainTotalScore_Stage_10", 0);
		}
		public void ResetPlayrScoreInLeaderBoard()
		{
			if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
			{
				if (_leaderBoardManager.Online == true)
				{
					_leaderBoardManager.SendLeaderboard(PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES"));
				}
			}
		}
	}
}
