using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicRevision : MonoBehaviour
{
	float soundVolume;
	public Slider MusicSlider;
	public void Start()
	{
		MusicSlider.value = PlayerPrefs.GetFloat("Music Volume");
	}
	public void SaveVolume()
	{
		PlayerPrefs.SetFloat("Music Volume",MusicSlider.value);
	}


}
