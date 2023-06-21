using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMVolume : MonoBehaviour // this is for splash screen only
{
    [SerializeField] AudioSource[] Sound;

    int FirstPlay;

    void Awake()
    {
        FirstPlay = PlayerPrefs.GetInt("First Play Music");
        if (FirstPlay == 0)
        {
            PlayerPrefs.SetFloat("Music Volume", 1);
            PlayerPrefs.SetInt("First Play Music", 1);
        }

        if (FirstPlay == 1)
        {
            PlayerPrefs.GetFloat("Music Volume");
        }
    }
	private void Start()
	{
        foreach (AudioSource sound in Sound)
		{
            sound.volume = PlayerPrefs.GetFloat("Music Volume");
        }
        
    }

}
