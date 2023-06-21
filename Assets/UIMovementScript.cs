

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIMovementScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float moveSpeed = 10.0f;
    public float smoothing = 5.0f;
    public Vector3 movementLimit = new Vector3(5.0f, 0, 0);

    public bool buttonPressed;
    [SerializeField] bool Left;
    [SerializeField] bool Right;
    [SerializeField] bool DropObj;
    [SerializeField] bool CoverObj;
    [SerializeField] bool HoldObj;

    [Header("Player Obj")]
    [SerializeField] GameObject Player;
    private RectTransform rectTransform;
    private Vector3 targetPos;
    private Image myImage;

    [Header("Color")]
    private Color CurrentColor;
    [SerializeField] Color DropColor;
    [SerializeField] Color CoverColor;
    [SerializeField] Color HoldColor;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = Player.GetComponent<RectTransform>();
        targetPos = rectTransform.localPosition;
        myImage = Player.GetComponent<Image>();
        CurrentColor = Player.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Left == true)
		{
            if (buttonPressed)
            {
                MoveLeft();
                Debug.Log("moveleft");
            }
            
        }
        if (Right == true)
		{
            if (buttonPressed)
            {
                MoveRight();
                Debug.Log("moveright");
            }
        }

        if (DropObj == true)
		{
			if (buttonPressed)
			{
				Drop();
			}
            
        }

		if (CoverObj == true)
        {
            if (buttonPressed)
            {
                Cover();
            }
            
        }

        if (HoldObj == true)
        {
            if (buttonPressed)
            {
                Hold();
            }
			
        }

        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    public void MoveLeft()
    {
        rectTransform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        rectTransform.localScale = new Vector3(1, 1, 1);
    }

    public void MoveRight()
    {
        rectTransform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        rectTransform.localScale = new Vector3(-1, 1, 1);
    }

    public void Drop()
	{
        myImage.color = new Color(DropColor.r, DropColor.g, DropColor.b, 1);
       
    }
    public void Cover()
    {
        myImage.color = new Color(CoverColor.r, CoverColor.g, CoverColor.b,1);
    }
    public void Hold()
    {
        myImage.color = new Color (HoldColor.r, HoldColor.g, HoldColor.b,1);
    }

    public void DefaultColor()
	{
        
        //myImage.color = new Color(CurrentColor.r, CurrentColor.g, CurrentColor.b, 1);
    }
}