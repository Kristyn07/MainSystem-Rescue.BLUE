using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Score.System;
using TMPro;
using UnityEngine.UI;
using System.Linq;


namespace Network.LeaderBoard
{
    public class PlayfabLeaderBoardManagerScript : MonoBehaviour
    {
        //[SerializeField]
       // ScoreManagerScript MainScore;
        [SerializeField]
        int PlayerScore;

        public string PlayerName;
        public string PlayerPassword;
        public string PlayerID;

       public bool Online;

        [SerializeField]
        bool Gameplay;

        //Leaderboard Show Data
        //Name
        [SerializeField]
        string ResultData;
        [SerializeField]
        GameObject ResultDataObj;
        [SerializeField]
        TextMeshProUGUI ResultDataText;
        [SerializeField]
        Transform ResultPos;
        //Score
        public
        int ResultDataValue;
        [SerializeField]
        GameObject ResultDataValueObj;
        [SerializeField]
        TextMeshProUGUI ResultDataValueText;
        //Image
        [Header("Score System")]
        private int MaxScore = 113574;
        [Header("Rank1 / Master")]
        public int MinScore_1 = 56787;
        public GameObject Rank01ImageObj;
        [Header("Rank2 / Intermediate")]
        public int MinScore_2 = 28393;
        public int MaxScore_2 = 56786;
        public GameObject Rank02ImageObj;
        [Header("Rank3 / Trainee")]
        public int MinScore_3 = 0;
        public int MaxScore_3 = 28392;
        public GameObject Rank03ImageObj;

        GameObject[] LeaderBoardData;
        public Transform LeaderBoardViewPoint;



        void Awake()
        {
            if (Gameplay == true)
            {
                PlayerID = PlayerPrefs.GetString("Player ID");
                PlayerName = PlayerPrefs.GetString("Player Name");
                PlayerPassword = PlayerPrefs.GetString("Player Password");
            }

			



            //if (Gameplay == false)
            //{
            //    PlayerID = PlayerPrefs.GetString("Player ID");
            //    PlayerName = PlayerPrefs.GetString("Player Name");
            //    PlayerPassword = PlayerPrefs.GetString("Player Password");
            //}
        }
        // Start is called before the first frame update
        void Start()
        {
            //if (Gameplay == false)
            //{
            //    OnLoginUserName();
            //}
            if (PlayerPrefs.GetInt("Online") == 1)
			{
                if (Gameplay == true)
                {
                    OnLoginUserName();
                    StartCoroutine(GetScoreOnline());
                }
            }
			else
			{
                //dont access
			}
            

        }
        IEnumerator GetScoreOnline()
        {
            yield return new WaitForSeconds(.5f);
            GetLeaderBoard();
        }

       

        public void SendLeaderboard(int score)
        {
            var SetLeaderBoardRequest = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate
                    {
                        StatisticName = "Rescue Blue Score",
                        Value = score
                    }
                }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(SetLeaderBoardRequest, OnLeaderBoardUpdate, OnErrorLeaderBoardUpdate);
        }

        void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
        {
            Debug.Log("Leader Board Sent");
        }

        void OnErrorLeaderBoardUpdate(PlayFabError error)
        {
            Debug.Log(error.GenerateErrorReport());
        }

        public void SaveDataScoreData()
        {
            StartCoroutine(SaveDataScoreDelay());
        }
        IEnumerator SaveDataScoreDelay()
        {
            yield return new WaitForSeconds(.2f);
            if (Online == true)
            {
                /*if (MainScore.MainTotalScore > PlayerScore)
                {
                    SendLeaderboard(MainScore.MainTotalScore);

                }*/
                if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
				{
                    if (PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES") > PlayerScore)
                    {
                        SendLeaderboard(PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES"));
                    }
                }

               
                //SendLeaderboard(MainScore.MainTotalScore);
            }
        }

        public void GetLeaderBoard()
        {
            if (Online)
            {
                var GetLeaderBoardRequest = new GetLeaderboardRequest
                    {
                        StatisticName = "Rescue Blue Score",
                        StartPosition = 0,
                        MaxResultsCount = 10
                    };
                  PlayFabClientAPI.GetLeaderboard(GetLeaderBoardRequest, OnLeaderBoardGetUpdate, OnErrorLeaderBoardUpdate);
                
            }
			else {
                    
                 }
        }
        public void OnLeaderBoardGetUpdate(GetLeaderboardResult result)
        {
            if (Gameplay == false)
            {
                
                LeaderBoardData = GameObject.FindGameObjectsWithTag("Leaderboard Data");
                foreach (GameObject data in LeaderBoardData)
                {
                    if (Online == true) { 
                        if (data.transform.IsChildOf(ResultPos.transform))
                        {
                            Destroy(data.gameObject);
                        }
                    }
					else
					{
                        //InstantiateStoredObjects();
                    }
                }



                for (int i = 0; i < result.Leaderboard.Count; i++)
                {
                   //Debug.Log(i);
                    if (result.Leaderboard.Count <= 10) // 10
                    {
                        //Debug.Log( "result form leader board"+i + result.Leaderboard.Count);
                        if (result.Leaderboard[i].DisplayName != null && result.Leaderboard[i].StatValue >= 1)
                        {
                            //Debug.Log("name" + result.Leaderboard[i].DisplayName);
                            ResultData = result.Leaderboard[i].DisplayName;
                            ResultDataText.text = ResultData.ToString();
                            GameObject D = Instantiate(ResultDataObj) as GameObject;
                            D.transform.SetParent(ResultPos.transform, false);


                            ResultDataValue = result.Leaderboard[i].StatValue;
                            ResultDataValueText.text = ResultDataValue.ToString();
                            GameObject E = Instantiate(ResultDataValueObj) as GameObject;
                            E.transform.SetParent(ResultPos.transform, false);

                            if (result.Leaderboard[i].StatValue >= MinScore_1)//2196
                            {
                                GameObject F = Instantiate(Rank01ImageObj) as GameObject;
                                F.transform.SetParent(ResultPos.transform, false);
                            }

                            if (result.Leaderboard[i].StatValue >= MinScore_2 && result.Leaderboard[i].StatValue <= MaxScore_2) //
                            {
                                GameObject F = Instantiate(Rank02ImageObj) as GameObject;
                                F.transform.SetParent(ResultPos.transform, false);
                            }

                            if (result.Leaderboard[i].StatValue >= MinScore_3 && result.Leaderboard[i].StatValue <= MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
                            {
                                GameObject F = Instantiate(Rank03ImageObj) as GameObject;
                                F.transform.SetParent(ResultPos.transform, false);
                            }
                        }
                    }

                }
                //Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
                //    PlayerScore += item.StatValue;

                //}
            }

            if (Gameplay == true)
            {
                PlayerScore = 0;
                for (int i = 0; i < result.Leaderboard.Count; i++)
                {
                    if (result.Leaderboard[i].PlayFabId == PlayerID)
                    {
                        if (result.Leaderboard[i].PlayFabId != null)
                        {
                            PlayerScore += result.Leaderboard[i].StatValue;
                        }
                    }
                }
            }

        }

        public void OnLoginUserName()
        {
            PlayerID = PlayerPrefs.GetString("Player ID");
            PlayerName = PlayerPrefs.GetString("Player Name");
            PlayerPassword = PlayerPrefs.GetString("Player Password");

            var requestLoginUserName = new LoginWithPlayFabRequest
            {
                Username = PlayerName,
                Password = PlayerPassword
            };
            PlayFabClientAPI.LoginWithPlayFab(requestLoginUserName, OnUserNameLoginSuccess, OnLoginError);
        }

        void OnUserNameLoginSuccess(LoginResult result)
        {
            Debug.Log("Login Success");
        }

        void OnUserNameDisplayError(PlayFabError error)
        {
            Debug.Log(error.GenerateErrorReport());
            Debug.Log("Error");
        }

        void OnLoginError(PlayFabError error)
        {
            Debug.Log(error.GenerateErrorReport());
            Debug.Log("Error"); ;
        }

        public void MainMenuLoginData()
        {
            PlayerID = PlayerPrefs.GetString("Player ID");
            PlayerName = PlayerPrefs.GetString("Player Name");
            PlayerPassword = PlayerPrefs.GetString("Player Password");
        }



        //stuff


        /*public void GetRank()
        {

            if (ResultDataValue >= MinScore_1)//2196
            {
                GameObject F = Instantiate(Rank01ImageObj) as GameObject;
                F.transform.SetParent(ResultPosRank.transform, false);
            }

            if (ResultDataValue >= MinScore_2 && ResultDataValue <= MaxScore_2) //
            {
                GameObject F = Instantiate(Rank02ImageObj) as GameObject;
                F.transform.SetParent(ResultPosRank.transform, false);
            }

            if (ResultDataValue >= MinScore_3 && ResultDataValue <= MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
            {
                GameObject F = Instantiate(Rank03ImageObj) as GameObject;
                F.transform.SetParent(ResultPosRank.transform, false);
            }
        }*/


        //PlayerUSerNAme
        public void GetPlayerUsername(string playFabId)
        {
            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest
            {
                PlayFabId = playFabId
            }, result =>
            {
                string username = result.AccountInfo.Username;
                Debug.Log("Username for player with PlayFab ID " + playFabId + " is " + username);
                ResultData = username;
            }, error =>
            {
                Debug.LogError(error.GenerateErrorReport());
            });
        }


        public void DontDestroyAllChildren()
        {
            int childCount = LeaderBoardViewPoint.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject child = LeaderBoardViewPoint.GetChild(i).gameObject;
                DontDestroyOnLoad(child);
                PlayerPrefs.SetInt(child.name, 1);
            }
        }


        public void InstantiateStoredObjects()
        {
            int childCount = LeaderBoardViewPoint.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                GameObject child = LeaderBoardViewPoint.GetChild(i).gameObject;
                if (PlayerPrefs.HasKey(child.name))
                {
                    Instantiate(child);
                }
            }
        }

    }
}

