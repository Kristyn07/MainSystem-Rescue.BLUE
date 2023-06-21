using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using Network.LeaderBoard;
using Network.Manager;

namespace Centralize.Button
{
    public class CentralizeAccountBTN : MonoBehaviour
    {
        [Header ("UI Manipulation")]
        [SerializeField] TextMeshProUGUI ScoreValue;
        [SerializeField] TextMeshProUGUI RankTitle;


        [SerializeField] PlayfabLeaderBoardManagerScript _playfabLeaderBoardManagerScript;
        [SerializeField] PlayfabManagerScript _playfabManager;
        [SerializeField] PlayfabOnlineDetector _onlineLoginDetected;
        [SerializeField] GameObject[] Delay;
        public void AccountButton()
		{
            CallDelay();
            if (_onlineLoginDetected.PlayerLogin)
            {
                
                SetScore();
                SetRankTitle();
                SetLeaderBoardRank();
            } 
        }

        public void SetScore()
		{
            /*int x = PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES");
            GetPlayerInfo();
            ScoreValue.text = x.ToString();*/
            //_playfabManager.LoginButton();
            _playfabManager.GetPlayerInfo();
            
        }

        public void SetRankTitle()
		{
            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_1)//2196
            {
                RankTitle.text = "MASTER";
            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_2 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_2) //
            {
                RankTitle.text = "INTERMEDIATE";
            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_3 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
            {
                RankTitle.text = "TRAINEE";
            }
        }

        public void SetLeaderBoardRank()
		{
            
            if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
            {
                if (_playfabLeaderBoardManagerScript.Online == true)
                {
                    //_playfabManager.GetPlayerRank();
                }
            }
            
        }

        public void CallDelay()
		{
            foreach (GameObject obj in Delay)
			{
                obj.SetActive(true);
			}
		}

    }
}
