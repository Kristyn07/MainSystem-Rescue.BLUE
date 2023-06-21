using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Network.Manager;
public class ToggleButtonsPrefabs : MonoBehaviour
{
	public Toggle Vibration;
	public Toggle AnimatedText;
	[SerializeField] PlayfabLatestStage _playfabSend;
	[SerializeField] PlayfabOnlineDetector _playfabAccessLogin;
	public void Start()
	{
		if (PlayerPrefs.GetInt("VibrationToggle") == 1)
		{
			Vibration.isOn = true;
		}
		else if (PlayerPrefs.GetInt("VibrationToggle") == 0)
		{
			Vibration.isOn = false;
		}

		if (PlayerPrefs.GetInt("AnimatedTextToggle") == 1)
		{
			AnimatedText.isOn = true;
		}
		else if (PlayerPrefs.GetInt("AnimatedTextToggle") == 0)
		{
			AnimatedText.isOn = false;
		}
	}

	
	public void VibrationMode()
	{
		if (Vibration.isOn)
		{
			PlayerPrefs.SetInt("VibrationToggle", 1);
		}

		else 
		{
			PlayerPrefs.SetInt("VibrationToggle", 0);
		}

		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			//offline
		}
		else
		{
			if (_playfabAccessLogin.PlayerLogin == true)
			{
				_playfabSend.SaveOptionVibration(PlayerPrefs.GetInt("VibrationToggle"));
			}

		}

	}
	public void AnimatedTextMode()
	{
		if (AnimatedText.isOn)
		{
			PlayerPrefs.SetInt("AnimatedTextToggle", 1);
			
		}

		else
		{
			PlayerPrefs.SetInt("AnimatedTextToggle", 0);
		}


		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			//offline
		}
		else
		{
			if (_playfabAccessLogin.PlayerLogin == true)
			{
				_playfabSend.SaveOptionAnimated(PlayerPrefs.GetInt("AnimatedTextToggle"));
			}
			
		}

	}

}
