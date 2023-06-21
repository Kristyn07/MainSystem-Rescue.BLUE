using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspector : MonoBehaviour
{
    public bool isTouching;
    public Button inspectButton;
    public Rigidbody2D player;
    public BoxCollider2D MG_1FirstAidKit;
    //public BoxCollider2D hazardmapping;
    public BoxCollider2D MG_3FirstAid;
    public GameObject ActiveInteractable;
    public GameObject HighLightIndicatorMN1; // popup highlight to indicate that the user is colliding nto an interactve mini game
    

    public GameObject HighLightIndicatorMN3; // popup highlight to indicate that the user is colliding nto an interactve mini game
    public List<GameObject> windows = new List<GameObject>();
    public List<Objectives> objs = new List<Objectives>();

    //Instruction Guide
    public BoxCollider2D MN1_Guide; // interactive information
    public GameObject MN1_PopUp; // Pop up info Guide mini toturial FIRST AID BOX
    public BoxCollider2D MN2_Guide; // interactive information
    public GameObject MN2_PopUp; // Pop up info Guide mini toturial BANDAGING

    public ColliededtoActiveMiniGame soundplayondetect;
    //objective public Objectives completeIt;
    //private Objectives completed_MN1;

    // AudioSource

    //public AudioSource MN1collide;

    private Objectives _objectives;
    //objectives
    void Start()
    {
        inspectButton.onClick.AddListener(InspectPerson);
        inspectButton.onClick.AddListener(InspectKit);
    }
	/* private void OnEnable()
	 {
		 HighLightIndicatorMN1 = transform.GetChild(0).gameObject; // highlight for minigame1 first aid box
	 }*/
	

	void OnTriggerEnter2D(Collider2D collider)
    {

        Debug.Log("In range of interactable.");
            if (collider == MG_1FirstAidKit )
            {
                Debug.Log("First aid kit.");
                    HighLightIndicatorMN1.SetActive(true);
                    soundplayondetect.detectedMN();
            }
        

            if (collider == MG_3FirstAid)
            {
                Debug.Log("First aid capsule/person");
                HighLightIndicatorMN3.SetActive(true);
                soundplayondetect.detectedMN();
            }    

            else if (collider == MN1_Guide)
            {
                Debug.Log("Colliding into MiniGame1 First Aid Box Puzzle ");
                MN1_PopUp.SetActive(true);
                soundplayondetect.CollidedtoGuide.Play();
            }

            else if (collider == MN2_Guide)
            {
                Debug.Log("Colliding into MiniGame1 First Aid Box Puzzle ");
                MN2_PopUp.SetActive(true);
                soundplayondetect.CollidedtoGuide.Play();
            }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        isTouching = true;
        if (collider == MG_1FirstAidKit)
         {
            ActiveInteractable = windows[2];
            
                inspectButton.gameObject.SetActive(true);
            
           
         }
        else if (collider == MG_3FirstAid)
         {
            ActiveInteractable = windows[3];
            inspectButton.gameObject.SetActive(true);
         }
        
    }
    void OnTriggerExit2D(Collider2D collider)
    {
       Debug.Log("Not in range of interactable");
       isTouching = false;
       inspectButton.gameObject.SetActive(false);

        if (collider == MG_1FirstAidKit)
        {
            HighLightIndicatorMN1.SetActive(false);
        }
        else if (collider == MG_3FirstAid)
        {
            HighLightIndicatorMN3.SetActive(false);
        }
        else if (collider == MN1_Guide)
        {
            MN1_PopUp.SetActive(false);
        }
        else if (collider == MN2_Guide)
        {
            MN2_PopUp.SetActive(false);
        }
    }

    public void InspectKit()
    {

        if (isTouching == true && ActiveInteractable == windows[2] && objs[0].isComplete == false)
        {

            //windows[1].SetActive(true); // main canvas of all the mini games//set as active to reduce coding lines
            ActiveInteractable.SetActive(true);
            windows[2].SetActive(true);
            windows[0].SetActive(false); // deact canvas main overworld btn's  
        }
    }
     public void InspectPerson()
     {
        if(isTouching == true && ActiveInteractable == windows[3])// && objs[1].isComplete == false)
        {
            ActiveInteractable.SetActive(true);
            windows[3].SetActive(true);
            windows[0].SetActive(false);
        }
    }
   


}
