using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using Mission.Control;
using Centralize.UI;

namespace GameplayManager.Level // 2,3
{
    public class Level02GameplayManagerScript : MonoBehaviour
    {
        [SerializeField]
        Button InspectButton;

        public int MissionTaskCount;

        [SerializeField]
        GameObject[] InspectMission;

        [SerializeField]
        GameObject[] PopUpMission;

        [SerializeField]
        GameObject[] PopUpMissionTraining;

        [SerializeField]
        GameObject[] HiddenObject;

        [SerializeField]
        Canvas MiniGameCanvas;

        public
        Canvas PlayerCanvas;

        //Timer Bar
        [SerializeField]
        Slider ReputationBar;
        
        public float MaxTimer;
        
        public float Timer;
        public bool StartGameplay;

        //[SerializeField]
        //TaskIsComplete taskIsComplete;
        //[SerializeField]
        //BoxCollider2D taskisCompleteCol;

        //[SerializeField]
        //Objectives objectives;
        //[SerializeField]
        //BoxCollider2D objectivesCol;

        [SerializeField]
        GameObject GameOverObj;

        

        //Continue
        [SerializeField]
        int ContinueScene;

        
        [SerializeField]
        DialogManager_GamePlay _dialogManager_GamePlay;

        [SerializeField] LoadingScreenRandomizeInfo TextLoad;
        [SerializeField] SceneLoader loadScene;

        [SerializeField] InspectButtonCentralize _inspectBehavior;

        void Awake()
        {
            InspectButton.interactable = false;
        }
        // Start is called before the first frame update
        void Start()
        {
            //StartGameplay = true;
            PlayerPrefs.SetInt("Continue", ContinueScene);
        }

        // Update is called once per frame
        void Update()
        {
            
            if (StartGameplay == true)
                {
                    ReputationBar.value = Timer / MaxTimer;
                    Timer -= Time.deltaTime;

                        if (ReputationBar.value <= 0)
                        {
                            Timer = 0;
                            StartGameplay = false;
                            //MainScore.ReputationGame = false;
                            GameOver();
                        }
                }

            
				
            
            

            //if (taskIsComplete.isComplete == true)
            //{
            //    taskisCompleteCol.enabled = false;
            //}

            //if (objectives.isComplete == true)
            //{
            //    objectivesCol.enabled = false;
            //}

        }

           

        void GameOver()
        {
            MiniGameCanvas.enabled = false;
            PlayerCanvas.enabled = true;
            GameOverObj.gameObject.SetActive(true);
        }

        public void ShowPopUpHidden()
        {
            HiddenObject[MissionTaskCount].gameObject.SetActive(true);
        }

        public void HidePopUpHidden()
        {
            HiddenObject[MissionTaskCount].gameObject.SetActive(false);
            MissionTaskCount = 999;
        }

        public void ShowMissionPopUpTraining()
        {
            PopUpMissionTraining[MissionTaskCount].gameObject.SetActive(true);
        }

        public void HideMissionPopUpTraining()
        {
           
            PopUpMissionTraining[MissionTaskCount].gameObject.SetActive(false);
            MissionTaskCount = 999;
        }
        public void ShowMissionPopUp()
        {
            InspectButton.interactable = true;
            PopUpMission[MissionTaskCount].gameObject.SetActive(true);
        }
        public void HideMissionPopUp()
        {
            
            InspectButton.interactable = false;
            PopUpMission[MissionTaskCount].gameObject.SetActive(false);
            MissionTaskCount = 999;
        }

        public void ShowInspectMission()
        {
            PlayerCanvas.enabled = false;
            MiniGameCanvas.enabled = true;
            _inspectBehavior.InspectMissionOpen();
            InspectMission[MissionTaskCount].gameObject.SetActive(true);
        }

        public void HideInspectMission()
        {
            //MissionTaskCount = 999;
            MiniGameCanvas.enabled = false;
            PlayerCanvas.enabled = true;
            _inspectBehavior.InspectMissionClose();
            //InspectMission[MissionTaskCount].gameObject.SetActive(true);
        }

        public void LoadSceneButtin(int intID)
        {
            //*SceneManager.LoadScene(intID);
            TextLoad.Start();
            loadScene.LoadScene(intID);
        }

        public void QuitButton()
        {
            Debug.Log("Quit App/Game");
            Application.Quit();
        }


        public void startGame()
		{
            if (_dialogManager_GamePlay.IsDone == true)
            {
                StartGameplay = true;
            }
        }

    }
}

