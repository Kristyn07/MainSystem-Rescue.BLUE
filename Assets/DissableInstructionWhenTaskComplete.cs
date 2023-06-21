using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableInstructionWhenTaskComplete : MonoBehaviour
{
	[Header("FistAidKit")]
	[SerializeField] bool FirstAidKitMiniGame;
	[SerializeField] Objectives[] _FirstAidKitIsComplete;
	[SerializeField] GameObject InstructionOfFirstAidKit;

	public void DisableInstruction()
	{
		if (FirstAidKitMiniGame == true) { 
			foreach (Objectives iscomplete in _FirstAidKitIsComplete)
			{
				if (iscomplete.isComplete == true)
				{
					InstructionOfFirstAidKit.SetActive(false);
				}
			}
		}
	}
}
