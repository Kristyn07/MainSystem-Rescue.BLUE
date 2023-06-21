using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepsText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Steps;
	public Bandage[] _bandage;

	private void Update()
	{
		StepsInfo();
	}
	void StepsInfo()
	{
		Steps.text = "";
		if (_bandage[0].IsSuccess == true)
		{
			Steps.text = "Wrap the first two rounds nearer to the wrist area";
		}
		if (_bandage[2].IsSuccess == true)
		{
			Steps.text = "Ensure that barrel of roller bandage is facing outwards";
		}
		if (_bandage[4].IsSuccess == true)
		{
			Steps.text = "Move the barrel upwards covering 2/3 of the previous bandage";
		}
		if (_bandage[6].IsSuccess == true)
		{
			Steps.text = "Continue the layering back downwards towards the wrist";
		}
		if (_bandage[7].IsSuccess == true)
		{
			Steps.text = "Keep repeating the motion until there is no excess bandage left";
		}

		if (_bandage[8].IsSuccess == true)
		{
			Steps.text = "Clip the end of the bandage. Do not clip on the injured area it might worsen the condition.";

		}

	}

}
