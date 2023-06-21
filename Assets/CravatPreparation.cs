/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CravatPreparation : MonoBehaviour
{

	public Bandage[] _bandage;
	public GameObject[] Steps;
	public Animator StepsAnimation;
	public int StepCounts = 0;
	public float[] Secs;
	public bool isSuccess = false;
	public GameObject humanwireframe;
	public GameObject NarrowCravatPrep;
	[SerializeField]
	bool Stage02;

	[SerializeField]
	bool DisplayControl;
	private void Start()
	{

	}
	private void Update()
	{
		AnimationClipController();
		CheckAlltrueNarrowCravat();


	}


	void AnimationClipController()
	{
		if (_bandage[0].IsSuccess == true)
		{
			StepCounts = 1;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[0].SetActive(false);
			Invoke("GameObjectActivate1", Secs[0]);

		}
		if (_bandage[1].IsSuccess == true && _bandage[2].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate1");
			StepCounts = 2;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[1].SetActive(false);
			Invoke("GameObjectActivate2", Secs[1]);

		}
		if (_bandage[3].IsSuccess == true && _bandage[4].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate2");
			StepCounts = 3;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[2].SetActive(false);

		}
		//IsAllStepComplete();

	}

	*//*public bool IsAllStepComplete()
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

	}*//*

	public void CheckAlltrueNarrowCravat()
	{
		if (_bandage[0].IsSuccess == true &&
			_bandage[1].IsSuccess == true &&
			_bandage[2].IsSuccess == true &&
			_bandage[3].IsSuccess == true &&
			_bandage[4].IsSuccess == true)
		{
			isSuccess = true;

			if (DisplayControl == false)
			{
				humanwireframe.SetActive(true);
				NarrowCravatPrep.SetActive(false);
				DisplayControl = true;
			}
		}
	}
	void GameObjectActivate1()
	{
		Steps[1].SetActive(true);
	}
	void GameObjectActivate2()
	{
		Steps[2].SetActive(true);
	}

}
*/