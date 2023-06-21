using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    [Header("Muting BGM")]
    public AudioSource muteBGM;
    public bool isMuted = false;
    public Button _bgmBtn;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

	public void Mute_OnButtonPressed()
	{
       

        if (isMuted == false)
		{
            isMuted = true;
            muteBGM.mute = isMuted;
            Debug.Log("mute"); 
        }
	}

    public void Unmute_OnButtonPressed()
    {
        if (isMuted == true)
        {
            isMuted = false;
            muteBGM.mute = false;
            Debug.Log("mute");
        }
    }
}
