using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using CollisionCheck.Manager;
namespace GameplayManager.Level
{
    public class CentralizeLevel05GameplayManagerScript : MonoBehaviour
    {
        LevelGameplayManagerScript MainLevel;
        //ScoreManagerScript MainScore;
        CentralizeCollisionCheckScript MainCol;

        StageComplete MainStageComplete;
        [SerializeField]
        Button InspectButton;
        [SerializeField]
        BoxCollider2D[] MissionCol;
        [SerializeField]
        GameObject[] MissionCount;

        public int FireExtingiusherAnimCount;
        public int CountControl;

        [Header("DropCoverHold")]
        [SerializeField] CameraFollow _cameraFollow;
        [SerializeField] GameObject OverWorld;
       
        void Start()
        {
            MainLevel = GameObject.FindObjectOfType<LevelGameplayManagerScript>();
            //MainScore = GameObject.FindObjectOfType<ScoreManagerScript>();
            MainStageComplete = GameObject.FindObjectOfType<StageComplete>();
            MainCol = GameObject.FindObjectOfType<CentralizeCollisionCheckScript>();
            FireExtingiusherAnimCount = 1;
        }

        

        public void CloseMiniGame()
        {
            InspectButton.interactable = true;
            //MainScore.DecreasePoints(1);
            MainLevel.HideInspectMission();
        }
        public void FinishStage()
        {
            /*MissionCol[CountControl].enabled = false;
            MissionCount[CountControl].gameObject.SetActive(false);
            InspectButton.interactable = false;*/
            //MainStageComplete.MissionCount += 1;
            //MainLevel.HideInspectMission();
            //MainScore.DisableTimer();
            Invoke("CloseWindow", 2.8f);
        }

        public void FireExtinguisherIncreaseCount()
        {

            FireExtingiusherAnimCount += 1;
        }

        public void ResetCount()
        {
            FireExtingiusherAnimCount = 1;

        }
        public void CloseWindow()
        {
            MissionCol[CountControl].enabled = false;
            MissionCount[CountControl].gameObject.SetActive(false);
            InspectButton.interactable = false;
            MainLevel.HideInspectMission();
        }

        public void HasANewOverWorld() 
		{
            /*//PopUpMissionTraining[MissionTaskCount].gameObject.SetActive(true);
            //PopUpMissionTraining[MissionTaskCount].gameObject.SetActive(true)
            if ()*/

            
            if (MainLevel.MissionTaskCount == 3)
			{
                _cameraFollow.IsEnteringMiniGameOverWorld = true;
                OverWorld.SetActive(true);

            }

        }

		public void CloseTheDropCoverHoldMiniGame()
		{
            _cameraFollow.IsEnteringMiniGameOverWorld = false;
        }



	}
}

