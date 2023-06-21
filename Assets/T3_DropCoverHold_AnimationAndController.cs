using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class T3_DropCoverHold_AnimationAndController : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject Player;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] Animator Anim;
    [Header("Movement")]
    public float MovementSpeed;

    [Header("Controller Button Pressed")]
    [SerializeField] bool MoveLeft;
    [SerializeField] bool MoveRight;
    [SerializeField] bool OnCrawl;
    public bool OnHold;
    [SerializeField] bool OnStand;
    public bool IsCrawling;
    public bool IsStanding;

    [Header("Buttons")]
    [SerializeField] ButtonIsPressed _LeftButtonIsPressed;
    [SerializeField] ButtonIsPressed _RightButtonIsPressed;
    [SerializeField] ButtonIsPressed _CrawlButtonIsPressed;
    [SerializeField] ButtonIsPressed _HoldButtonIsPressed;
    [SerializeField] ButtonIsPressed _StandButtonIsPressed;

    [Header("DissableButtonsOnHold")]
    [SerializeField] ButtonIsPressed[] DissableButton;
    [SerializeField] GameObject[] DissableButtonObj;

    [SerializeField] bool Move;
    [SerializeField] bool Moving;
    [Header("AdjustmentOnMovement")]
    [SerializeField] bool MovementAdjustment; // for animation
    [SerializeField] MainPlayerMovementScript _mainPlayerMovementScript;

    [Header("OnHold")]
    [SerializeField] GameObject HandPositionObj;
    [SerializeField] float HandPosX;
    [SerializeField] Transform HandTransform;
    [SerializeField] Transform NewHandPosTransform;
    [SerializeField] GameObject[] LeftHoldPos;
    [SerializeField] GameObject[] RightHoldPos;
    [SerializeField] float[] leftPosX;
    [SerializeField] float[] rightPosX;
    //mnigame
    [SerializeField] OnHoldTransformPosition Onholdtransform;
    //gameplay
    [SerializeField] PlayerOnHoldTransformPosition PlayerOnhold;
    //[SerializeField] Transform MainPlayerHandLoc; 
    [Header("Stages Handler")]
    [SerializeField] bool Stage05 ;
    [SerializeField] bool Stage06 ;
    public bool DoneEartquake;

    [SerializeField] GameObject ParentHandPos;

    float AdjustSpeedWhenCrawling = 5.5f;
    public float DefaultSpeed = 7f;

    float MNAdjustSpeedWhenCrawling = 3f;
    float MNDefaultSpeed = 4f;

    private void Start()
    {
         AdjustSpeedWhenCrawling = 5.5f;
         DefaultSpeed = 7f;

         MNAdjustSpeedWhenCrawling = 3f;
         MNDefaultSpeed = 4f;





        if (Stage05)
        {
            foreach (GameObject obj in LeftHoldPos)
            {
                int index = Array.IndexOf(LeftHoldPos, obj);
                leftPosX[index] = obj.transform.position.x;
            }
            foreach (GameObject obj in RightHoldPos)
            {
                int index = Array.IndexOf(RightHoldPos, obj);
                rightPosX[index] = obj.transform.position.x;
            }
        }
        if (Stage06)
		{
            foreach (GameObject obj in LeftHoldPos)
            {
                int index = Array.IndexOf(LeftHoldPos, obj);
                leftPosX[index] = obj.transform.position.x;
            }
            foreach (GameObject obj in RightHoldPos)
            {
                int index = Array.IndexOf(RightHoldPos, obj);
                rightPosX[index] = obj.transform.position.x;
            }
        }
    }
    public void Update()
    {
        ButtonPressedUpdate();




    }


    public void ButtonPressedUpdate()
    {
        OnHold = _HoldButtonIsPressed.ButtonPressed == true;
        if (OnHold == true)
        {
            Anim.SetBool("IsHolding", OnHold);
            Holding();
        }
        else
        {
            Anim.SetBool("IsHolding", OnHold);
            IsNotHolding();

            MoveRight = _RightButtonIsPressed.ButtonPressed == true;
            MoveLeft = _LeftButtonIsPressed.ButtonPressed == true;
            //left right only 
            Move = (MoveRight == true || MoveLeft == true) && (IsStanding == false && IsCrawling == false);
            if (Move == true)
            {
                PlayerIsMoving();
            }
            else
            {
                OnCrawl = _CrawlButtonIsPressed.ButtonPressed == true;
                Anim.SetBool("Drop", OnCrawl);
                OnStand = _StandButtonIsPressed.ButtonPressed == true;
                Anim.SetBool("Stand", OnStand);
            }

            //moving while transitioning
            Moving = (MoveRight == true || MoveLeft == true) && (IsStanding == true || IsCrawling == true);

            IsCrawling = (_RightButtonIsPressed.ButtonPressed == true || _LeftButtonIsPressed.ButtonPressed == true) && _CrawlButtonIsPressed.ButtonPressed == true;
            IsStanding = (_RightButtonIsPressed.ButtonPressed == true || _LeftButtonIsPressed.ButtonPressed == true) && _StandButtonIsPressed.ButtonPressed == true;


            if (Moving == true)
            {
                PlayerIsMoving();
                if (IsCrawling == true)
                {
                    Anim.SetBool("Crawling", IsCrawling);
                }

                if (IsStanding == true)
                {
                    Anim.SetBool("Walking", IsStanding);
                }

            }
            else
            {
                Anim.SetBool("Crawling", IsCrawling);
                Anim.SetBool("Walking", IsStanding);
            }

            Anim.SetBool("IsMoving", Move || Moving);
        }
    }

    public void MovingToLeft()
    {
        if (MovementAdjustment)
        {
            //AdjusmentMovementSpeed();
            Player.transform.position -= new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            if (DoneEartquake)
			{
                PlayerTransform.localScale = new Vector3(-1, 1, 1);
            }
			else
			{
                
                PlayerTransform.localScale = new Vector3(-0.75f, 0.75f, 1);
            }
            //PlayerTransform.position -= new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
           
            
            //_mainPlayerMovementScript.dirX = -1;

        }
        else
        {
            //MNAdjusmentMovementSpeed();
            PlayerTransform.position -= new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            PlayerTransform.localScale = new Vector3(-1, 1, 1);
        }
    }
    public void MovingToRight()
    {
        if (MovementAdjustment)
        {
            //AdjusmentMovementSpeed();
            Player.transform.position += new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            
            if (DoneEartquake)
			{
                PlayerTransform.localScale = new Vector3(1, 1, 1);
            }
			else
			{
                PlayerTransform.localScale = new Vector3(0.75f, 0.75f, 1);
            }
            //PlayerTransform.position += new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            
            //_mainPlayerMovementScript.dirX = 1;

        }
        else
        {
            //MNAdjusmentMovementSpeed();
            PlayerTransform.position += new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
            PlayerTransform.localScale = new Vector3(1, 1, 1);
        }



    }
    public void PlayerIsMoving()
    {
        if (MoveLeft == true)
        {
            MovingToLeft();
        }
        if (MoveRight == true)
        {
            MovingToRight();
        }
    }
    //Hold
    public void Holding()
    {
        foreach (ButtonIsPressed btn in DissableButton)
        {
            btn.ButtonPressed = false;

        }
        foreach (GameObject obj in DissableButtonObj)
        {
            var Image = obj.GetComponent<Image>();
            var Color = Image.GetComponent<Image>().color;
            Image.color = new Color(Color.r, Color.g, Color.b, 0.25f);
        }
        MoveLeft = false;
        MoveRight = false;
        OnCrawl = false;
        OnStand = false;

    }
    public void IsNotHolding()
    {

        foreach (GameObject obj in DissableButtonObj)
        {
            var Image = obj.GetComponent<Image>();
            var Color = Image.GetComponent<Image>().color;
            Image.color = new Color(Color.r, Color.g, Color.b, 0.5f);
        }
        if (Stage05)
        {
            Onholdtransform.HierchyChangeDefault();
            Onholdtransform.notholding();
        }
        else if (Stage06)
        {
            PlayerOnhold.HierchyChangeDefault();
            PlayerOnhold.notholding();
        }
    }



	public void ResetPlayerAnim()
    {
        Anim.SetBool("Reset", true);
        Invoke("DissableReset", 0.1f);
    }

    public void DissableReset()
    {
        Anim.SetBool("Reset", false);
    }

    public void DCHCompleteStand()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("IdleCrawling") || Anim.GetCurrentAnimatorStateInfo(0).IsName("Crawling") || Anim.GetCurrentAnimatorStateInfo(0).IsName("OnHold"))
        {
            Anim.SetBool("TaskIsDone", true);
            Invoke("DoneAnim", 0.5f);
        }
    }

    public void DoneAnim()
    {
        Anim.SetBool("TaskIsDone", false);
    }

    public void OnHoldTransformPos()
    {
        if (Stage05 == true){
            Vector3 position = HandPositionObj.transform.position;
                    if (Onholdtransform.SafeAreaManager[0].IsInSafe)
                    {
                        if (Player.transform.localScale.x < 0)
                        {

                            position.x = leftPosX[0];
                            HandPositionObj.transform.position = position;
                        }
                        else if (Player.transform.localScale.x > 0)
                        {
                            position.x = rightPosX[0];
                            HandPositionObj.transform.position = position;
                        }
                    }
                    else if (Onholdtransform.SafeAreaManager[1].IsInSafe)
                    {
                        if (Player.transform.localScale.x < 0)
                        {

                            position.x = leftPosX[1];
                            HandPositionObj.transform.position = position;
                        }
                        else if (Player.transform.localScale.x > 0)
                        {
                            position.x = rightPosX[1];
                            HandPositionObj.transform.position = position;
                        }
                    }
                    else if (Onholdtransform.SafeAreaManager[2].IsInSafe)
                    {
                        if (Player.transform.localScale.x < 0)
                        {

                            position.x = leftPosX[2];
                            HandPositionObj.transform.position = position;
                        }
                        else if (Player.transform.localScale.x > 0)
                        {
                            position.x = rightPosX[2];
                            HandPositionObj.transform.position = position;
                        }
                    }
                    else if (Onholdtransform.SafeAreaManager[3].IsInSafe)
                    {
                        if (Player.transform.localScale.x < 0)
                        {

                            position.x = leftPosX[3];
                            HandPositionObj.transform.position = position;
                        }
                        else if (Player.transform.localScale.x > 0)
                        {
                            position.x = rightPosX[3];
                            HandPositionObj.transform.position = position;
                        }
                    }
                    else if (Onholdtransform.SafeAreaManager[4].IsInSafe)
                    {
                        if (Player.transform.localScale.x < 0)
                        {

                            position.x = leftPosX[4];
                            HandPositionObj.transform.position = position;
                        }
                        else if (Player.transform.localScale.x > 0)
                        {
                            position.x = rightPosX[4];
                            HandPositionObj.transform.position = position;
                        }
                    }
		}
        if (Stage06 == true)
		{
            
            Vector3 position = HandPositionObj.transform.position;
            if (PlayerOnhold.SafeAreaManager[0].IsInSafe)
            {
                if (PlayerTransform.localScale.x < 0 )
                {
                    //Debug.Log("left");
					position.x = leftPosX[0];
					HandPositionObj.transform.position = position;
				}
                else if (PlayerTransform.localScale.x > 0)
                {
                    //Debug.Log("right");
                    position.x = rightPosX[0];
					HandPositionObj.transform.position = position;
				}
            }
            else if (PlayerOnhold.SafeAreaManager[1].IsInSafe)
            {
                if (PlayerTransform.localScale.x < 0)
                {
                    Debug.Log("left");
                    position.x = leftPosX[1];
                    HandPositionObj.transform.position = position;
                }
                else if (PlayerTransform.localScale.x > 0)
                {
                    Debug.Log("right");
                    position.x = rightPosX[1];
                    HandPositionObj.transform.position = position;
                }
            }
            else if (PlayerOnhold.SafeAreaManager[2].IsInSafe)
            {
                if (PlayerTransform.localScale.x < 0)
                {
                    Debug.Log("left");
                    position.x = leftPosX[2];
                    HandPositionObj.transform.position = position;
                }
                else if (PlayerTransform.localScale.x > 0)
                {
                    Debug.Log("right");
                    position.x = rightPosX[2];
                    HandPositionObj.transform.position = position;
                }
            }
            else if (PlayerOnhold.SafeAreaManager[3].IsInSafe)
            {
                if (PlayerTransform.localScale.x < 0)
                {
                    Debug.Log("left");
                    position.x = leftPosX[3];
                    HandPositionObj.transform.position = position;
                }
                else if (PlayerTransform.localScale.x > 0)
                {
                    Debug.Log("right");
                    position.x = rightPosX[3];
                    HandPositionObj.transform.position = position;
                }
            }
            else if (PlayerOnhold.SafeAreaManager[4].IsInSafe)
            {
                if (PlayerTransform.localScale.x < 0)
                {
                    Debug.Log("left");
                    position.x = leftPosX[4];
                    HandPositionObj.transform.position = position;
                }
                else if (PlayerTransform.localScale.x > 0)
                {
                    Debug.Log("right");
                    position.x = rightPosX[4];
                    HandPositionObj.transform.position = position;
                }
            }

        }
    }

    public void AdjusmentMovementSpeed()
	{
        if (Anim.GetBool("SpeedWhenCrawling"))
        {
            MovementSpeed = AdjustSpeedWhenCrawling;
        }
        else
        {
            MovementSpeed = DefaultSpeed;
        }
    }
    public void MNAdjusmentMovementSpeed()
	{
       
            if (Anim.GetBool("SpeedWhenCrawling"))
            {
                MovementSpeed = MNAdjustSpeedWhenCrawling;
            }
            else
            {
                MovementSpeed = MNDefaultSpeed;
            }
        
    }
   
    
}
