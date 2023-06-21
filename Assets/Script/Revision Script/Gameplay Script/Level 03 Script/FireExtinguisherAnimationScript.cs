using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniGame.Manager;
using GameplayManager.Level;
using CollisionCheck.Manager;

namespace FireExtinguisher.Animation
{
    public class FireExtinguisherAnimationScript : MonoBehaviour
    {
        
        [SerializeField]
        CentralizeCollisionCheckScript MainCol;

        [SerializeField]
        FireExtinguisherScript MiniGameControl;
        
        
        //[SerializeField] GameObject ExitButton;
        [SerializeField]
        GameObject FireOnPlatform;
        public bool isComplete = false;

        [Header("Animation Update Current State")]
        [SerializeField] Animator Anim;
        [SerializeField] int animationCount;
        [SerializeField] GameObject FE;

        [Header("Update Mission State")]
        public bool TaskIsDone = false;
        [SerializeField] Stage3Missions _stage3Missions;

        //[SerializeField] GameObject SetToNull;

        /*[Header("ControllRefinement")]
        [SerializeField] GameObject[] Refinement;*/

        [Header("Stage04-5 == true")]
        [SerializeField]bool OtherStages;

        [Header("Stage 04")]
        CentralizeLevel04GameplayManagerScript Level04Main;
        [SerializeField] bool Stage04;

        [Header("Stage 05")]
        [SerializeField] bool Stage05;
        CentralizeLevel05GameplayManagerScript Level05Main;

        [SerializeField] bool IsPause;

        [Header("Stage 10")]
        [SerializeField] bool Stage10;
        CentralizeLevel10GamePlayManagerScript Level10Main;


        // Start is called before the first frame update
        void Start()
        {
            if (OtherStages == true)
            {
                if (Stage04 == true)
                {
                    Level04Main = GameObject.FindObjectOfType<CentralizeLevel04GameplayManagerScript>();
                }
                if (Stage05== true)
                {
                    Level05Main = GameObject.FindObjectOfType<CentralizeLevel05GameplayManagerScript>();
                }
                if (Stage10 == true)
                {
                    Level10Main = GameObject.FindObjectOfType<CentralizeLevel10GamePlayManagerScript>();
                }
            }

            Anim.SetInteger("FE Step", animationCount);
            

        }

        // Update is called once per frame
        void Update()
        {
            //MiniGameControl.AnimationCount();

            animationCount = MiniGameControl.AnimationCount;
            //Anim.SetInteger("FE Step", (animationCount));
            if (FE.activeSelf){
                //Debug.Log("activateeeee");
                Anim.speed = 1f;
                //Anim.SetInteger("FE Step", animationCount);
            }



        }
        public void DisableExitButton()
        {
            //CheckAnimPlay();
           /* ExitButton.gameObject.SetActive(false);
            FireOnPlatform.gameObject.SetActive(false);*/
        }

        public void IncreaseCount()
        {
              

                if (OtherStages == true)
                {
                    if (Stage04 == true)
                    {
                        //ExitButton.gameObject.SetActive(true);
                        Level04Main.FireExtinguisherIncreaseCount();
                    }
                    if (Stage05 == true)
				    {
                        //ExitButton.gameObject.SetActive(true);
                        Level05Main.FireExtinguisherIncreaseCount();
                    }
                if (Stage10 == true)
                {
                    //ExitButton.gameObject.SetActive(true);
                    Level10Main.FireExtinguisherIncreaseCount();
                }
            }

                if (OtherStages == false)
                {

                    MiniGameControl.AnimationCount += 1;

                }
            
        }
            
        
        public void EndAnimation()
        {
            FireOnPlatform.SetActive(false);
            TaskIsDone = true;

            //_stage3Missions.SubTaskSucess();

            if (OtherStages == true)
            {
                if (Stage04 == true)
                {
                    MainCol.CountControl();
                    Level04Main.FinishStage();
                    MiniGameControl.EndResultAnimation();
                    isComplete = true;
                }
				else {
                    //MainCol.CountControl();
                    //Level04Main.FinishStage();
                }
                if (Stage05 == true)
				{
                    MainCol.CountControl();
                    Level05Main.FinishStage();
                    MiniGameControl.EndResultAnimation();
                    isComplete = true;
                }
                if (Stage10 == true)
                {
                    MainCol.CountControl();
                    Level10Main.FinishStage();
                    MiniGameControl.EndResultAnimation();
                    isComplete = true;
                }
            }

            if (OtherStages == false)
            {
                MiniGameControl.EndResultAnimation();
                if (!Stage10)
				{
                    _stage3Missions.SubTaskSucess();
				}
                
                isComplete = true;

            }


        }

        

        /*void CheckAnimPlay()
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                *//*ExitButton.gameObject.SetActive(false);
                FireOnPlatform.gameObject.SetActive(false);*//*
                //Debug.Log("is not playing");
                IncreaseCount();
            }
            else
            {

                //Debug.Log("is playing");
            }
        }*/

        public void RestartReturn()
		{

            //Anim.SetInteger("FE Step", 0);
            //Anim.Play("FE Step", 0);
            //Anim.Update(0f);
            //Anim.Rebind();
            MiniGameControl.AnimationCount = 1;

           /* foreach (GameObject obj in Refinement)
			{
                obj.SetActive(true);
			}*/
        }

        public void PauseAnimator()
        {
            IsPause = true;
            Anim.speed = 0;

        }

        public void ResumeAnimator()
        {
            IsPause = false;
            Anim.speed = 1;
        }

    }
}

