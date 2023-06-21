using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingArmAnimationController : MonoBehaviour // 3steps only
{
	public Bandage[] _bandage;
	public GameObject[] Steps;
	public Animator StepsAnimation;
	public int StepCounts = 0;
	//public float[] Secs;
	public bool isSuccess = false;
	public int BandageStep;
	public bool TwoFingerDone = false;
	//public GameObject humanwireframe;

	private void Start()
	{
		//BandageStep = _bandage.Length;
		StepCounts = 0;
		BandageStep = 19;
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
		if (BandageStep > 0)
		{
			CheckAnimPlay();
			if (TwoFingerDone == false)
			{
				StepsAnimation.SetInteger("Steps", StepCounts);
				//Step 1 - 4
				if (_bandage[0].IsSuccess == true)
				{

					Steps[0].SetActive(false);
					StepCounts = 1;
					BandageStep = 18;
					//StepsAnimation.SetInteger("Steps", StepCounts);
				}
				if (_bandage[1].IsSuccess == true)
				{

					Steps[1].SetActive(false);
					StepCounts = 2;
					BandageStep = 17;
					//StepsAnimation.SetInteger("Steps", StepCounts);
				}
				if (_bandage[2].IsSuccess == true)
				{

					Steps[2].SetActive(false);
					StepCounts = 3;
					BandageStep = 16;
					//StepsAnimation.SetInteger("Steps", StepCounts);
				}
				if (_bandage[3].IsSuccess == true)
				{

					Steps[3].SetActive(false);
					StepCounts = 4;
					BandageStep = 15;
					//StepsAnimation.SetInteger("Steps", StepCounts);
				}
				//Step 5 - 8	
				if (_bandage[4].IsSuccess == true && _bandage[5].IsSuccess == true)
				{
					Steps[4].SetActive(false);
					StepCounts = 5;
					BandageStep = 14;
				}
				if (_bandage[6].IsSuccess == true && _bandage[7].IsSuccess == true)
				{
					Steps[5].SetActive(false);
					StepCounts = 6;
					BandageStep = 13;
				}
				if (_bandage[8].IsSuccess == true && _bandage[9].IsSuccess == true)
				{
					Steps[6].SetActive(false);
					StepCounts = 7;
					BandageStep = 12;
				}
				if (_bandage[10].IsSuccess == true && _bandage[11].IsSuccess == true)
				{
					Steps[7].SetActive(false);
					StepCounts = 8;
					BandageStep = 11;
					TwoFingerDone = true;
				}

			}
			else if (TwoFingerDone == true)
			{
				//Step 9 - 19
				if (_bandage[12].IsSuccess == true)
				{
					Steps[8].SetActive(false);
					StepCounts = 9;
					BandageStep = 10;
				}
				if (_bandage[13].IsSuccess == true)
				{
					Steps[9].SetActive(false);
					StepCounts = 10;
					BandageStep = 9;
				}
				if (_bandage[14].IsSuccess == true)
				{
					Steps[10].SetActive(false);
					StepCounts = 11;
					BandageStep = 8;
				}
				if (_bandage[15].IsSuccess == true)
				{
					Steps[11].SetActive(false);
					StepCounts = 12;
					BandageStep = 7;
				}
				if (_bandage[16].IsSuccess == true)
				{
					Steps[12].SetActive(false);
					StepCounts = 13;
					BandageStep = 6;
				}
				if (_bandage[17].IsSuccess == true)
				{
					Steps[13].SetActive(false);
					StepCounts = 14;
					BandageStep = 5;
				}
				if (_bandage[18].IsSuccess == true)
				{
					Steps[14].SetActive(false);
					StepCounts = 15;
					BandageStep = 4;
				}
				if (_bandage[19].IsSuccess == true)
				{
					Steps[15].SetActive(false);
					StepCounts = 16;
					BandageStep = 3;
				}
				if (_bandage[20].IsSuccess == true)
				{
					Steps[16].SetActive(false);
					StepCounts = 17;
					BandageStep = 2;
				}
				if (_bandage[21].IsSuccess == true)
				{
					Steps[17].SetActive(false);
					StepCounts = 18;
					BandageStep = 1;
				}
				if (_bandage[22].IsSuccess == true)
				{
					Steps[18].SetActive(false);
					StepCounts = 19;
					BandageStep = 0;
				}
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
			if (_bandage[0].IsSuccess == true &&
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

	} 

	