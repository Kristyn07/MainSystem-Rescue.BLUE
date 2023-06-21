using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MainScene.Manager;
using Network.LeaderBoard;
using PlayFab;
using PlayFab.ClientModels;

namespace Centralize.Button
{
	public class CentralizeLeaderBoardButton : MonoBehaviour
	{
		[Header("UI Manipulation")]
		[SerializeField] MainMenuManagerScript MainMenuManager;
		[SerializeField] GameObject LeaderBoardPanel;
		[SerializeField] GameObject MainMenuCollection;
		[SerializeField] GameObject PlayerCharacterCollection;

		[Header("GetLeaderBoard")]
		[SerializeField] PlayfabLeaderBoardManagerScript LeaderBoardManager;


		[Header("Cannot Access LeaderBoard")]
		[SerializeField] GameObject NoticePanel;
		[SerializeField] Text TextMessage;
		[SerializeField] string NeedInternet;
		[SerializeField] string NeedToLogin;
		public void LeaderBoardButton()
		{
			

			//player has access on leader board 
			if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
			{
				if (LeaderBoardManager.Online == true)
				{
					MainMenuManager.ShowPanel(LeaderBoardPanel);
					MainMenuCollection.SetActive(false);
					PlayerCharacterCollection.SetActive(false);
					//MainMenuManager.HidePanel(MainMenuCollection);
					//MainMenuManager.HidePanel(PlayerCharacterCollectiob);
					LeaderBoardManager.GetLeaderBoard();
				}
				else
				{
					MainMenuManager.ShowPanel(NoticePanel);
					TextMessage.text = NeedInternet;
				}
			}

			else
			{
				MainMenuManager.ShowPanel(NoticePanel);
				TextMessage.text = NeedToLogin;
			}
		}
	}
}
