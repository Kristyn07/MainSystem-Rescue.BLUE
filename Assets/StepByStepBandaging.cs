using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepByStepBandaging : MonoBehaviour
{
	public int StepCounts = 0;
	public bool isSuccess = false;
	[SerializeField] GameObject obj;
	[SerializeField] Bandage[] _bandage;
	[SerializeField] GameObject[] Steps;
	[SerializeField] Animator Anim;
	public int BandageStep;
	//[SerializeField] bool IsReset;
	private void Start()
	{
		BandageStep = _bandage.Length;
	}
	private void Update()
	{
		if (obj.activeSelf)
		{
			AnimationClipController();
			Anim.SetInteger("Steps", StepCounts);

		}
	}
	void AnimationClipController()
	{
		
			//Debug.Log(_bandage.Length);//9
			if (BandageStep > 0 )
			{
				CheckAnimPlay();
				if (_bandage[StepCounts].IsSuccess == true)
				{
					Steps[StepCounts].SetActive(false);
					StepCounts++; 
					BandageStep--;
					Anim.SetInteger("Steps", StepCounts);
				}
			}
			else
			{
				isSuccess = true;
				//Debug.Log("done");
			}
		
	}
	public void ResetBandage()
	{
		//Anim.ResetTrigger("Steps");
		BandageStep = _bandage.Length;
		StepCounts = 0;
		Anim.SetInteger("Steps", StepCounts);
		//IsReset = true;
	}

	void CheckAnimPlay()
	{
		if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
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

	void DelaySucess()
	{
		isSuccess = true;
	}

	public void OffStep()
	{
		foreach(GameObject obj in Steps)
		{
			obj.SetActive(false);
		}
	}
}
