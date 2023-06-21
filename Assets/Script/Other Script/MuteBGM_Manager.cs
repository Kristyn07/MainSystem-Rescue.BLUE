using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteBGM_Manager : MonoBehaviour
{
    [Header("Muting BGM")]
    public AudioSource muteBGM;
    public bool isMuted = false;
    public Button _bgmBtn;
    BGM_SliderContoller _BGM_SliderContoller;
    

	private void Update()
	{

        VolumeBGM();
        

    }
	public void Mute_OnButtonPressed()
    {


        if (isMuted == false)
        {
            isMuted = true;
            muteBGM.mute = isMuted;
            Debug.Log("mute BGM");
        }
    }

    public void Unmute_OnButtonPressed()
    {
        if (isMuted == true)
        {
            isMuted = false;
            muteBGM.mute = false;
            Debug.Log("Unmute BGM");
        }
    }

    public void VolumeBGM()
    {
        float GetVolumeValue = PlayerPrefs.GetFloat("save_BGM_Value");
        muteBGM.volume = GetVolumeValue;
    }

    
}
