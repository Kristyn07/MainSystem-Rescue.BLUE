using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

	//MusicController for bgm
	public AudioSource AudioSourceBGMs;
	private float VolumeMusic = 1f; //BGM
	//public Button[] button;
	//public AudioSource[] arraySFX; // button on click sounds
	private float SFXvolume = 1f; //BGM

	
	private void Start()
	{
		AudioSourceBGMs.Play();
	}

	/*private void Update()
	{
		AudioSourceBGMs.volume = VolumeMusic;
		PlayerPrefs.SetFloat("volumeBGM", VolumeMusic);
	}*/

	public void UpdateMusicVolume(float volume)// BGM
	{
		VolumeMusic = volume;
	}

	






}
