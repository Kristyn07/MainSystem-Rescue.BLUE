/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerBandaging : MonoBehaviour
{
	public GameObject LeftArmBandaging;
	[SerializeField]
	public Bandage _bandage;
	public bool activateanim = false;
	public GameObject[] Steps;

	private void Update()
	{
		CheckIfSuccess();
		DisableSteps();
	}

	void CheckIfSuccess()
	{
		if (_bandage.IsSuccess == true)
		{
			activateanim = true;

			if (activateanim == true)
			{
				LeftArmBandaging.SetActive(true);

			}
		}
	}

		void DisableSteps()
		{
			 if (activateanim == true)
			 {
				Steps[0].SetActive(false);
				*//*if (Steps[0].SetActive == false)
					{
						Steps[1].SetActive(true);
					}*//*



			 }
		}
}
*/