using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LegCravatMiniTask;
public class BandageComplete : MonoBehaviour
{

	[Header("Narrow Cravat")] 
	[SerializeField] CravatNarrowFolding _cravatnarrowfolding;
	[SerializeField] bool NarrowCravatOnly;

	[Header("Step By Step Bandaging")]
	[SerializeField] StepByStepBandaging _stepByStepBandaging;
	[SerializeField] bool StepbyStepOnly;

	[Header("Narrow + Bandaging Technique")]
	[SerializeField] bool NarrowAndBandageTechnique;
	[SerializeField] LegCravatStepsController _StepsController;

	[Header("TopOfTheHead")]
	[SerializeField] bool TopOfTheHead;
	[SerializeField] TopOfTheHeadBandaging _topOfTheHeadBandaging;

	[Header("TopOfTheHead")]
	[SerializeField] bool SlingArm;
	[SerializeField] SlingArmAnimationController _slingArmAnimationController;

	[Header("Complete Animation")]
	[SerializeField] GameObject CompletedMark;

	

	public void CompletedBandaging()
	{
		if (NarrowCravatOnly)
		{
			if (_cravatnarrowfolding.isSuccess == true)
			{
				CompletedMark.SetActive(true);
				
			}
		}
		if (StepbyStepOnly)
		{
			if (_stepByStepBandaging.isSuccess == true)
			{
				CompletedMark.SetActive(true);
				
			}
		}

		if (NarrowAndBandageTechnique)
		{
			if (_StepsController.IsSuccess == true)
			{
				CompletedMark.SetActive(true);
				
			}
		}

		if (TopOfTheHead)
		{
			if (_topOfTheHeadBandaging.isSuccess == true)
			{
				CompletedMark.SetActive(true);
				
			}
		}

		if (SlingArm)
		{
			if (_slingArmAnimationController.isSuccess == true)
			{
				CompletedMark.SetActive(true);
				
			}
		}
	}

	public void ActivateCompleteState(GameObject CompleteState)
	{
		CompleteState.SetActive(true);
	}
}
