using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Score.System // redo remove on 1
{
    public class ScoreManagerScript : MonoBehaviour
    {
        [SerializeField]
        Text ScoreText;

        public int FirstAidKitScore;

        public int BandageScore;
        [SerializeField]
        int FireExtinguisherScore;

        public int TotalScore;
        public int MainTotalScore;

        //[SerializeField]
        [SerializeField] int ExtraScore;
        [SerializeField] bool GameTimer;

        [SerializeField] float Timer;
        [SerializeField] bool TimerControl;

        //Reputation Score
        [SerializeField]
        int ReputataionScore;
        float ReputationTimer;
        bool ReputationTimerControl;
        public bool ReputationGame;

        private void Awake()
        {
            MainTotalScore =  PlayerPrefs.GetInt("Main Total Score");
            //MainTotalScore = 0;
        }
        // Start is called before the first frame update
        void Start()
        {
            ReputationGame = true;
        }

        // Update is called once per frame
        void Update()
        {
            TotalScore = FirstAidKitScore + BandageScore + ExtraScore + ReputataionScore + FireExtinguisherScore;
            //ScoreText.text = TotalScore.ToString();

            if (GameTimer == true)
            {
                if (TimerControl == false)
                {
                    Timer = 3;
                    TimerControl = true;
                }

                Timer -= Time.deltaTime;

                if (Timer <= 0)
                {
                    if (TimerControl == true)
                    {
                        Timer = 0;

                        ExtraScore -= 1;

                        if (ExtraScore <= 0)
                        {
                            ExtraScore = 0;
                        }
                        TimerControl = false;
                    }
                }
            }

            if (ReputationGame == true)
            {
                if (ReputationTimerControl == false)
                {
                    ReputationTimer = 3;
                    ReputationTimerControl = true;
                }

                ReputationTimer -= Time.deltaTime;

                if (ReputationTimer <= 0)
                {
                    if (ReputationTimerControl == true)
                    {
                        ReputationTimer = 0;

                        ReputataionScore -= 1;

                        if (ReputataionScore <= 0)
                        {
                            ReputataionScore = 0;
                        }
                        ReputationTimerControl = false;
                    }
                }
            }
        }
        public void DecreaseFirstAidKitScore(int IDScoreCount)
        {
            if (IDScoreCount == 0)
            {
                GameTimer = false;
                TimerControl = false;
                FirstAidKitScore -= 100;
            }

            if (IDScoreCount == 1)
            {
                GameTimer = false;
                TimerControl = false;
                BandageScore -= 100;
            }
          
        }

        public void DecreasePoints(int IDScoreCount)
        {
            if (IDScoreCount == 0)
            {
                GameTimer = false;
                TimerControl = false;
                FirstAidKitScore -= 100;
            }

            if (IDScoreCount == 1)
            {
                GameTimer = false;
                TimerControl = false;
                BandageScore -= 100;
            }
        }

        public void ActivateTimer()
        {

                GameTimer = true;
                TimerControl = false;
           
        }

        public void DisableTimer()
        {
            GameTimer = false;
            TimerControl = false;
        }

        public void AddUpTotalScore()
        {
            // Main Total Score Add Up
            //MainTotalScore = 0;
            MainTotalScore += TotalScore;
            if (MainTotalScore >= 9999)
            {
                MainTotalScore = 9999;
                PlayerPrefs.SetInt("Main Total Score", MainTotalScore);
            }
            if (MainTotalScore < 9999)
            {
                PlayerPrefs.SetInt("Main Total Score", MainTotalScore);
            }
        }

    }
}

