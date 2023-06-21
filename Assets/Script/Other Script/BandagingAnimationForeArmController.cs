using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BandagingAnimationForeArmController : MonoBehaviour
{
	[SerializeField] Bandage[] _bandage;
	[SerializeField] GameObject[] Steps;
	public int StepCounts = 0;
	public bool isSuccess = false;
	[SerializeField] Animator Anim;
	

	

	private void Update()
	{
		AnimationClipController();
		
		Anim.SetInteger("Steps", StepCounts);
		
	}


	void AnimationClipController()

	{
		CheckAnimPlay();

			if (_bandage[StepCounts].IsSuccess == true)
			{
				Steps[StepCounts].SetActive(false);
				StepCounts++;
				Anim.SetInteger("Steps", StepCounts);	
			}
	}
	void CheckAnimPlay()
	{
		if (Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
		{
			Steps[StepCounts].SetActive(true);
			Debug.Log("is not playing");
		}
		else
		{
			Steps[StepCounts].SetActive(false);
			Debug.Log("is playing");
		}
	}

}
