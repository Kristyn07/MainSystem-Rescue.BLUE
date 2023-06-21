using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LegCravatMiniTask
{
	//2 Steps Narrow + step bystep 
	public class LegCravatStepsController : MonoBehaviour
	{

		public GameObject[] Steps;
		public GameObject[] ImageAnimation;
		public CravatNarrowFolding narrowfoldingstep1;
		public StepByStepBandaging legcravatstep2;
		public float DelaySecs = 1.5f;
		
		public bool IsSuccess = false;

		/*[Header("Stage 4 Stuff")]
		[SerializeField] StageComplete _stageComplete;
		[SerializeField] bool stage04;*/
		

		
		public void Check_Update()
		{
			CheckStepsLegCravat();
			TaskCompleteLegCravat();
			


		}

		public void CheckStepsLegCravat()
		{
			if (narrowfoldingstep1.isSuccess == true)
			{
				/*Steps[0].SetActive(false);
				ImageAnimation[0].SetActive(false);
				Steps[1].SetActive(true);
				ImageAnimation[1].SetActive(true);*/
				Invoke("Delay", DelaySecs);
			}


		}

		public void GameObjectActivate1()
		{
			Steps[0].SetActive(false);
			ImageAnimation[0].SetActive(false);
			
		}

		public void TaskCompleteLegCravat()
		{
			if (narrowfoldingstep1.isSuccess == true && legcravatstep2.isSuccess)
			{
				IsSuccess = true;
				/*if (stage04 == true)
				{
					_stageComplete.MissionCount +=1;
				}*/
					
					
			}

			else { IsSuccess = false; }
		}

		void Delay()
		{
			Steps[0].SetActive(false);
			ImageAnimation[0].SetActive(false);
			Steps[1].SetActive(true);
			ImageAnimation[1].SetActive(true);
			
		}
		
	}
}
