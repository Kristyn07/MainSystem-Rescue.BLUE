using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratualationAnim : MonoBehaviour
{
	[SerializeField] GameObject Anim;

	
	public void Congratualation()
	{
		if (PlayerPrefs.GetInt("RescueBLUEMember") == 1)
		{
			Anim.SetActive(false);
		}
	}

	public void SetPlayerPrefs()
	{
		PlayerPrefs.SetInt("RescueBLUEMember", 1);
	}
}
