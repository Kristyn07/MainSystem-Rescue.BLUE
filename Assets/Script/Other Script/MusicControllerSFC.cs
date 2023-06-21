using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControllerSFC : MonoBehaviour
{
	//MusicController for SFX
	
									
	public AudioSource UI_BTNsAudioSFX;
	public AudioSource OWcollideMN_SFX;
	public float VolumeMusicSFX;
	SFX_SliderContoller volumeupdate;

	private void Update()
	{
		volumeupdate.sliderValueSFX = VolumeMusicSFX;
		UI_BTNsAudioSFX.volume = VolumeMusicSFX;
		OWcollideMN_SFX.volume = VolumeMusicSFX;
	}

}
