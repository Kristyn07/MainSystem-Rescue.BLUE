using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MN_DCH_PlayerController : MonoBehaviour // this is for UI
{
    [Header("Player")]
    [SerializeField] GameObject Player;

    [Header("Movement")]
    public float MovementSpeed;
    [SerializeField] Vector3 targetPos;
   
    [SerializeField] float GetPosX;
    private RectTransform rectTransform;

    [Header("Controller Button Pressed")]
    [SerializeField] bool MoveLeft;
    [SerializeField] bool MoveRight;
    [SerializeField] bool OnCrawl;
    [SerializeField] bool OnHold;
    [SerializeField] bool OnStand;
    public bool IsCrawling;
    public bool IsStanding;

    [Header("Buttons")]
    [SerializeField] ButtonIsPressed _LeftButtonIsPressed;
    [SerializeField] ButtonIsPressed _RightButtonIsPressed;
    [SerializeField] ButtonIsPressed _CrawlButtonIsPressed;
    [SerializeField] ButtonIsPressed _HoldButtonIsPressed;
    [SerializeField] ButtonIsPressed _StandButtonIsPressed;

    [Header("Animation")]
    [SerializeField] Animator Anim;

    [Header("DissableButtonsOnHold")]
    [SerializeField] ButtonIsPressed[] DissableButton;
    [SerializeField] GameObject[] DissableButtonObj;

    [Header("HoldButtonManipulation")]
    [SerializeField] ButtonIsPressed[] HoldDissableButton;
    [SerializeField] GameObject HoldDissableButtonObj;

    [Header("LimitMovement")]
    [SerializeField] GameObject LeftMoveLimit;
    [SerializeField] float LeftLimit;
    [SerializeField] GameObject RightMoveLimit;
    [SerializeField] float RightLimit;

    [SerializeField] bool Move;
    [SerializeField] bool Moving;

    void Start()
    {
        rectTransform = Player.GetComponent<RectTransform>();
        targetPos = rectTransform.localPosition;
        /*myImage = Player.GetComponent<Image>();
        CurrentColor = Player.GetComponent<Image>().color;*/
        LeftLimit = LeftMoveLimit.GetComponent<RectTransform>().position.x;
        RightLimit = RightMoveLimit.GetComponent<RectTransform>().position.x;
    }

    void Update()
	{
        ButtonPressedUpdate();
    }
    //Buttons
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

    //Movement
    public void MovingToLeft()
    {
        GetPosX = Player.GetComponent<RectTransform>().position.x;

        if (GetPosX >= LeftLimit) 
        { 
            rectTransform.position -= new Vector3(MovementSpeed * Time.deltaTime,0, 0);
        }
        rectTransform.localScale = new Vector3(-1, 1, 1);
        
    }
    public void MovingToRight()
    {
        GetPosX = Player.GetComponent<RectTransform>().position.x;
        if (GetPosX <= RightLimit)
        {
            rectTransform.position += new Vector3(MovementSpeed * Time.deltaTime, 0, 0);
        }
        rectTransform.localScale = new Vector3(1, 1, 1);
    }
    //LeftRightUpdate
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
        foreach(ButtonIsPressed btn in DissableButton)
		{
            btn.ButtonPressed = false;

        }
        foreach(GameObject obj in DissableButtonObj)
		{
            var Image = obj.GetComponent<Image>();
            var Color = Image.GetComponent<Image>().color;
            Image.color = new Color(Color.r, Color.g, Color.b, 0.5f);
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
            Image.color = new Color(Color.r, Color.g, Color.b, 1);
        }
        
    }
    
   



}
