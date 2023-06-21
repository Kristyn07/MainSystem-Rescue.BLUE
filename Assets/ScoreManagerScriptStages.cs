using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager.Level;
using System;
using Network.LeaderBoard;
namespace Score.System
{
    public class ScoreManagerScriptStages : MonoBehaviour
    {
		[Header("Player Score")]
		[SerializeField] int PlayerTotalScore;
		[SerializeField] int ScoreAdjustmentDueToHigherLevel;

		[Header("UI")]
        [SerializeField] Text DisplayScore;

		[Header("Stage Specification")]
		[SerializeField] int StageNumber;
		[SerializeField] int GetStagePlayerScore;

		[Header("Stage Score Specification")]
		[SerializeField] ScoreSystemCalculator TotalScoreManager;
		[SerializeField] int StageTotalScore;

		
		[Header("Timer Game Play Mode")]
		[SerializeField] int MissionCountStage;
		[SerializeField] float LevelOfDifficultyStage;
		[SerializeField] float _MaximumTimer;
		
		[SerializeField] float _ScoreReducePerSec;
		[SerializeField] float UpdateScore;
		[SerializeField] int UpdateScoreStage;

		[Header ("StageGamePlaySpecification")]
		[SerializeField] LevelGameplayManagerScript MainLevel1;
		[SerializeField] Level02GameplayManagerScript MainLevel2;
		[SerializeField] Level02GameplayManagerScript MainLevel3;
		[SerializeField] LevelGameplayManagerScript MainLevel4;
		[SerializeField] LevelGameplayManagerScript MainLevel5;
		[SerializeField] LevelGameplayManagerScript MainLevel6;
		[SerializeField] LevelGameplayManagerScript MainLevel7;
		[SerializeField] LevelGameplayManagerScript MainLevel8;
		[SerializeField] LevelGameplayManagerScript MainLevel9;
		[SerializeField] LevelGameplayManagerScript MainLevel10;


		[Header("SendToLeaderBoard")]
		[SerializeField] PlayfabLeaderBoardManagerScript _leaderBoard;

		[Header("WinCondition Update Rank")]
		[SerializeField] PlayfabOnlineDetector _onlineDetector;
		private bool hasInstantiated = false;
		private void Awake()
		{
			//Get Higher Value Of Stage Score
			switch (StageNumber)
			{
				case 1:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_1");
					break;
				case 2:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_2");
					break;
				case 3:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_3");
					break;
				case 4:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_4");
					break;
				case 5:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_5");
					break;
				case 6:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_6");
					break;
				case 7:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_7");
					break;
				case 8:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_8");
					break;
				case 9:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_9");
					break;
				case 10:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_10");
					break;
				default:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES");
					break;
			}
		}
		private void Start()
		{
			StageTotalScore = TotalScoreManager.TotalScoreStage;// + ScoreAdjustmentDueToHigherLevel; // get maximum score
			GetMaximumTimer();
			DecreaseScoreTimed();

		}

		private void Update()
		{
			UpdateScoreTimeBased();
		}

		public void UpdateScoreTimeBased()
		{
			if (StageNumber == 1)
			{
				UpdateScore = MainLevel1.Timer * _ScoreReducePerSec;
			}
			else if (StageNumber == 2)
			{
				UpdateScore = MainLevel2.Timer * _ScoreReducePerSec;
			}
			else if (StageNumber == 3)
			{
				UpdateScore = MainLevel3.Timer * _ScoreReducePerSec;
			}
			else if (StageNumber == 4)
			{
				UpdateScore = MainLevel4.Timer * _ScoreReducePerSec;
			}
			else if (StageNumber == 5)
			{
				UpdateScore = MainLevel5.Timer * _ScoreReducePerSec;
			}
			//earthquake
			else if (StageNumber == 6) 
			{
				if (MainLevel6.StartGameplay)
				{
					UpdateScore = MainLevel6.Timer * _ScoreReducePerSec;
				}
				else
				{
					//centralized gameplay to earthquake only
					UpdateScore = 85 * MainLevel6.ReputationBar.value; //8500
				}


			}
			else if (StageNumber == 7)
			{
				UpdateScore = MainLevel7.Timer * _ScoreReducePerSec;
			}
			else if (StageNumber == 8)
			{
				UpdateScore = (MainLevel8.Timer+ScoreAdjustmentDueToHigherLevel) * _ScoreReducePerSec;//
			}

			//typhoon
			else if (StageNumber == 9)
			{

				if (MainLevel9.StartGameplay) 
				{
					UpdateScore = (MainLevel9.Timer + ScoreAdjustmentDueToHigherLevel) * _ScoreReducePerSec;
					//UpdateScore = MainLevel7.Timer * _ScoreReducePerSec;
				}
				else
				{
					//centralized gameplay to typhooon only
					//TyphoonGamePlayStage09 _typhoonGamePlay = GetComponent<TyphoonGamePlayStage09>();
					//UpdateScore = _typhoonGamePlay.CurrentHealth * _ScoreReducePerSec;
					//UpdateScore = 23.742f * MainLevel9.ReputationBar.value; //23742

					//UpdateScore = (MainLevel9.ReputationBar.value); // get score base on main health bar
					UpdateScore = (MainLevel9.Timer + ScoreAdjustmentDueToHigherLevel) * _ScoreReducePerSec;
					UpdateScore *= MainLevel9.ReputationBar.value;

				}

			}
			else if (StageNumber == 10)
			{
				UpdateScore = MainLevel10.Timer * _ScoreReducePerSec;

			}

			UpdateScoreStage = Convert.ToInt32(Math.Round(UpdateScore));
			DisplayScore.text = UpdateScoreStage.ToString();
			
		}

		public void DecreaseScoreTimed()
		{
			_ScoreReducePerSec = StageTotalScore / _MaximumTimer;
		}
		public void GetMaximumTimer()
		{
			
			_MaximumTimer = (StageTotalScore * LevelOfDifficultyStage)/ MissionCountStage;

			if (StageNumber == 1)
			{
				MainLevel1.MaxTimer = _MaximumTimer;
				MainLevel1.Timer = _MaximumTimer;
			}

			else if (StageNumber == 2)
			{
				MainLevel2.MaxTimer = _MaximumTimer;
				MainLevel2.Timer = _MaximumTimer;
			}
			else if (StageNumber == 3)
			{
				MainLevel3.MaxTimer = _MaximumTimer;
				MainLevel3.Timer = _MaximumTimer;
			}
			else if (StageNumber == 4)
			{
				MainLevel4.MaxTimer = _MaximumTimer;
				MainLevel4.Timer = _MaximumTimer;
			}
			else if (StageNumber == 5)
			{
				MainLevel5.MaxTimer = _MaximumTimer;
				MainLevel5.Timer = _MaximumTimer;
			}
			else if (StageNumber == 6)
			{
				MainLevel6.MaxTimer = _MaximumTimer;
				MainLevel6.Timer = _MaximumTimer;
			}
			else if (StageNumber == 7)
			{
				MainLevel7.MaxTimer = _MaximumTimer;
				MainLevel7.Timer = _MaximumTimer;
			}
			else if (StageNumber == 8)
			{
				MainLevel8.MaxTimer = _MaximumTimer;
				MainLevel8.Timer = _MaximumTimer;
			}
			else if (StageNumber == 9)
			{
				MainLevel9.MaxTimer = _MaximumTimer;
				MainLevel9.Timer = _MaximumTimer;
			}
			else if (StageNumber == 10)
			{
				MainLevel10.MaxTimer = _MaximumTimer;
				MainLevel10.Timer = _MaximumTimer;
			}


		}

		public void GetHighestScorePerStage()
		{
			switch (StageNumber)
			{
				case 1:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_1");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_1", UpdateScoreStage);
					}
					break;
				case 2:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_2");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_2", UpdateScoreStage);
					}
					break;
				case 3:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_3");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_3", UpdateScoreStage);
					}
					break;
				case 4:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_4");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_4", UpdateScoreStage);
					}
					break;
				case 5:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_5");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_5", UpdateScoreStage);
					}
					break;
				case 6:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_6");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_6", UpdateScoreStage);
					}
					break;
				case 7:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_7");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_7", UpdateScoreStage);
					}
					break;
				case 8:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_8");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_8", UpdateScoreStage);
					}
					break;
				case 9:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_9");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_9", UpdateScoreStage);
					}
					break;
				case 10:
					GetStagePlayerScore = PlayerPrefs.GetInt("MainTotalScore_Stage_10");
					if (GetStagePlayerScore <= UpdateScore)
					{
						UpdateScoreStage = Convert.ToInt32(UpdateScore);
						PlayerPrefs.SetInt("MainTotalScore_Stage_10", UpdateScoreStage);
					}
					break;
				default:
					
					break;
			}
		}

		public void AddUpTotalScore()
		{
			//PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES");
			GetHighestScorePerStage();
			Debug.Log("called");
			PlayerTotalScore =
			PlayerPrefs.GetInt("MainTotalScore_Stage_1") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_2") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_3") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_4") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_5") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_6") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_7") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_8") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_9") +
			PlayerPrefs.GetInt("MainTotalScore_Stage_10");

			PlayerPrefs.SetInt("MainTotalScore_ALLSTAGES", PlayerTotalScore);

			if (!hasInstantiated)
			{
				_onlineDetector.UpdatePlayerRankOnStageClear();
				hasInstantiated = true;
			}


			if (_leaderBoard.Online == true)
			{
				if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1)
				{
					_leaderBoard.SaveDataScoreData();
				}
				
			}
		}

		







		





	}
}
