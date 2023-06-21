using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using CollisionCheck.Manager;

namespace GameplayManager.Level
{
    public class CentralizeLevel08GameplayManagerScript : MonoBehaviour
    {
        LevelGameplayManagerScript MainLevel;
        ScoreManagerScript MainScore;
        CentralizeCollisionCheckScript MainCol;

        StageComplete MainStageComplete;
        [SerializeField]
        Button InspectButton;
        
        public BoxCollider2D[] MissionCol;
        [SerializeField]
        GameObject[] MissionCount;

        public int FireExtingiusherAnimCount;
        public int CountControl;

        [SerializeField] CameraFollow _cameraFollow;

        [Header("Centralize Collision")]
        [SerializeField] Text EnteringText;
        [SerializeField] GameObject Fade;
        //[SerializeField] GameObject DefaultFade;
        [SerializeField] GameObject MainPlayer;
        [SerializeField] Vector3 HHQOutside;
        //[SerializeField] GameObject HHQObjOut;
        [SerializeField] Vector3 HHQInside;
        //[SerializeField] GameObject HHQObjIn;
        [Header("Elevator")]
        [SerializeField] GameObject Elevator;
        [SerializeField] Vector3 FloorOne;
        [SerializeField] Vector3 FloorTwo;
        [SerializeField] Vector3 FloorThree;
        [SerializeField] Animator Buttons;
        [SerializeField] Animator ElevatorOpenClose;
        //[SerializeField] GameObject OverWorld;
        [Header("TrashCanUI")]
        [SerializeField] Animator[] CloseTrashcan;

        void Start()
        {
            MainLevel = GameObject.FindObjectOfType<LevelGameplayManagerScript>();
            MainScore = GameObject.FindObjectOfType<ScoreManagerScript>();
            MainStageComplete = GameObject.FindObjectOfType<StageComplete>();
            MainCol = GameObject.FindObjectOfType<CentralizeCollisionCheckScript>();
            //HHQOutside = HHQObjOut.GetComponent<Transform>().position;
            //HHQInside = HHQObjIn.GetComponent<Transform>().position;

        }

        public void CloseMiniGame()
        {
            InspectButton.interactable = true;
            MainScore.DecreasePoints(1);
            MainLevel.HideInspectMission();
        }
        public void FinishStage()
        {
            
            MainStageComplete.MissionCount += 1;
            MainScore.DisableTimer();
            Invoke("CloseWindow", 2.8f);
        }

        public void HasANewOverWorld() // attach this to inspector has new code
        {

            if (MainLevel.MissionTaskCount == 0)
            {
                EnteringText.text = "You are now entering the Risk Reduction Headquarters...";
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = HHQInside;
                //_cameraFollow.IsEnteringMiniGameOverWorld = true;
                //OverWorld.SetActive(true);

            }
            if (MainLevel.MissionTaskCount == 1) 
            {
                EnteringText.text = "You are now exiting the Risk Reduction Headquarters...";
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = HHQOutside;
            }
            if (MainLevel.MissionTaskCount == 6) // elevator
			{
                //DefaultFade.SetActive(true);
                MainLevel.HideInspectMission();
                StartCoroutine(ElevatorRoute());
                
            }
            if (MainLevel.MissionTaskCount == 10)//drinaige
			{
                //StartCoroutine(CloseTrashBin());
            }

        }

        public void CloseTheDropCoverHoldMiniGame()
        {
            _cameraFollow.IsEnteringMiniGameOverWorld = false;
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
                MainPlayer.transform.position = new Vector3 (FloorThree.x, (FloorThree.y- 2.2767f),FloorThree.z);
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

        



    }
}
