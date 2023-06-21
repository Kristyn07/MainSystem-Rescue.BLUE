using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BandagingMiniTask
{
	public class BandagingCravatNarrow : MonoBehaviour
	{

		public GameObject[] Steps;
		public GameObject[] ImageAnimation;
		public CravatNarrowFolding narrowfoldingstep1;
		public StepByStepBandaging legcravatstep2;
		public float DelaySecs;

		public bool IsSuccess = false;



		public void Start()
		{
			Steps[0].SetActive(true);
			ImageAnimation[0].SetActive(true);

			Steps[1].SetActive(false);
			ImageAnimation[1].SetActive(false);

		}
		private void Update()
		{
			CheckStepsLegCravat();
			//TaskCompleteLegCravat();



		}

		public void CheckStepsLegCravat()
		{
			if (narrowfoldingstep1.isSuccess == true)
			{
				/*Steps[0].SetActive(false);
				ImageAnimation[0].SetActive(false);
				Steps[1].SetActive(true);
				ImageAnimation[1].SetActive(true);*/
				Invoke("Delay", 1.5f);
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
