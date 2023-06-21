using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float followSpeed = 2f;
    public Transform Player;
    [SerializeField] bool ToturialMode;
    public Vector3 playerPos;

    [Header("DialogCount")]
    [SerializeField] int dialogueCount;

    [SerializeField] Vector3 leftAreaPos;
    [SerializeField] Vector3 rightAreaPos;
    [SerializeField] Vector3 popUpGuideAreaPos;
    [SerializeField] Vector3 minigameAreaPos;
    [SerializeField] Vector3 popUpAnimAreaPos;
    //[SerializeField] Vector3 seenPopUpAreaPos;

    [Header("GetScript")]
    [SerializeField] DialogManager_GamePlay _dialogManager_Gameplay;
    [SerializeField] DialogManager_Toturial _dialogManager_Toturial;

    [Header("PanCameraToObj")]
    [SerializeField] Transform LeftArea;
    [SerializeField] Transform RightArea;
    [SerializeField] Transform PopUpGuideArea;
    [SerializeField] Transform PopUpAnimArea;
    [SerializeField] Transform MiniGameArea;

    

    // Update is called once per frame
    private void Start()
	{
        
        
        leftAreaPos = new Vector3(LeftArea.position.x, Player.position.y, -999f);
        rightAreaPos = new Vector3(RightArea.position.x, Player.position.y, -999f);
        popUpGuideAreaPos = new Vector3(PopUpGuideArea.position.x, Player.position.y, -999f);
        minigameAreaPos = new Vector3(MiniGameArea.position.x, MiniGameArea.position.y, -999f);
        popUpAnimAreaPos = new Vector3(PopUpAnimArea.position.x, PopUpAnimArea.position.y, -999f);


    }
	void Update()
    {
        


        playerPos = new Vector3(Player.position.x, Player.position.y, -999f);

        ToturialMode = _dialogManager_Toturial.isinToturialMode;
        if (ToturialMode == true)
		{
            FollowObject();
        }

		else
		{
            transform.position = Vector3.Slerp(transform.position, playerPos, FollowSpeed * Time.deltaTime);
        }

    }
	
	public void FollowObject()
    {

        dialogueCount = _dialogManager_Toturial.x; //always start at zero or + 1
        
        switch (dialogueCount)
        {

            case 3://left area
                transform.position = Vector3.Slerp(transform.position, leftAreaPos, followSpeed * Time.deltaTime);
                if (transform.position == Vector3.Slerp(transform.position, leftAreaPos, followSpeed * Time.deltaTime))
				{
                    PanForASecs();
                }
               

                break;
            case 6://right area
                transform.position = Vector3.Slerp(transform.position, rightAreaPos, followSpeed * Time.deltaTime);
                if (transform.position == Vector3.Slerp(transform.position, rightAreaPos, followSpeed * Time.deltaTime))
                {
                    PanForASecs();
                }
                break;
            case 9://guide pop up seen
                transform.position = Vector3.Slerp(transform.position, popUpGuideAreaPos, followSpeed * Time.deltaTime);
                if (transform.position == Vector3.Slerp(transform.position, popUpGuideAreaPos, followSpeed * Time.deltaTime))
                {
                    PanForASecs();
                }


                break;
            case 11://empazize mini pop up animation
                transform.position = Vector3.Slerp(transform.position, popUpAnimAreaPos, followSpeed * Time.deltaTime);
                if (transform.position == Vector3.Slerp(transform.position, popUpAnimAreaPos, followSpeed * Time.deltaTime))
                {
                    PanForASecs();
                }

                break;
            default:
                transform.position = Vector3.Slerp(transform.position, playerPos, FollowSpeed * Time.deltaTime);
                break;
        }

    }

  
    //go back to player 
    public void PanForASecs()
	{
        _dialogManager_Toturial.DisplayNextSentence();
        transform.position = Vector3.Slerp(transform.position, playerPos, FollowSpeed * Time.deltaTime);
    }

}
