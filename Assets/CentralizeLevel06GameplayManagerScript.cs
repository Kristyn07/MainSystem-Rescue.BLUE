using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Score.System;
using CollisionCheck.Manager;
namespace GameplayManager.Level
{
    public class CentralizeLevel06GameplayManagerScript : MonoBehaviour
    {
        LevelGameplayManagerScript MainLevel;
        ScoreManagerScript MainScore;
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


        [Header("Changeposition of Player")]
        [SerializeField] GameObject MainPlayer;
        [SerializeField] GameObject ScaleMainPlayer;
        [Header("New")]
        [SerializeField] Vector3 NewPos;
        [SerializeField] Vector3 NewScale; 
        [SerializeField] GameObject NewPosition;
        [Header("Old")]
        [SerializeField] Vector3 OldPos;
        [SerializeField] Vector3 OldScale;

        [Header("StartEarthquakeTrigger")]
        [SerializeField] bool EarthquakeTrigger;
        [SerializeField] GameObject ChangeController;
        [SerializeField] GameObject ChangeMission;
        [SerializeField] GameObject NewController;
        [SerializeField] Animator Anim;
        [SerializeField] OffTrigger ColliderTriggerSwitch;
        [SerializeField] GameObject TiggershakeCam;
        [SerializeField] GameObject StaticGameObjectSprites;
        [SerializeField] MainPlayerMovementScript MainPlayerController;

        [Header("Change Reputation bar")]
        [SerializeField] GameObject FillSliderNewColor;
        [SerializeField] Color NewColor;
        [SerializeField] Image SliderFill;

        [Header("Damage Object")]
        [SerializeField] Collider2D playerCollider;

        [Header("ColliderMinigame")]
        [SerializeField] Collider2D[] MiniGameObject;

        //[SerializeField]
        [SerializeField] GameObject[] ChangeHeirchy;
        [SerializeField] GameObject NewParent;
        [SerializeField] Rigidbody2D ChangeRigidBody;

        [SerializeField] ReputationBarTextUpdate _reputationText;
        [SerializeField] OffTrigger offtriger;

        [SerializeField] GameObject[] OffObject;
        
        void Start()
        {
            MainLevel = GameObject.FindObjectOfType<LevelGameplayManagerScript>();
            MainScore = GameObject.FindObjectOfType<ScoreManagerScript>();
            MainStageComplete = GameObject.FindObjectOfType<StageComplete>();
            MainCol = GameObject.FindObjectOfType<CentralizeCollisionCheckScript>();
            FireExtingiusherAnimCount = 1;

            NewPos = NewPosition.GetComponent<Transform>().position;
            //NewScale = NewPosition.GetComponent<Transform>().localScale;
            //NewScale = new Vector3(2, 2, 2);

            NewColor = FillSliderNewColor.GetComponent<Image>().color;
            Image fillImage = MainLevel.ReputationBar.fillRect.GetComponent<Image>();

            
        }

        

        public void CloseMiniGame()
        {
            InspectButton.interactable = true;
            MainScore.DecreasePoints(1);
            MainLevel.HideInspectMission();
        }
        public void FinishStage()
        {
            /*MissionCol[CountControl].enabled = false;
            MissionCount[CountControl].gameObject.SetActive(false);
            InspectButton.interactable = false;*/
            MainStageComplete.MissionCount += 1;
            //MainLevel.HideInspectMission();
            MainScore.DisableTimer();
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

        public void HasANewOverWorld() //player inspector
        {
            /*//PopUpMissionTraining[MissionTaskCount].gameObject.SetActive(true);
            //PopUpMissionTraining[MissionTaskCount].gameObject.SetActive(true)
            if ()*/


            if (MainLevel.MissionTaskCount == 0) // go Inside
            {
                OldPos = MainPlayer.GetComponent<Transform>().position;
                OldScale = ScaleMainPlayer.GetComponent<Transform>().localScale;

                _cameraFollow.IsEnteringMiniGameOverWorld = true;
                OverWorld.SetActive(true);

                //setposition
                MainPlayer.transform.position = NewPos;
                ScaleMainPlayer.transform.localScale = NewScale;

                MainLevel.HideInspectMission();
                MainLevel.InspectMission[0].SetActive(false);

            }
            else if (MainLevel.MissionTaskCount == 1) // go outside
            {
                _cameraFollow.IsEnteringMiniGameOverWorld = false;
                OverWorld.SetActive(false);

                //resetPos
                MainPlayer.transform.position = OldPos;
                ScaleMainPlayer.transform.localScale = OldScale;

                MainLevel.InspectMission[0].SetActive(false);
                MainLevel.HideInspectMission();
            }
            else if (MainLevel.MissionTaskCount == 4) { // eathquake

                
                
                MainLevel.HideInspectMission(); // inspect mission hide cause it is not a mini gme
                ChangeController.SetActive(false); // controller player default dissable
                NewController.SetActive(true); // activate new controller
                ChangeMission.SetActive(false); // dissable mission
                Anim.SetBool("ISEnteringEarthQuakeMode", true); // animation of player change
                //MainPlayerController.dirX = 0;
                MainPlayer.transform.localScale = new Vector3(0.4031155f, 0.4031155f, 0);
                MainPlayerController.enabled = false;


                //Change Gameplay
                MainLevel.StartGameplay = false; // dissable couter of the reputation bar;
                NewGamePlay();
                _reputationText.ChangeToHealthBar = true;


                MainLevel.ReputationBar.minValue = 0;//change reputation function
                MainLevel.ReputationBar.maxValue = 100;
                MainLevel.ReputationBar.value = 100;
                SliderFill.color = NewColor;


                StaticGameObjectSprites.SetActive(false); // disabble static game obj
                TiggershakeCam.SetActive(true); // enable game object
                ColliderTriggerSwitch.OnColliderTrigger();//activate colliders and stuff
                playerCollider.enabled = true;
                //ChangeRigidBody.constraints.


                //dissable Collider of minigames
                foreach (Collider2D obj in MiniGameObject)
				{
                    obj.enabled = false;
				}
                foreach (GameObject obj in OffObject)
				{
                    obj.SetActive(false);
				}

                offtriger.OnCollider2d();

                //ChangeScoreSystem


            }

        }
		public void PlayerHealthBar()
		{

		}

		public void CloseTheDropCoverHoldMiniGame()
        {
            _cameraFollow.IsEnteringMiniGameOverWorld = false;
        }

        public void AutoGoOutside()
		{
            _cameraFollow.IsEnteringMiniGameOverWorld = false;
            OverWorld.SetActive(false);

            //resetPos
            MainPlayer.transform.position = OldPos;
            ScaleMainPlayer.transform.localScale = OldScale;

            /*MainLevel.InspectMission[0].SetActive(false);
            MainLevel.HideInspectMission();*/
        }


        public void NewGamePlay()
		{
            foreach (GameObject obj in ChangeHeirchy)
			{
                obj.transform.SetParent(NewParent.transform);
			}
        }


    }
}

