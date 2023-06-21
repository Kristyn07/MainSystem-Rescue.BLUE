using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareKnotBandagingAnimationController : MonoBehaviour
{
	public Bandage[] _bandage;
	public GameObject[] Steps;
	public Animator StepsAnimation;
	public int StepCounts = 0;
	public float[] Secs;
	public bool isSuccess = false;

	[SerializeField]
	bool Stage02;


	private void Start()
	{


	}
	private void Update()
	{
		AnimationClipController();

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
		if (_bandage[1].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate1");
			StepCounts = 2;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[1].SetActive(false);
			Invoke("GameObjectActivate2", Secs[1]);

		}
		if (_bandage[2].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate2");
			StepCounts = 3;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[2].SetActive(false);
			Invoke("GameObjectActivate3", Secs[2]);
		}
		if (_bandage[3].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate3");
			StepCounts = 4;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[3].SetActive(false);
			Invoke("GameObjectActivate4", Secs[3]);
		}
		if (_bandage[4].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate4");
			StepCounts = 5;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[4].SetActive(false);
			Invoke("GameObjectActivate5", Secs[4]);

		}
		if (_bandage[5].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate5");
			StepCounts = 6;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[5].SetActive(false);
			Invoke("GameObjectActivate6", Secs[5]);

		}
		if (_bandage[6].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate6");
			StepCounts = 7;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[6].SetActive(false);
			Invoke("GameObjectActivate7", Secs[6]);
		}
		if (_bandage[7].IsSuccess == true)
		{
			CancelInvoke("GameObjectActivate7");
			StepCounts = 8;
			StepsAnimation.SetInteger("Steps", StepCounts);
			Steps[7].SetActive(false);
			//Invoke("GameObjectActivate8", Secs[7]);
			IsAllStepComplete();
		}
	}

	private bool IsAllStepComplete()
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
		isSuccess = true;
		return true;
	}

	void GameObjectActivate1()
	{
		Steps[1].SetActive(true);
	}
	void GameObjectActivate2()
	{
		Steps[2].SetActive(true);
	}
	void GameObjectActivate3()
	{
		Steps[3].SetActive(true);
	}
	void GameObjectActivate4()
	{
		Steps[4].SetActive(true);
	}
	void GameObjectActivate5()
	{
		Steps[5].SetActive(true);
	}
	void GameObjectActivate6()
	{
		Steps[6].SetActive(true);
	}
	void GameObjectActivate7()
	{
		Steps[7].SetActive(true);
	}
	

}
