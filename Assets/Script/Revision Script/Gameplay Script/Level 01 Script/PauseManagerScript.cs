using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Centralize.UI;
using PlayFab;
using PlayFab.ClientModels;
using Network.Manager;
namespace Pause.Manager
{
    public class PauseManagerScript : MonoBehaviour
    {
        [SerializeField]
        AudioSource MusicSource;
        [SerializeField]
        GameObject[] MusicIcon;

        [SerializeField] int MusicCount;

        [SerializeField]
        AudioSource SoundSource;
        [SerializeField]
        GameObject[] SoundIcon;

        [SerializeField] int SoundCount;

        [SerializeField]
        int MainMenuScene;
        [SerializeField]
        GameObject PauseCollection;

        [SerializeField] SceneLoader sceneLoad;
        [SerializeField] LoadingScreenRandomizeInfo loadtext;

        [SerializeField] PlayFabSaveVolume _playfab;
        [SerializeField] PlayfabOnlineDetector _playfabAccessLogin;
        void Check_Update()
        {
            if (MusicCount == 0)
            {
                MusicSource.mute = false;
                MusicIcon[0].gameObject.SetActive(false);
                MusicIcon[1].gameObject.SetActive(true);
            }

            if (MusicCount == 1)
            {
                MusicSource.mute = true;
                MusicIcon[0].gameObject.SetActive(true);
                MusicIcon[1].gameObject.SetActive(false);
            }

            if (SoundCount == 0)
            {
                SoundSource.mute = false;
                SoundIcon[0].gameObject.SetActive(false);
                SoundIcon[1].gameObject.SetActive(true);
            }

            if (SoundCount == 1)
            {
                SoundSource.mute = true;
                SoundIcon[0].gameObject.SetActive(true);
                SoundIcon[1].gameObject.SetActive(false);
            }
        }
		public void Start()
		{
            MusicCount = PlayerPrefs.GetInt("MuteBGM");
            SoundCount =PlayerPrefs.GetInt("MuteSFX");
             if (PlayerPrefs.GetInt("MuteBGM") == 0)
             {
                 MusicSource.mute = false;
                 MusicIcon[1].SetActive(true); // not mute
                 MusicIcon[0].SetActive(false);
             }
             else if (PlayerPrefs.GetInt("MuteBGM") == 1)
             {
                 MusicSource.mute = true;
                 MusicIcon[0].SetActive(true);
                 MusicIcon[1].SetActive(false);

             }
             if (PlayerPrefs.GetInt("MuteSFX") == 0)
             {
                 SoundSource.mute = false;
                 SoundIcon[1].SetActive(true); // not mute
                 SoundIcon[0].SetActive(false);
             }
             else if (PlayerPrefs.GetInt("MuteSFX") == 1)
             {
                 MusicSource.mute = true;
                 SoundIcon[0].SetActive(true);
                 SoundIcon[1].SetActive(false);
             }
             
            Check_Update();
        }




		public void PauseButtonControl(int IDControl)
        {
            SoundButtonEffect();
            if (IDControl == 0)//resume
            {
                Time.timeScale = 1;
                PauseCollection.gameObject.SetActive(false);

            }
            if (IDControl == 1)//reply
            {
                Time.timeScale = 1;
                //*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //int x = SceneManager.GetActiveScene().buildIndex;
                loadtext.Start();
                sceneLoad.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (IDControl == 2)//mainmenu
            {
                Time.timeScale = 1;
                //*SceneManager.LoadScene(MainMenuScene);

                loadtext.Start();
                sceneLoad.LoadScene(MainMenuScene);
            }
        }

        public void PauseButton(GameObject gameObjectID)
        {
            SoundButtonEffect();
            Time.timeScale = 0;
            gameObjectID.gameObject.SetActive(true);
        }

        public void AudioControl(int AudioID)
        {
            SoundButtonEffect();

            if (AudioID == 0)
            {
                if (MusicCount == 1)
                {
                    MusicCount = 0;
                    Debug.Log("OnBGM");
                    PlayerPrefs.SetInt("MuteBGM", 0); // not mute
                }
                else
                {
                    MusicCount += 1;
                    Debug.Log("OffBGM");
                    PlayerPrefs.SetInt("MuteBGM", 1); // not mute
                }
                
            }

            if (AudioID == 1)
            {
                if (SoundCount == 1)
                {
                    SoundCount = 0;
                    PlayerPrefs.SetInt("MuteSFX", 0); // not mute
                }
                else
                {
                    SoundCount += 1;
                    PlayerPrefs.SetInt("MuteSFX", 1); // mute
                }
            }
            Check_Update();

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                //offline
            }
            else
            {
                if (_playfabAccessLogin.PlayerLogin == true)
                {
                    _playfab.SaveMuteSettings(PlayerPrefs.GetInt("MuteBGM"), PlayerPrefs.GetInt("MuteSFX"));
                }

            }
        }

        void SoundButtonEffect()
        {
            SoundEffectScript.instance.Play(SoundEffectScript.instance.SoundButton);
        }
    }
}

