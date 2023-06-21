using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stage06Mission : MonoBehaviour
{
	[Header("First Aid Kit")]
	[SerializeField] bool mn1_isComplete;
	[SerializeField] Objectives T1IsCompleteScript;
	public TMPro.TextMeshProUGUI MN1_txt;
	public TMPro.TextMeshProUGUI MN1_count;
	[SerializeField] bool M1Done;

	//emergency kit
	[Header("Emergency Kit")]
	[SerializeField] bool mn2_isComplete;
	[SerializeField] Objectives T2IsCompleteScript;
	public TMPro.TextMeshProUGUI MN2_txt;
	public TMPro.TextMeshProUGUI MN2_count;
	[SerializeField] bool M2Done;

	[SerializeField] BoxCollider2D FirstAid;
	[SerializeField] BoxCollider2D EmergencyKit;
	public void Check_Update()
	{
		if (M1Done == false)
		{
			if (T1IsCompleteScript.isComplete == true)
			{
				mn1_isComplete = true;
				MN1_txt.color = new Color32(0, 0, 0, 90);// lower opacity
				MN1_count.text = "1/1";
				MN1_count.color = new Color32(0, 0, 0, 90);// lower opacity
				M1Done = true;
				FirstAid.enabled = false;
			}
		}
		//Task2
		if (M2Done == false)
		{
			if (T2IsCompleteScript.isComplete == true)
			{
				mn2_isComplete = true;
				MN2_txt.color = new Color32(0, 0, 0, 90);// lower opacity
				MN2_count.text = "1/1";
				MN2_count.color = new Color32(0, 0, 0, 90);// lower opacity
				M2Done = true;
				EmergencyKit.enabled = false;
			}

		}
	}
		
}
