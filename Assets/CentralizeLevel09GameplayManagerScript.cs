using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using CollisionCheck.Manager;

namespace GameplayManager.Level
{
    public class CentralizeLevel09GameplayManagerScript : MonoBehaviour
    {
        LevelGameplayManagerScript MainLevel;
        ScoreManagerScript MainScore;
        CentralizeCollisionCheckScript MainCol;

        StageComplete MainStageComplete;
        [SerializeField] Button InspectButton;

        public BoxCollider2D[] MissionCol;
        [SerializeField] GameObject[] MissionCount;
        public int CountControl;


        [Header("Doors And Stairs")]
        [SerializeField] GameObject Fade;
        [SerializeField] GameObject MainPlayer;
        [Header("Setposition")]
        [SerializeField] float value = 1.45f;
        //gameobject
        [SerializeField] GameObject GEnterTheHouse;
        [SerializeField] GameObject GExitTheHouse;
        [SerializeField] GameObject GStairsUp;
        [SerializeField] GameObject GStairsDown;
        [SerializeField] GameObject GEnterRoom_1;
        [SerializeField] GameObject GEnterRoom_2;
        [SerializeField] GameObject GExitRoom_1;
        [SerializeField] GameObject GExitRoom_2;
        // Positions
        [SerializeField] Vector3 EnterTheHouse;
        [SerializeField] Vector3 ExitTheHouse;
        [SerializeField] Vector3 StairsUp;
        [SerializeField] Vector3 StairsDown;
        [SerializeField] Vector3 EnterRoom_1;
        [SerializeField] Vector3 EnterRoom_2;
        [SerializeField] Vector3 ExitRoom_1;
        [SerializeField] Vector3 ExitRoom_2;

        [SerializeField] float valuee;

        [Header("MiniGameGamePlay")]
        [SerializeField] Overworld_ChargeThePhone _taskCompletePlugOnly;
        [SerializeField] Animator anim;

        // Start is called before the first frame update
        void Start()
        {
            MainLevel = GameObject.FindObjectOfType<LevelGameplayManagerScript>();
            MainScore = GameObject.FindObjectOfType<ScoreManagerScript>();
            MainStageComplete = GameObject.FindObjectOfType<StageComplete>();
            MainCol = GameObject.FindObjectOfType<CentralizeCollisionCheckScript>();

            EnterTheHouse = GEnterTheHouse.transform.position;
            ExitTheHouse = GExitTheHouse.transform.position;
            StairsUp = GStairsUp.transform.position;
            StairsDown = GStairsDown.transform.position;
            EnterRoom_1 = GEnterRoom_1.transform.position;
            ExitRoom_1 = GExitRoom_1.transform.position;
            EnterRoom_2 = GEnterRoom_2.transform.position;
            ExitRoom_2 = GExitRoom_2.transform.position;

            //adjust door vector3
            EnterTheHouse.y -= 1.1188f; //-10.51-9.3912
            ExitTheHouse.y -= value;
            StairsUp.y = 25.96159f;
            StairsDown.y = 32.6f; 
            EnterRoom_1.y -= value;
            EnterRoom_2.y -= value;
            ExitRoom_1.y -= value;
            ExitRoom_2.y -= value;

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
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitTheHouse;
            }//enter house
            if (MainLevel.MissionTaskCount == 1)
			{
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterTheHouse;
            }//exit house
            if (MainLevel.MissionTaskCount == 2)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = StairsDown;
            }//stairsup
            if (MainLevel.MissionTaskCount == 3)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = StairsUp;
            }//stairsdown
            if (MainLevel.MissionTaskCount == 4)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitRoom_1;
            }//enter r1
            if (MainLevel.MissionTaskCount == 5)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = ExitRoom_2;

            }//enter r2
            if (MainLevel.MissionTaskCount == 6)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterRoom_1;
            }//exir r1
            if (MainLevel.MissionTaskCount == 7)
            {
                Fade.SetActive(true);
                MainLevel.HideInspectMission();
                MainPlayer.transform.position = EnterRoom_2;
            }//exit r2
            if (MainLevel.MissionTaskCount == 11) // electricfan
			{
                Debug.Log("called");
               _taskCompletePlugOnly.RemoveOnePlug(anim);
            }
            

        }

    }
}
