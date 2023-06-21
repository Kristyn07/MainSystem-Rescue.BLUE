using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Network.LeaderBoard;
using Network.Manager;
using UnityEngine.UI;
[DefaultExecutionOrder(-100)]
public class PlayfabOnlineDetector : MonoBehaviour // if offline do this
{
    [SerializeField] PlayfabLeaderBoardManagerScript _playfabLeaderBoardManagerScript;

    [Header("MainMenu")]
    [SerializeField] bool IsInMainMenuScene;
    [SerializeField] PlayfabManagerScript _playfabManager;
    [SerializeField] GameObject LoginPanel;
    [SerializeField] GameObject MyAccount;
    
    [Header("Stages")]
    [SerializeField] Text PlayerName;
    [SerializeField] Transform RankPos;
    [SerializeField] GameObject Rank01;
    [SerializeField] GameObject Rank02;
    [SerializeField] GameObject Rank03;

    [Header("StageComplete")]
    [SerializeField] Transform RankPositionOnWin;
    [SerializeField] Text RankText;


   public bool PlayerLogin = false;
	/*public void Awake()
	{
        if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
        {
            //_playfabManager.LoginButton();
            AutoLoginLeaderBoardAccess();
            //_playfabManager.LoginButton();
        }
    }*/
	public void Start()
    {
		
		OnlineNetwork();

        if (IsInMainMenuScene) { PlayerMobileHasSigned(); }
        else
        {
            SetPlayerNameeOnReputationBar();
            SetRankIconOnReputationBar();
        }

        if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
        {
            //_playfabManager.LoginButton();
            AutoLoginLeaderBoardAccess();
        }

    }


    //MainMenu
    public void OnlineNetwork()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No Internet!");
            PlayerPrefs.SetInt("Online", 1);
            _playfabLeaderBoardManagerScript.Online = false;
            _playfabManager.GetPlayerInfo();


        }
        else
        {
            Debug.Log("Internet!");
            PlayerPrefs.SetInt("Online", 0);
            _playfabLeaderBoardManagerScript.Online = true;
            
           
            UpdateLeaderBoardPlayerScore();
            
            //_playfabManager.GetPlayerInfo();
            
        }



    }

    public void RetainPlayerInfoWhenOffline()
    {
        _playfabManager.UserNameText.text = PlayerPrefs.GetString("Player Name");
        _playfabManager.PlayerRankText.text = PlayerPrefs.GetString("PlayerRank");
        _playfabManager.PlayerScoreText.text = PlayerPrefs.GetString("PlayerScore");
        _playfabManager.PlayerRankNumberText.text = PlayerPrefs.GetString("PlayerRankNumber");

        if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_1)//2196
        {
            GameObject F = Instantiate(_playfabLeaderBoardManagerScript.Rank01ImageObj) as GameObject;
            F.transform.SetParent(_playfabManager.ResultPosRank.transform, false);

        }

        if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_2 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_2) //
        {
            GameObject F = Instantiate(_playfabLeaderBoardManagerScript.Rank02ImageObj) as GameObject;
            F.transform.SetParent(_playfabManager.ResultPosRank.transform, false);

        }

        if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_3 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
        {
            GameObject F = Instantiate(_playfabLeaderBoardManagerScript.Rank03ImageObj) as GameObject;
            F.transform.SetParent(_playfabManager.ResultPosRank.transform, false);

        }

        MyAccount.SetActive(true);
        LoginPanel.SetActive(false);
    }

    public void PlayerMobileHasSigned()
    {
        if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
        {
            RetainPlayerInfoWhenOffline();
            

        }
        else
        {
            


        }
    }

    //Stages
    public void SetPlayerNameeOnReputationBar()
    {
        PlayerName.text = PlayerPrefs.GetString("Player Name");
    }
    public void SetRankIconOnReputationBar()
    {
        if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1) {
            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_1)//2196
            {
                GameObject F = Instantiate(Rank01) as GameObject;
                F.transform.SetParent(RankPos.transform, false);

            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_2 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_2) //
            {
                GameObject F = Instantiate(Rank02) as GameObject;
                F.transform.SetParent(RankPos.transform, false);

            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_3 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
            {
                GameObject F = Instantiate(Rank03) as GameObject;
                F.transform.SetParent(RankPos.transform, false);

            }
        }

        else if (PlayerPrefs.GetInt("PlayerHasLogIn") == 0)
        {
            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_1)//2196
            {
                GameObject F = Instantiate(Rank01) as GameObject;
                F.transform.SetParent(RankPos.transform, false);

            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_2 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_2) //
            {
                GameObject F = Instantiate(Rank02) as GameObject;
                F.transform.SetParent(RankPos.transform, false);

            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_3 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
            {
                GameObject F = Instantiate(Rank03) as GameObject;
                F.transform.SetParent(RankPos.transform, false);

            }

        }
    }

    public void UpdatePlayerRankOnStageClear()
	{
        if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
        {
            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_1)//2196
            {
                GameObject F = Instantiate(Rank01) as GameObject;
                F.transform.SetParent(RankPositionOnWin.transform, false);
                RankText.text = "MASTER";

            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_2 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_2) //
            {
                GameObject F = Instantiate(Rank02) as GameObject;
                F.transform.SetParent(RankPositionOnWin.transform, false);
                RankText.text = "INTERMEDIATE";
            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_3 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
            {
                GameObject F = Instantiate(Rank03) as GameObject;
                F.transform.SetParent(RankPositionOnWin.transform, false);
                RankText.text = "TRAINEE";
            }
        }

        else if (PlayerPrefs.GetInt("PlayerHasLogIn") == 0)
        {
            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_1)//2196
            {
                GameObject F = Instantiate(Rank01) as GameObject;
                F.transform.SetParent(RankPositionOnWin.transform, false);
                RankText.text = "MASTER";
            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_2 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_2) //
            {
                GameObject F = Instantiate(Rank02) as GameObject;
                F.transform.SetParent(RankPositionOnWin.transform, false);
                RankText.text = "INTERMEDIATE";
            }

            if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") >= _playfabLeaderBoardManagerScript.MinScore_3 && PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") <= _playfabLeaderBoardManagerScript.MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
            {
                GameObject F = Instantiate(Rank03) as GameObject;
                F.transform.SetParent(RankPositionOnWin.transform, false);
                RankText.text = "TRAINEE";
            }

        }
    }

    public void AutoLoginLeaderBoardAccess()
    {
        
        _playfabLeaderBoardManagerScript.OnLoginUserName();
        _playfabLeaderBoardManagerScript.PlayerName = PlayerPrefs.GetString("Player Name") ;
        _playfabLeaderBoardManagerScript.PlayerPassword = PlayerPrefs.GetString("Player Password");
        _playfabLeaderBoardManagerScript.PlayerID = PlayerPrefs.GetString("Player ID");
        PlayerLogin = true;
        //_playfabManager.GetPlayerInfo();
        
    }

    public void UpdateLeaderBoardPlayerScore()
	{
        if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
        {
            if (_playfabLeaderBoardManagerScript.Online == true)
            {
                _playfabLeaderBoardManagerScript.SaveDataScoreData();
            }
        }
    }
}
