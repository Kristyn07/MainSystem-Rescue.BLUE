
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTestPlayerPrefs : MonoBehaviour
{
	private void Awake()
	{
		// Prevent the device from going into sleep mode
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	// Update is called once per frame
	/*void Update()
	{
		//Debug.Log("HeadCount : "+ PlayerPrefs.GetInt("Head"));
		//Debug.Log("TorsoCount : " + PlayerPrefs.GetInt("Torso"));
		//Debug.Log("PelvisCount : " + PlayerPrefs.GetInt("Pelvis"));
		//Debug.Log("LeftUpperArmCount : " + PlayerPrefs.GetInt("L U Arm"));
		*//*Debug.Log("HeadCount : " + PlayerPrefs.GetInt("Head"));
		Debug.Log("HeadCount : " + PlayerPrefs.GetInt("Head"));
		Debug.Log("HeadCount : " + PlayerPrefs.GetInt("Head"));
		Debug.Log("HeadCount : " + PlayerPrefs.GetInt("Head"));
		Debug.Log("HeadCount : " + PlayerPrefs.GetInt("Head"));
		Debug.Log("HeadCount : " + PlayerPrefs.GetInt("Head"));
		Debug.Log("HeadCount : " + PlayerPrefs.GetInt("Head"));
		
		int  = PlayerPrefs.GetInt("");
		int LeftLowerArmCount = PlayerPrefs.GetInt("L L Arm");
		int LeftUpperLegCount = PlayerPrefs.GetInt("L U Leg");
		int LeftLowerLegCount = PlayerPrefs.GetInt("L L Leg");
		int RightUpperArmCount = PlayerPrefs.GetInt("R U Arm");
		int RightLowerArmCount = PlayerPrefs.GetInt("R L Arm");
		int RightUpperLegCount = PlayerPrefs.GetInt("R U Leg");
		int RightLowerLegCount = PlayerPrefs.GetInt("R L Leg");*//*





		//Done Testing ---------------------------- this is for continue and stage selection 
		//Debug.Log("Continue : " + (PlayerPrefs.GetInt("Continue") - 1));
		//Debug.Log("Continue : " + PlayerPrefs.GetInt("Orig"));
		//Debug.Log(PlayerPrefs.GetInt("VibrationToggle"));
		//Debug.Log("Continue " + PlayerPrefs.GetInt("Continue"));
		//Debug.Log("Stage " + PlayerPrefs.GetInt("StageSelection"));
		//Debug.Log("Animated Text : " + PlayerPrefs.GetInt("AnimatedTextToggle"));
		//Debug.Log("Vibration : " + PlayerPrefs.GetInt("VibrationToggle"));
		//Debug.Log("SFX : " + PlayerPrefs.GetFloat("Sound Volume"));
		//Debug.Log("BGM : " + PlayerPrefs.GetFloat("Music Volume"));
		//Debug.Log("BGM Mute :" + PlayerPrefs.GetInt("MuteBGM")); // not mute 0
		//Debug.Log("SFX Mute :" + PlayerPrefs.GetInt("MuteSFX"));



		*//*
				//Done Testing ----------------------------------------- this is for tutorial mode in stage 1;
				int test = PlayerPrefs.GetInt("Reply");
				Debug.Log("Player Pref (Reply) 0 = false / 1 =true   : " + test);


				//user data
				Debug.Log("PlayerName/Username :" + (PlayerPrefs.GetString("Player Name")));
				Debug.Log("PlayerPassword :" + (PlayerPrefs.GetString("Player Password")));
				Debug.Log("PlayerHasLogin :" + PlayerPrefs.GetInt("PlayerHasLogIn"));
				Debug.Log("PlayerRank :" + PlayerPrefs.GetString("PlayerRank")); // strnf
				Debug.Log("PlayerRankNumber :" + PlayerPrefs.GetString("PlayerRankNumber")); // int
				Debug.Log("PlayerScore :" + PlayerPrefs.GetInt("PlayerScore"));// deleted
				Debug.Log("PlayerScore :" + PlayerPrefs.GetString("PlayerScore")); // in stringform
				Debug.Log("PlayerScoreInt :" + PlayerPrefs.GetInt("IntPlayerScore"));
		*//*
		//scoreManger

		Debug.Log("1 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_1"));
				Debug.Log("2 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_2"));
				Debug.Log("3 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_3"));
				Debug.Log("4 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_4"));
				Debug.Log("5 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_5"));
				Debug.Log("6 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_6"));
				Debug.Log("7 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_7"));
				Debug.Log("8 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_8"));
				Debug.Log("9 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_9"));
				Debug.Log("10 : " + PlayerPrefs.GetInt("MainTotalScore_Stage_10"));
				Debug.Log("ALL : " + PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES"));
				//Debug.Log(PlayerPrefs.GetInt("IntPlayerScore"));
	}*/


}
