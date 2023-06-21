using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//stage 6 only
public class PlayerOnHoldTransformPosition : MonoBehaviour
{
	[SerializeField] bool ApplyScript;

	[SerializeField] T3_DropCoverHold_AnimationAndController DCHManger;
	public SafeAreaCollided[] SafeAreaManager;
	[SerializeField] bool isAnySafeAreaCollidedInSafe;
	public bool[] SafeAreaCollidedInSafe;
	public GameObject Player;
	[SerializeField] GameObject NewHandPosTransform;
	[SerializeField] GameObject DefaultParentPos;
	public Transform Handtransform;
	public Transform NewHandPostransform;
	[SerializeField] GameObject MainPlayer;
	[SerializeField] TriggerCameraShake[] _CameraShake;
	

	public void Start()
	{
		

	}
	public void holding()
	{
		Applythis();
	}
	

	public void Applythis()
	{
		if (ApplyScript)
		{
			if (isAnySafeAreaCollidedInSafe == true)
			{
				SwitchObjectHeirchy();
				DCHManger.OnHoldTransformPos();
				foreach (TriggerCameraShake shake in _CameraShake)
				{
					
					float x = shake.DefaultMagnitude * 0.7f;//reduce 30%
					shake.shakeMagnitude = x;
				}




			}
			else
			{
				HierchyChangeDefault();
			}
		}
		else
		{
			//donothing
		}
	}
	public void notholding()
	{
		foreach (TriggerCameraShake shake in _CameraShake)
		{
			float x = shake.DefaultMagnitude;//reduce 100%
			shake.shakeMagnitude = shake.DefaultMagnitude;
		}
	}
	private void Update()
	{
		if (ApplyScript)
		{

			IsInSafeArea();
			if (DCHManger.OnHold) 
			{

			}

			else
			{
				NewHandPostransform.transform.position = Handtransform.transform.position;
			}

		}



	}
	public void IsInSafeArea()
	{
		if (SafeAreaManager[0].IsInSafe == true || SafeAreaManager[1].IsInSafe == true || SafeAreaManager[2].IsInSafe == true || SafeAreaManager[3].IsInSafe == true || SafeAreaManager[4].IsInSafe == true)		
		{
			isAnySafeAreaCollidedInSafe = true;
		}
		else
		{
			isAnySafeAreaCollidedInSafe = false;
		}


	}

	public void SwitchObjectHeirchy()
	{
		AdjustmentPosition();
	}

	public void HierchyChange()
	{
		
		MainPlayer.transform.SetParent(NewHandPosTransform.transform);
	}

	public void HierchyChangeDefault()
	{
		MainPlayer.transform.SetParent(DefaultParentPos.transform);
	}

	public void AdjustmentPosition()
	{
		/*if (Player.transform.localScale.x < 0)
		{

			Handtransform.transform.position = new Vector3 (-Handtransform.transform.position.x, Handtransform.transform.position.y, Handtransform.transform.position.z);
			NewHandPostransform.transform.position = Handtransform.transform.position;
		}
		else if (Player.transform.localScale.x > 0)
		{

			Handtransform.transform.position = new Vector3 (+Handtransform.transform.position.x, Handtransform.transform.position.y, Handtransform.transform.position.z);
			NewHandPostransform.transform.position = Handtransform.transform.position;
		}
*/
		HierchyChange();
	}

	
	


}
