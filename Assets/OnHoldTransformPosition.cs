using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//stage 5 only
public class OnHoldTransformPosition : MonoBehaviour
{
    [SerializeField] T3_DropCoverHold_AnimationAndController DCHManger;
	public SafeAreaCollided[] SafeAreaManager;
	[SerializeField] bool isAnySafeAreaCollidedInSafe;
	public bool[] SafeAreaCollidedInSafe;
	[SerializeField] GameObject Player;
	[SerializeField] GameObject NewHandPosTransform;
	[SerializeField] GameObject DefaultParentPos;
	[SerializeField] Transform Handtransform;
	[SerializeField] Transform NewHandPostransform;
	[SerializeField] TriggerCameraShake[] _CameraShake;
	public void holding()
	{
		if (isAnySafeAreaCollidedInSafe == true) {
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
		IsInSafeArea();
		
			NewHandPostransform.transform.position = Handtransform.transform.position;
		


	}
	public void IsInSafeArea()
	{
		if (SafeAreaManager[0].IsInSafe == true ||
			SafeAreaManager[1].IsInSafe == true ||
			SafeAreaManager[2].IsInSafe == true ||
			SafeAreaManager[3].IsInSafe == true ||
			SafeAreaManager[4].IsInSafe == true)
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
		HierchyChange();
	}

	public void HierchyChange()
	{

		Player.transform.SetParent(NewHandPosTransform.transform);
	}

	public void HierchyChangeDefault()
	{
		Player.transform.SetParent(DefaultParentPos.transform);
	}


}
