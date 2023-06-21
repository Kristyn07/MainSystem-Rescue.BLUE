using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using Network.Manager;

    public class MusicManagerScript : MonoBehaviour
{
    AudioSource SoundFx;

    float soundVolume;
    public Slider MusicSlider;
    [SerializeField] PlayFabSaveVolume _playfab;
    [SerializeField] PlayfabOnlineDetector _playfabAccessLogin;

    int FirstPlay;

    void Awake()
    {
        FirstPlay = PlayerPrefs.GetInt("First Play Music");
        if (FirstPlay == 0)
        {
            PlayerPrefs.SetFloat("Music Volume", 1);
            PlayerPrefs.SetInt("First Play Music", 1);
        }

        if(FirstPlay == 1)
        {
            PlayerPrefs.GetFloat("Music Volume");
        }
    }
    // Start is called before the first frame update
    public void Start()
    {
        SoundFx = GetComponent<AudioSource>();
        MusicSlider.value = PlayerPrefs.GetFloat("Music Volume");
    }

    // Update is called once per frame
    void Update()
    {

        SoundFx.volume = MusicSlider.value;

    }


    public void SaveButtonMusic()
    {
        SoundEffect();
        PlayerPrefs.SetFloat("Music Volume", SoundFx.volume);
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            //offline
        }
        else
        {
            if (_playfabAccessLogin.PlayerLogin == true)
            {
                _playfab.SaveBGMVolume(PlayerPrefs.GetFloat("Music Volume"));
            }

        }
    }
    public void GameplaySaveButtonMusic()
    {
        PlayerPrefs.SetFloat("Music Volume", SoundFx.volume);
    }
    void SoundEffect()
    {
        SoundEffectScript.instance.Play(SoundEffectScript.instance.SoundButton);
    }
}
