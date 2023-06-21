using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class MuteSFX_Manager : MonoBehaviour
{
    [Header("Muting SFX")]
 
    public bool isMuted = false;
    public Button _sfxBtn;
    public MusicController _sfxmutecontrol;


    private void Update()
	{
        VolumeSFX();

    }
	public void Mute_OnButtonPressed()
    {


        if (isMuted == false)
        {
            isMuted = true;
            //muteSFX.mute = isMuted; // single audiosource
            Debug.Log("mute SFX ");

            
            foreach (AudioSource obj in _sfxmutecontrol.arraySFX) // array of audio sorce
            {
                obj.mute = isMuted;
            }

        }
    }
    public void Unmute_OnButtonPressed()
    {
        if (isMuted == true)
        {
            isMuted = false;
            //muteSFX.mute = isMuted; single audiosource
            Debug.Log("Unmute SFX ");

            foreach (AudioSource obj in _sfxmutecontrol.arraySFX) // array of audio sorce
            {
                obj.mute = isMuted;
            }

        }
    }

    public void VolumeSFX()
    {
        float GetVolumeValue = PlayerPrefs.GetFloat("save_BGM_Value");
        *//*foreach (AudioSource obj in _sfxmutecontrol.arraySFX) // array of audio sorce
        {
            obj.volume = GetVolumeValue;
        }*//*
        
    }
}
*/