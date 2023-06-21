using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CravatNarrowFolding : MonoBehaviour // 3steps only
{
	public Bandage[] _bandage;
	public GameObject[] Steps;
	public Animator StepsAnimation;
	public int StepCounts = 0;
	//public float[] Secs;
	public bool isSuccess = false;
	public int BandageStep;
	//public GameObject humanwireframe;

	private void Start()
	{
		//BandageStep = _bandage.Length;
		StepCounts = 0;
		BandageStep = 3;
	}
	private void Update()
	{
		AnimationClipController();
		//CheckAlltrueNarrowCravat();
		StepsAnimation.SetInteger("Steps", StepCounts);

	}


	void AnimationClipController()
	{
		//StepCounts = 0; 
		if (BandageStep > 0) {
			CheckAnimPlay();


			if (_bandage[0].IsSuccess == true)
			{

				Steps[0].SetActive(false);
				StepCounts = 1;
				BandageStep = 2 ;
				StepsAnimation.SetInteger("Steps", StepCounts);
			}

			if (_bandage[1].IsSuccess == true && _bandage[2].IsSuccess == true)
			{
				Steps[1].SetActive(false);
				StepCounts = 2;
				BandageStep = 1;
				StepsAnimation.SetInteger("Steps", StepCounts);
			}
			if (_bandage[3].IsSuccess == true && _bandage[4].IsSuccess == true)
			{
				Steps[2].SetActive(false);
				StepCounts = 3;
				BandageStep = 0;
				StepsAnimation.SetInteger("Steps", StepCounts);
			}
		}
		else
		{
			isSuccess = true;
			//Debug.Log("done");
		}















	}

	/*public bool IsAllStepComplete()
	{
		for (int i = 0; i < _bandage.Length; ++i)
		{
			if (_bandage[i].IsSuccess == false)
			{
				Debug.Log("Not successful");
				return false;
				
			}
		}
		Debug.Log("successful");
		
		return isSuccess = true;

	}*/
	
	public void CheckAlltrueNarrowCravat()
	{
		if(_bandage[0].IsSuccess == true &&
			_bandage[1].IsSuccess == true &&
			_bandage[2].IsSuccess == true &&
			_bandage[3].IsSuccess == true &&
			_bandage[4].IsSuccess == true)
		{
			//isSuccess = true;
			//humanwireframe.SetActive(true);

		}
	}
	/*void GameObjectActivate1()
	{
		Steps[1].SetActive(true);
	}
	void GameObjectActivate2()
	{
		Steps[2].SetActive(true);
	}*/


	void CheckAnimPlay()
	{
		if (StepsAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
		{
			Steps[StepCounts].SetActive(true);
			//Debug.Log("is not playing");
		}
		else
		{
			Steps[StepCounts].SetActive(false);
			//Debug.Log("is playing");
		}
	}

	public void OffStepNarrow()
	{
		foreach (GameObject obj in Steps)
		{
			obj.SetActive(false);
		}
	}
}
