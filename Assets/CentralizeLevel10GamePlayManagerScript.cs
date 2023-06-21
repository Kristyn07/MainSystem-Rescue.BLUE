using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using CollisionCheck.Manager;

namespace GameplayManager.Level
{
    public class CentralizeLevel10GamePlayManagerScript : MonoBehaviour
    {
        [SerializeField]LevelGameplayManagerScript MainLevel;
        ScoreManagerScript MainScore;
        CentralizeCollisionCheckScript MainCol;

        //StageComplete MainStageComplete;
        [SerializeField] Button InspectButton;

        public BoxCollider2D[] MissionCol;
        [SerializeField] GameObject[] MissionCount;
        public int CountControl;

        [Header("Interactable Doors")]
        [SerializeField] Camera MainCamera;
        [SerializeField] Canvas MiniGameCanvas;
        [SerializeField] CameraFollow _camScript;
        [SerializeField] GameObject Fade;
        [SerializeField] GameObject MainPlayer;
        [Header("Positions")]
        [SerializeField] GameObject GEnterRTC;
        [SerializeField] Vector3 EnterTheRTC;
        [SerializeField] GameObject GExitRTC;
        [SerializeField] Vector3 ExitTheRTC;
        [Header("Doors")]
        [SerializeField] float Exit;
        [SerializeField] float Enter;
        [Header("Earthquake")]
        [SerializeField] GameObject GEnterEarthquake;
        [SerializeField] Vector3 EnterEarthquake;
        [SerializeField] GameObject GExitEarthquake;
        [SerializeField] Vector3 ExitEarthquake;
        [Header("FirstAid")]
        [SerializeField] GameObject GEnterFirstAid;
        [SerializeField] Vector3 EnterFirstAid;
        [SerializeField] GameObject GExitFirstAid;
        [SerializeField] Vector3 ExitFirstAid;
        [Header("Fire")]
        [SerializeField] GameObject GEnterFire;
        [SerializeField] Vector3 EnterFire;
        [SerializeField] GameObject GExitFire;
        [SerializeField] Vector3 ExitFire;
        [Header("Bandage")]
        [SerializeField] GameObject GEnterBandage;
        [SerializeField] Vector3 EnterBandage;
        [SerializeField] GameObject GExitBandage;
        [SerializeField] Vector3 ExitBandage;
        [Header("Flooding")]
        [SerializeField] GameObject GEnterFlooding;
        [SerializeField] Vector3 EnterFlooding;
        [SerializeField] GameObject GExitFlooding;
        [SerializeField] Vector3 ExitFlooding;

        [Header("Elevator")]
        [SerializeField] GameObject Elevator;
        [SerializeField] Vector3 FloorOne;
        [SerializeField] Vector3 FloorTwo;
        [SerializeField] Vector3 FloorThree;
        [SerializeField] Vector3 FloorFour;
        [SerializeField] Vector3 FloorFive;
        [SerializeField] Animator Buttons;
        [SerializeField] Animator ElevatorOpenClose;

        // Start is called before the first frame update


        public int FireExtingiusherAnimCount;
        //public int CountControl;

        void Start()
        {
            MainLevel = GameObject.FindObjectOfType<LevelGameplayManagerScript>();
            MainScore = GameObject.FindObjectOfType<ScoreManagerScript>();
            //MainStageComplete = GameObject.FindObjectOfType<StageComplete>();
            MainCol = GameObject.FindObjectOfType<CentralizeCollisionCheckScript>();
            //RTC
            EnterTheRTC = GEnterRTC.transform.position;
            ExitTheRTC = GExitRTC.transform.position;
            EnterTheRTC.y -= 1.7f; //-10.51-9.3912
            ExitTheRTC.y -= 1.8f;
            //eartquake
            EnterEarthquake = GEnterEarthquake.transform.position;
            ExitEarthquake = GExitEarthquake.transform.position;
            EnterEarthquake.y -= Enter;
            ExitEarthquake.y -= Exit;
            EnterEarthquake.z = 0;
            ExitEarthquake.z = 0;
            //EnterTheRTC.y -= 1.7f; //-10.51-9.3912
            //ExitTheRTC.y -= 1.8f;
            //firstaid
            EnterFirstAid = GEnterFirstAid.transform.position;
            ExitFirstAid = GExitFirstAid.transform.position;
            EnterFirstAid.y -= Enter;
            ExitFirstAid.y -= Exit;

            EnterFirstAid.z = 0;
            ExitFirstAid.z = 0;

            EnterFire = GEnterFire.transform.position;
            ExitFire = GExitFire.transform.position;
            EnterFire.y -= Enter;
            ExitFire.y -= Exit;

            EnterFire.z = 0;
            ExitFire.z = 0;

            EnterBandage = GEnterBandage.transform.position;
            ExitBandage = GExitBandage.transform.position;
            EnterBandage.y -= Enter;
            ExitBandage.y -= Exit;
            EnterBandage.z = 0;
            ExitBandage.z = 0;

            EnterFlooding = GEnterFlooding.transform.position;
            ExitFlooding = GExitFlooding.transform.position;
            EnterFlooding.y -= Enter;
            ExitFlooding.y -= Exit;
            EnterFlooding.z = 0;
            ExitFlooding.z = 0;








        }

        public void CloseMiniGame()
        {
            InspectButton.interactable = true;
            MainScore.DecreasePoints(1);
            MainLevel.HideInspectMission();
        }
        public void FinishStage()
        {

            //MainStageComplete.MissionCount += 1;
            //MainScore.DisableTimer();
            Invoke("CloseWindow", 2.8f);
        }

        public void HasANewOverWorld() // attach this to inspector has new code
        {

            if (MainLevel.MissionTaskCount == 0)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainCamera.orthographicSize = 5f;
                _camScript.Stage10 = false;
                MainPlayer.transform.position = ExitTheRTC;
            }//enter RTC
            if (MainLevel.MissionTaskCount == 1)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainCamera.orthographicSize = 11.95355f;
                _camScript.Stage10 = true;
                MainPlayer.transform.position = EnterTheRTC;
            }//exit RTC
            if (MainLevel.MissionTaskCount == 2)
            {
               
                MainLevel.HideInspectMission();
                StartCoroutine(ElevatorRoute());
            }//elevator
            if (MainLevel.MissionTaskCount == 7)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitEarthquake;
            }//enter Earthquake
            if (MainLevel.MissionTaskCount == 8)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitFirstAid;
            }//enter 
            if (MainLevel.MissionTaskCount == 9)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitFire;
            }//enter 
            if (MainLevel.MissionTaskCount == 10)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitBandage;
            }//enter 
            if (MainLevel.MissionTaskCount == 11)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitFlooding;
            }//enter 
            if (MainLevel.MissionTaskCount == 12)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterEarthquake;
            }//exit
            if (MainLevel.MissionTaskCount == 13)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterFire;
            }//exit
            if (MainLevel.MissionTaskCount == 14)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterFirstAid;
            }//exit
            if (MainLevel.MissionTaskCount == 15)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterBandage;
            }//exit
            if (MainLevel.MissionTaskCount == 16)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterFlooding;
            }//exit
            if (MainLevel.MissionTaskCount == 17)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            }
            if (MainLevel.MissionTaskCount == 18)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            }
            if (MainLevel.MissionTaskCount == 19)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            }

            if (MainLevel.MissionTaskCount == 20)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            }
            if (MainLevel.MissionTaskCount == 21)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
                
            }//firetype
            if (MainLevel.MissionTaskCount == 22)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

            }//fireextinguisher
            if (MainLevel.MissionTaskCount == 23)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            }//cleandrainaige....
            if (MainLevel.MissionTaskCount == 24)
            {
                MiniGameCanvas.renderMode = RenderMode.ScreenSpaceOverlay;

            }//identifyflood causes
            if (MainLevel.MissionTaskCount == 25)
            {
                _camScript.IsEnteringMiniGameOverWorld = true;
                MainCamera.orthographicSize = 5f;
                //OverWorld.SetActive(true);

            }
        }

        public void ElevatorFunction(int FloorNumber)
        {
            if (FloorNumber == 1)
            {
                StartCoroutine(CloseElevatorRoute());
                Elevator.transform.position = FloorOne;
                MainPlayer.transform.position = new Vector3(FloorOne.x, (FloorOne.y - 2.2767f), FloorOne.z);
            }
            else if (FloorNumber == 2)
            {
                StartCoroutine(CloseElevatorRoute());
                Elevator.transform.position = FloorTwo;
                MainPlayer.transform.position = new Vector3(FloorTwo.x, (FloorTwo.y - 2.2767f), FloorTwo.z);
            }
            else if (FloorNumber == 3)
            {
                StartCoroutine(CloseElevatorRoute());
                Elevator.transform.position = FloorThree;
                MainPlayer.transform.position = new Vector3(FloorThree.x, (FloorThree.y - 2.2767f), FloorThree.z);
            }
            else if (FloorNumber == 4)
            {
                StartCoroutine(CloseElevatorRoute());
                Elevator.transform.position = FloorFour;
                MainPlayer.transform.position = new Vector3(FloorFour.x, (FloorFour.y - 2.2767f), FloorFour.z);
            }
            else if (FloorNumber == 5)
            {
                StartCoroutine(CloseElevatorRoute());
                Elevator.transform.position = FloorFive;
                MainPlayer.transform.position = new Vector3(FloorFive.x, (FloorFive.y - 2.2767f), FloorFive.z);
            }

        }

        public IEnumerator ElevatorRoute()
        {
            ElevatorOpenClose.SetBool("IsOpening", true);
            yield return new WaitForSeconds(0.5f);
            Buttons.SetBool("Button", true);
        }

        public IEnumerator CloseElevatorRoute()
        {
            Buttons.SetBool("Button", false);
            yield return new WaitForSeconds(0.5f);
            ElevatorOpenClose.SetBool("IsOpening", false);
        }


        public void FireExtinguisherIncreaseCount()
        {

            FireExtingiusherAnimCount += 1;
        }


    }
}
