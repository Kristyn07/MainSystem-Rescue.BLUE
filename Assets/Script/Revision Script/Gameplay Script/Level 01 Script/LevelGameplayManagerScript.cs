using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using GameplayManager.Level;
using Centralize.UI;


namespace GameplayManager.Level
{
    public class LevelGameplayManagerScript : MonoBehaviour
    {
        [SerializeField]
        int StageNo;

        [SerializeField]
        Button InspectButton;

        public int MissionTaskCount;

        public
        GameObject[] InspectMission;

       
        public GameObject[] PopUpMission;

        [SerializeField]
        GameObject[] PopUpMissionTraining;

        [SerializeField]
        GameObject[] HiddenObject;

        [SerializeField]
        Canvas MiniGameCanvas;

        public
        Canvas PlayerCanvas;

        //Timer Bar
        public
        Slider ReputationBar;
        public
        float MaxTimer;
        
        public float Timer;
        public bool StartGameplay;

        [SerializeField]
        TaskIsComplete taskIsComplete;
        [SerializeField]
        BoxCollider2D taskisCompleteCol;

        [SerializeField]
        Objectives objectives;
        [SerializeField]
        BoxCollider2D objectivesCol;

        [SerializeField]
        GameObject GameOverObj;

        //[SerializeField]
        //ScoreManagerScript MainScore;

        //Continue
        [SerializeField]
        int ContinueScene;

        [SerializeField]
        bool CallStage04;
        CentralizeLevel04GameplayManagerScript MainLevel04;

        //pause for intermission
        [SerializeField]DialogManager_Toturial _dialogManager_Toturial;


        [Header("CallStage")]
        [SerializeField] bool CallStage05;
        CentralizeLevel05GameplayManagerScript MainLevel05;
        [SerializeField] bool CallStage06;
        CentralizeLevel06GameplayManagerScript MainLevel06;
        [SerializeField] bool CallStage07;
        CentralizeLevel07GameplayManagerScript MainLevel07;
        [SerializeField] bool CallStage08;
        CentralizeLevel08GameplayManagerScript MainLevel08;
        [SerializeField] bool CallStage09;
        CentralizeLevel09GameplayManagerScript MainLevel09;
        [SerializeField] bool CallStage10;
        CentralizeLevel10GamePlayManagerScript MainLevel10;

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
            if (CallStage04 == true)
            {
                MainLevel04 = GameObject.FindObjectOfType<CentralizeLevel04GameplayManagerScript>();
            }
            if (CallStage05 == true)
            {
                MainLevel05 = GameObject.FindObjectOfType<CentralizeLevel05GameplayManagerScript>();
            }
            if (CallStage06 == true)
			{
                MainLevel06 = GameObject.FindObjectOfType<CentralizeLevel06GameplayManagerScript>();
            }
            if (CallStage07 == true)
			{
                MainLevel07 = GameObject.FindObjectOfType<CentralizeLevel07GameplayManagerScript>();
            }
            if (CallStage08 == true)
            {
                MainLevel08 = GameObject.FindObjectOfType<CentralizeLevel08GameplayManagerScript>();
            }
            if (CallStage09 == true)
			{
                MainLevel09 = GameObject.FindObjectOfType<CentralizeLevel09GameplayManagerScript>();

            }
            if (CallStage10 == true)
            {
                MainLevel10 = GameObject.FindObjectOfType<CentralizeLevel10GamePlayManagerScript>();

            }

            StartGameplay = false;
            PlayerPrefs.SetInt("Continue", ContinueScene);

            //MaxTimer = 

        }

        // Update is called once per frame
        void Update()
        {
            
            if (StageNo == 1)
			{
                if (StartGameplay == true)
                {
                    if (_dialogManager_Toturial.isinToturialMode == false)
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

                        if (taskIsComplete.isComplete == true)
                        {
                            taskisCompleteCol.enabled = false;
                        }

                        if (objectives.isComplete == true)
                        {
                            objectivesCol.enabled = false;
                        }
                    }
                }
            }

            else if (StageNo != 1)
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
            }

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
            //SceneManager.LoadScene(intID);
            //*StartCoroutine(DelayLoadScene(intID));
            TextLoad.Start();
            loadScene.LoadScene(intID);
            






        }

        IEnumerator DelayLoadScene(int intID)
        {
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene(intID);
        }

        public void QuitButton()
        {
            StartCoroutine(DelayQuit());
        }
        IEnumerator DelayQuit()
        {
            yield return new WaitForSeconds(.5f);
            Debug.Log("Quit App/Game");
            Application.Quit();

        }
        public void CallStage04Function(string StringID)
        {

        }

        public void StartReputationBar(bool StartGame)
		{
            if (StartGame == true)
            {
                StartGameplay = true;
            }
            
        }

        public void _Show_InspectMission()
        {
            PlayerCanvas.enabled = false;
            MiniGameCanvas.enabled = true;

        }
    }
}

