using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using Network.Manager;

public class SoundManagerScript : MonoBehaviour
{
    AudioSource SoundFx;

    float soundVolume;
    public Slider SoundSlider;

    int FirstPlay;
    [SerializeField] PlayFabSaveVolume _playfab;
    [SerializeField] PlayfabOnlineDetector _playfabAccessLogin;
    void Awake()
    {
        FirstPlay = PlayerPrefs.GetInt("First Play Sound");
        if (FirstPlay == 0)
        {
            PlayerPrefs.SetFloat("Sound Volume", 1);
            PlayerPrefs.SetInt("First Play Sound", 1);
        }

        if(FirstPlay == 1)
        {
            PlayerPrefs.GetFloat("Sound Volume");
        }
    }
    // Start is called before the first frame update
    public void Start()
    {
        SoundFx = GetComponent<AudioSource>();
        SoundSlider.value = PlayerPrefs.GetFloat("Sound Volume");
    }

    // Update is called once per frame
    void Update()
    {

        SoundFx.volume = SoundSlider.value;
    }

    public void SaveButtonSound()
    {
        PlayerPrefs.SetFloat("Sound Volume", SoundFx.volume);
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //offline
        }
        else
        {
            if (_playfabAccessLogin.PlayerLogin == true)
            {
                _playfab.SaveSFXVolume(PlayerPrefs.GetFloat("Sound Volume"));
            }

        }
    }
}
