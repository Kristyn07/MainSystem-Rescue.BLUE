using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWasteIfIsInTheRightTrashBin : MonoBehaviour
{
    [Header("Checker")]
    public bool Checker;
    public Collider2D ThisWasteCol;
    [SerializeField] Collider2D ThisRightTrashBinCol;
    [SerializeField] Animator Anim_TrashBin;
    [SerializeField] Transform TransformTransBin;
    [SerializeField] BoxCollider2D otherBoxCollider;
    [SerializeField] TaskCompleteDrainage TaskComplete;


    [Header("Waste")]
    [SerializeField] bool Green_Biodegradable;
    [SerializeField] bool Black_Residual;
    [SerializeField] bool Blue_Recyclable;
    [SerializeField] bool Yellow_HouseholdHealthCare_MSW;

    [Header("TrashBin Collider")]
    [SerializeField] Collider2D Col_Green_Biodegradable;
    [SerializeField] Collider2D Col_Black_Residual;
    [SerializeField] Collider2D Col_Blue_Recyclable;
    [SerializeField] Collider2D Col_Yellow_HouseholdHealthCare_MSW;

    [Header("Default Parent")]
    [SerializeField] Transform WasteDrinaige;
    [Header("Over World")]
    [SerializeField] GameObject WasteObj;
    [SerializeField] GameObject HL_WasteObj;

    
    private void Start()
	{
        ThisWasteCol = gameObject.GetComponent<BoxCollider2D>();
        GetTheRightCol();
    }



	private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider == Col_Green_Biodegradable || 
            otherCollider == Col_Black_Residual ||
            otherCollider == Col_Blue_Recyclable ||
            otherCollider == Col_Yellow_HouseholdHealthCare_MSW)
		{
            otherBoxCollider = otherCollider.GetComponent<BoxCollider2D>();
            Anim_TrashBin = otherBoxCollider.GetComponent<Animator>();
            Anim_TrashBin.SetBool("TrashBinIsOpen", true);
            TransformTransBin = otherBoxCollider.GetComponent<Transform>();

            if (otherBoxCollider == ThisRightTrashBinCol)
            {
                if (ThisWasteCol.bounds.Intersects(otherBoxCollider.bounds))
                {
                    Checker = true;
                    
                }
            }
			else { Checker = false; }
        }
        
        
    }
	private void OnTriggerExit2D(Collider2D otherCollider)
	{
        Checker = false;

        if (Anim_TrashBin != null)
		{
            Anim_TrashBin.SetBool("TrashBinIsOpen", false);
        }
       

    }
	public void GetTheRightCol()
	{
        if (Green_Biodegradable)
		{
            ThisRightTrashBinCol = Col_Green_Biodegradable;
        }
        else if (Black_Residual)
		{
            ThisRightTrashBinCol = Col_Black_Residual;
        }
        else if (Blue_Recyclable)
        {
            ThisRightTrashBinCol = Col_Blue_Recyclable;
        }
        else if(Yellow_HouseholdHealthCare_MSW)
        {
            ThisRightTrashBinCol = Col_Yellow_HouseholdHealthCare_MSW;
        }






    }

    public void DoThisOnDrop() // right
	{
        DisableBoxCollider();
        Anim_TrashBin.SetBool("TrashBinIsOpen", false);
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        TaskComplete.checkTask();
        gameObject.transform.SetParent(TransformTransBin);
        //gameObject.transform.SetAsFirstSibling();
        gameObject.transform.SetSiblingIndex(transform.parent.childCount - 3);

        if (WasteObj != null)
		{
            WasteObj.SetActive(false);
        }
        if (HL_WasteObj != null)
		{
            HL_WasteObj.SetActive(false);
        }
       
       

        //change hierchy
    }

    public void DothisOnDropWrong() //wrong
    {
        EnableBoxCollider();
        gameObject.transform.localScale = new Vector3(1, 1, 0);
        gameObject.transform.SetParent(WasteDrinaige);
        if (WasteObj != null)
        {
            WasteObj.SetActive(true);
        }

        if (HL_WasteObj != null)
        {
            HL_WasteObj.SetActive(true);
        }
    }

    public void DisableBoxCollider()
    {
        ThisWasteCol.enabled = false;
        Checker = true;
    }

    public void EnableBoxCollider()
    {
        ThisWasteCol.enabled = true;
        Checker = false;
    }

    }
