using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InspectButtonCentralize : MonoBehaviour
{
	[SerializeField] MainPlayerMovementScript PlayerMovement;
	[SerializeField] EventTrigger Leftmovement;
	[SerializeField] EventTrigger Rightmovement;

	public void InspectMissionOpen()
	{
		PlayerMovement.IdleButton();
		Leftmovement.enabled = false;
		Rightmovement.enabled = false;
	}

	public void InspectMissionClose()
	{
		PlayerMovement.IdleButton();
		Leftmovement.enabled = true;
		Rightmovement.enabled = true;
	}
} 
