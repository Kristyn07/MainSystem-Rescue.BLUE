using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Pause.Manager;

namespace Network.Manager
{
    public class PlayFabSaveVolume : MonoBehaviour
    {
        [SerializeField] bool IsinMainMenu;
        [SerializeField] MusicManagerScript _bgm;
        [SerializeField] SoundManagerScript _sfx;
        [SerializeField] PauseManagerScript _mute;
        [SerializeField] PlayfabOnlineDetector _playfabAccessLogin;
        public void Start()
		{
            if (IsinMainMenu)
			{
                OnlineLogin();
            }
            

        }
		public void OnlineLogin()
        {

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                Debug.Log("No Internet!");


            }
            else
            {
                Debug.Log("Internet!");
                if (_playfabAccessLogin.PlayerLogin == true)
                {
                    float bgm = PlayerPrefs.GetFloat("Music Volume");
                    float sfx = PlayerPrefs.GetFloat("Sound Volume");
                    int mutebgm = PlayerPrefs.GetInt("MuteBGM");
                    int mutesfx = PlayerPrefs.GetInt("MuteSFX");


                    SaveBGMVolume(bgm);
                    LoadBGMVolume();
                    SaveSFXVolume(sfx);
                    LoadSFXVolume();
                    SaveMuteSettings(mutebgm, mutesfx);
                    LoadMuteSettings();
                }
            }
            
        }




        //BGM
        //set

        public void SaveBGMVolume(float volume)
        {
            // Create a request to update the player's custom data
            UpdateUserDataRequest request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
        {
            { "BGMVolume", volume.ToString() }
        }
            };

            // Call the API to update the player's data
            PlayFabClientAPI.UpdateUserData(request, OnSaveBGMVolumeSuccess, OnSaveBGMVolumeFailure);
        }

        private void OnSaveBGMVolumeSuccess(UpdateUserDataResult result)
        {
            Debug.Log("BGM Volume Sent");
        }

        private void OnSaveBGMVolumeFailure(PlayFabError error)
        {
            // Handle error while saving BGM volume
        }

        //get
        public void LoadBGMVolume()
        {
            // Create a request to get the player's custom data
            GetUserDataRequest request = new GetUserDataRequest();

            // Call the API to retrieve the player's data
            PlayFabClientAPI.GetUserData(request, OnLoadBGMVolumeSuccess, OnLoadBGMVolumeFailure);
        }

        private void OnLoadBGMVolumeSuccess(GetUserDataResult result)
        {
            // Check if the BGMVolume key exists in the data
            if (result.Data.ContainsKey("BGMVolume"))
            {
                // Retrieve the BGM volume value and apply it to your audio system
                float bgmVolume = float.Parse(result.Data["BGMVolume"].Value);
                // Apply the bgmVolume value to your audio system
                Debug.Log("BGM Volume Get" + bgmVolume);


                PlayerPrefs.SetFloat("Music Volume", bgmVolume);
                _bgm.Start();

            }
			else
			{
                Debug.Log("BGM Not Found");
			}
        }

        private void OnLoadBGMVolumeFailure(PlayFabError error)
        {
            // Handle error while loading BGM volume
        }




        //SFX
        //set

        public void SaveSFXVolume(float volume)
        {
            // Create a request to update the player's custom data
            UpdateUserDataRequest request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
        {
            { "SFXVolume", volume.ToString() }
        }
            };

            // Call the API to update the player's data
            PlayFabClientAPI.UpdateUserData(request, OnSaveSFXVolumeSuccess, OnSaveSFXVolumeFailure);
        }

        private void OnSaveSFXVolumeSuccess(UpdateUserDataResult result)
        {
            Debug.Log("SFX Volume Sent");
        }

        private void OnSaveSFXVolumeFailure(PlayFabError error)
        {
            // Handle error while saving sfx volume
        }

        //get
        public void LoadSFXVolume()
        {
            // Create a request to get the player's custom data
            GetUserDataRequest request = new GetUserDataRequest();

            // Call the API to retrieve the player's data
            PlayFabClientAPI.GetUserData(request, OnLoadSFXVolumeSuccess, OnLoadSFXVolumeFailure);
        }

        private void OnLoadSFXVolumeSuccess(GetUserDataResult result)
        {
            // Check if the sfxVolume key exists in the data
            if (result.Data.ContainsKey("SFXVolume"))
            {
                // Retrieve the sfx volume value and apply it to your audio system
                float sfxVolume = float.Parse(result.Data["SFXVolume"].Value);
                // Apply the sfxVolume value to your audio system
                Debug.Log("SFX Volume Get" + sfxVolume);


                PlayerPrefs.SetFloat("Sound Volume", sfxVolume);
                _sfx.Start();

            }
            else
            {
                Debug.Log("SFX Not Found");
            }
        }

        private void OnLoadSFXVolumeFailure(PlayFabError error)
        {
            // Handle error while loading sfx volume
        }



        public void SaveMuteSettings(int bgmMuted, int sfxMuted)
        {
            // Create a request to update the player's custom data
            UpdateUserDataRequest request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
        {
            { "BGMMute", bgmMuted.ToString() },
            { "SFXMute", sfxMuted.ToString() }
        }
            };

            // Call the API to update the player's data
            PlayFabClientAPI.UpdateUserData(request, OnSaveMuteSettingsSuccess, OnSaveMuteSettingsFailure);
        }

        private void OnSaveMuteSettingsSuccess(UpdateUserDataResult result)
        {
            Debug.Log("Mute Setting Sent");
        }

        private void OnSaveMuteSettingsFailure(PlayFabError error)
        {
            Debug.Log("E- Mute Setting Sent");
        }

        public void LoadMuteSettings()
        {
            // Create a request to get the player's custom data
            GetUserDataRequest request = new GetUserDataRequest();

            // Call the API to retrieve the player's data
            PlayFabClientAPI.GetUserData(request, OnLoadMuteSettingsSuccess, OnLoadMuteSettingsFailure);
        }

        private void OnLoadMuteSettingsSuccess(GetUserDataResult result)
        {
            // Check if the BGMVolume key exists in the data
            if (result.Data.ContainsKey("BGMMute"))
            {
                // Retrieve the BGM mute setting
                int bgmMuted = int.Parse(result.Data["BGMMute"].Value);
                Debug.Log("BGM Mute Get" + bgmMuted);


                PlayerPrefs.SetInt("MuteBGM", bgmMuted);
                
                // Apply the BGM mute setting to your audio system
                // ...
            }

            // Check if the SFXVolume key exists in the data
            if (result.Data.ContainsKey("SFXMute"))
            {
                // Retrieve the SFX mute setting
                int sfxMuted = int.Parse(result.Data["SFXMute"].Value);
                Debug.Log("SFX Mute Get" + sfxMuted);


                PlayerPrefs.SetInt("MuteSFX", sfxMuted);
                // Apply the SFX mute setting to your audio system
                // ...
            }

            _mute.Start();
        }

        private void OnLoadMuteSettingsFailure(PlayFabError error)
        {
            Debug.Log("Mute Setting Get");
        }
    }
}
