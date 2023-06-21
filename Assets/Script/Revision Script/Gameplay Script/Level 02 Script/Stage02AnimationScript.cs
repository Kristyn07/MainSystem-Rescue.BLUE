using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameplayManager.Level;
using UnityEngine.UI;
using Score.System;
using CollisionCheck.Manager;

namespace Stage02.Animation
{
    public class Stage02AnimationScript : MonoBehaviour
    {
        [SerializeField] Canvas MiniGameCanvas;
        [SerializeField]
        CheckTheAnswer CheckTheAnswer;
        [SerializeField]
        SubTasksIsSuccess MainSubtaskStage02;
        [SerializeField]
        Stage02Complete MainComplete;
        [SerializeField]
        Level02GameplayManagerScript MainControl;
        //[SerializeField]
        //ScoreManagerScript MainScore;

        [SerializeField]
        BoxCollider2D MissionCol;
        [SerializeField]
        Button InspectButton;


        //Other Level
        [SerializeField]
        bool AdditionalStage;
        [SerializeField]
        bool Stage04;
        CentralizeLevel04GameplayManagerScript MainLevel04;
        [SerializeField]
        CentralizeCollisionCheckScript MainCol;

        //Stage 02
        [Header("STAGE 02 TASK")]
        [SerializeField]
        bool Task01;
        [SerializeField]
        bool Task02;
        [SerializeField]
        bool Task03;

        [SerializeField]
        bool Task03First;

        [SerializeField]
        GameObject[] Task03FirstGame;
        [SerializeField]
        GameObject Task03SecondGame;
        [SerializeField]
        GameObject Task03SecondGameSelection;

        [SerializeField]
        GameObject MiniGameObject;

        [SerializeField]
        float DelayWindowClose;

        [SerializeField]
        GameObject CompleteAnim;

        [SerializeField] bool Stage10;
        CentralizeLevel10GamePlayManagerScript MainLevel10;
        [SerializeField]
        LevelGameplayManagerScript MainControl1;

        //[SerializeField] Canvas MiniGame;
        // Start is called before the first frame update
        void Start()
        {
            if (AdditionalStage == true)
            {
                if (Stage04 == true)
                {
                    MainLevel04 = GameObject.FindObjectOfType<CentralizeLevel04GameplayManagerScript>();
                }
                if (Stage10 == true)
                {
                    MainLevel10 = GameObject.FindObjectOfType<CentralizeLevel10GamePlayManagerScript>();

                }
            }
        }

        
        public void Stage02CloseControl()
        {
            //this.gameObject.SetActive(false);
        }
        public void Stage02AnimationControl()
        {
            if (Stage10)
			{
                CompleteAnim.SetActive(true);
                Invoke("CanvasOn", 0);
                Invoke("CloseWindow", DelayWindowClose);
                //Invoke("Cancel", DelayWindowClose);
            }
			else
			{
                if (Task01 == true)
                {
                    MissionCol.enabled = false;
                    MainSubtaskStage02.Task_1();

                    //MainScore.DisableTimer();
                    //MainControl.HideInspectMission();

                    CompleteAnim.SetActive(true);
                    Invoke("CloseWindow", DelayWindowClose);

                    //MiniGameObject.gameObject.SetActive(false);
                }

                if (Task02 == true)
                {
                    MissionCol.enabled = false;
                    MainSubtaskStage02.Task_2();
                    //MainScore.DisableTimer();
                    CompleteAnim.SetActive(true);
                    Invoke("CanvasOn", 0);
                    Invoke("CloseWindow", DelayWindowClose);
                    Invoke("Cancel", DelayWindowClose);
                }



                /*if (Task02 == true)
            {
                
                MissionCol.enabled = false;
                MainSubtaskStage02.Task_2();

                MainScore.DisableTimer();
                //MainControl.HideInspectMission();

                CompleteAnim.SetActive(true);
                Invoke("CloseWindow", DelayWindowClose);

                //MainControl.ShowInspectMission();

                //Dea
                //Invoke("CloseWindow", DelayWindowClose);

                //MiniGameObject.gameObject.SetActive(false);
            }*/


                if (Task03 == true)
                {
                    MissionCol.enabled = false;
                    //MainScore.DisableTimer();
                    MainSubtaskStage02.Task_3();
                    //MainControl.HideInspectMission();
                    CompleteAnim.SetActive(true);
                    //MainControl.ShowInspectMission();
                    Invoke("CloseWindow", DelayWindowClose);

                    //MiniGameObject.gameObject.SetActive(false);
                }

                if (Task03First == true)
                {
                    //Task03SecondGame.gameObject.SetActive(true);
                    //Task03SecondGameSelection.gameObject.SetActive(true);
                    //foreach(GameObject t03f in Task03FirstGame)
                    // {
                    //     t03f.gameObject.SetActive(false);
                    // }
                    //Task03MainObj.gameObject.SetActive(false);
                }
            }
        }
           
        public void AddMissionCount()
        {
            if (AdditionalStage == true)
            {
                if (Stage04 == true)
                {
                    MainCol.CountControl();
                    MainLevel04.FinishStage();
                }
                else if(Stage10 == true)
				{
                    MainCol.CountControl();
                    MainLevel10.FinishStage();
                }
            }

            if (AdditionalStage == false)
            {
                //MainScore.DisableTimer();
                MainComplete.MissionCount += 1;
                InspectButton.interactable = false;
                MissionCol.enabled = false;
                MainControl.HideInspectMission();
            }
            
        }
        //task 2 configuration
        public void CloseWindow()
		{
            MiniGameObject.gameObject.SetActive(false);
            if (Stage10)
			{
                MainControl1.HideInspectMission();
			}
			else
			{
                MainControl.HideInspectMission();

            }
            //MainControl.HideInspectMission();
        }

        public void CanvasOn()
		{
            //*MainControl.ShowInspectMission();
            MiniGameCanvas.enabled = true;
            if (Stage10)
            {
                MainControl1.PlayerCanvas.enabled = false;
            }
            else
            {
                MainControl.PlayerCanvas.enabled = false;
            }


        }
        public void Cancel()
		{
            CancelInvoke("CanvasOn");
        }


        
    }
}
