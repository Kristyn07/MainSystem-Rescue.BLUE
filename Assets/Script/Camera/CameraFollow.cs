using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public bool IsEnteringMiniGameOverWorld;
    [SerializeField] Transform NewTarget;
    [SerializeField] GameObject FadeTransition;



    [Header("ApplyThisScriptOnStage6Only")]
    [SerializeField] bool ApplyThisMethod;
    [SerializeField] Transform Torso;
    public bool PlayerExitTheHouse; // stage 6

    [Header("ApplyThisOnStage10Only")]
    public bool Stage10;
   

    // Update is called once per frame
    public void Update()
    {
        if (IsEnteringMiniGameOverWorld == true)
		{
            Vector3 newPos = new Vector3(NewTarget.position.x, 116f, -999f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
		else 
        {
            if (ApplyThisMethod)
            {
                if (PlayerExitTheHouse)
				{
                    StageSixCameraAdjustment();
                }

				else
				{
                    Vector3 newPos = new Vector3(target.position.x, target.position.y, -999f);
                    transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
                }
            }
            else if (Stage10)
			{
                Stage10CameraAdjustMent();

            }

			else
			{

                Vector3 newPos = new Vector3(target.position.x, target.position.y, -999f);
                transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

            }
        }
    }
        
    public void IsExitingMiniGameOverWorld()
	{
        IsEnteringMiniGameOverWorld = false;
        FadeTransition.SetActive(true);

    }

    public void StageSixCameraAdjustment()
	{
        //GameObject - 883.5062
        Vector3 newPos = new Vector3(Torso.position.x, -1.7f, -999f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

    }
    public void Stage10CameraAdjustMent()
	{
        Vector3 newPos = new Vector3(target.position.x, 4.1f, -999f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);

        //transform.position = newPos;

    }



}
