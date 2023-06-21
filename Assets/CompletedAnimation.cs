using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameplayManager;
using GameplayManager.Level;

public class CompletedAnimation : MonoBehaviour
{
	public bool stage7;
	public LevelGameplayManagerScript _stage_07;
	public bool ApplynspectFunction;
	[SerializeField] InspectButtonCentralize enableMovement;
	public void DisableAnim()
	{
		
		
		


		if (stage7)
		{
			_stage_07.HideInspectMission();
		}

		this.gameObject.SetActive(false);
	}

	public void Ispector()
	{
		if (ApplynspectFunction)
		{
			enableMovement.InspectMissionClose();
		}
	}

	
}
