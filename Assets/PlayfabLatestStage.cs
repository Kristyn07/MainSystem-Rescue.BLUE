using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace Network.Manager
{

    public class PlayfabLatestStage : MonoBehaviour
    {
        //[SerializeField] PlayfabManagerScript _mainPlayfabManager;
        [SerializeField] bool IsInMainMenu;
        [SerializeField] NewPlayer _newplayer;

        [Header("Saving Option")]
        [SerializeField] ToggleButtonsPrefabs _toggleButtonPrefabs;
        [SerializeField] PlayfabOnlineDetector _playfabAccessLogin;
        public void Start()
        {
            
            //Invoke("OnlineLogin", 1);
            StartCoroutine(PlayerData());

        }

        IEnumerator PlayerData()
        {

            if (_playfabAccessLogin.PlayerLogin == true)
            {
                yield return new WaitForSeconds(1f);
                if ((PlayerPrefs.GetInt("StageSelection") + 1) != PlayerPrefs.GetInt("Continue"))
				{
                    PlayerPrefs.SetInt("StageSelection", PlayerPrefs.GetInt("Continue")-1);

                }
                yield return new WaitForSeconds(1.5f);
                GetLatestStage();
                if (IsInMainMenu)
                {
                    
                    GetOptionAnimated();
                    GetOptionVibration();
                    _newplayer.Start();
                }
                int isOn = PlayerPrefs.GetInt("AnimatedTextToggle");
                int vison = PlayerPrefs.GetInt("VibrationToggle");
               
                SaveOptionAnimated(isOn);
                SaveOptionVibration(vison);
            }

            
        }


        public void SaveLatestStageBTNNewGame()
		{
            if (_playfabAccessLogin.PlayerLogin == true)
            {
                PlayerPrefs.SetInt("Continue", 2);
                SaveLatestStage(1);
                
            }
        }   


        

        public void SaveLatestStage(int stage)
        {
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
        {
            { "LatestLevel", stage.ToString() }
        }
            };

            PlayFabClientAPI.UpdateUserData(request, OnDataSaved, OnDataSaveError);
        }

        private void OnDataSaved(UpdateUserDataResult result)
        {
            // Data saved successfully
            Debug.Log("Latest stage saved successfully!");
        }

        private void OnDataSaveError(PlayFabError error)
        {
            // Handle the error
            Debug.LogError("Failed to save latest stage: " + error.ErrorMessage);
        }

        public void GetLatestStage()
        {
            var request = new GetUserDataRequest();

            PlayFabClientAPI.GetUserData(request, OnUserDataReceived, OnUserDataError);
        }

        private void OnUserDataReceived(GetUserDataResult result)
        {
            if (result.Data.TryGetValue("LatestLevel", out var latestStageValue))
            {
                int latestStage = int.Parse(latestStageValue.Value);
                Debug.Log("Latest stage: " + latestStage+1);
                //getlatest stage and store to stage selection
                if (latestStage > PlayerPrefs.GetInt("StageSelection"))
				{
                    PlayerPrefs.SetInt("StageSelection", latestStage);
                    PlayerPrefs.SetInt("Continue", latestStage + 1);
                }
				else
				{
                    int stage = PlayerPrefs.GetInt("StageSelection");
                    SaveLatestStage(stage);
                }
                
                if (IsInMainMenu)
                {
                    if (latestStage > 0)
                    {
                        foreach (GameObject obj in _newplayer.ContinueButton)
                        {
                            obj.SetActive(true);
                            PlayerPrefs.SetInt("NewPlayer", 1);
                        }

                    }
                    else
                    {
                        foreach (GameObject obj in _newplayer.ContinueButton)
                        {
                            obj.SetActive(false);
                            PlayerPrefs.SetInt("NewPlayer", 0);
                        }
                    }
                }

            }
            else
            {
                Debug.Log("Latest stage not found");
            }
        }

        private void OnUserDataError(PlayFabError error)
        {
            // Handle the error
            Debug.LogError("Failed to get user data: " + error.ErrorMessage);
        }


        // Save AnimatedText Option 


        public void SaveOptionAnimated(int isOn)
        {
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
        {
            { "AnimatedOption", isOn.ToString() }
        }
            };

            PlayFabClientAPI.UpdateUserData(request, OnDataAnimatedSaved, OnDataAnimatedSaveError);
        }
        private void OnDataAnimatedSaved(UpdateUserDataResult result)
        {
            // Data saved successfully
            Debug.Log("Animated Option Save saved successfully!");
        }

        private void OnDataAnimatedSaveError(PlayFabError error)
        {
            // Handle the error
            Debug.LogError("Failed to save animated option: " + error.ErrorMessage);
        }

        public void GetOptionAnimated()
        {
            var request = new GetUserDataRequest();

            PlayFabClientAPI.GetUserData(request, OnUserDataAnimatedReceived, OnUserAnimatedDataError);
        }

        private void OnUserDataAnimatedReceived(GetUserDataResult result)
        {
            if (result.Data.TryGetValue("AnimatedOption", out var animatedOptionValue))
            {
                int ison = int.Parse(animatedOptionValue.Value);
                Debug.Log("Animated Option: " + ison);
                //getlatest stage and store to stage selection

                PlayerPrefs.SetInt("AnimatedTextToggle", ison);
                _toggleButtonPrefabs.Start();
            }
            else
            {
                Debug.Log("Animated Option NotFound");
            }
        }

        private void OnUserAnimatedDataError(PlayFabError error)
        {
            // Handle the error
            Debug.LogError("Failed to get user animated option: " + error.ErrorMessage);
        }


        // Save Vibration Option 


        public void SaveOptionVibration(int isOn)
        {
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
        {
            { "VibrationOption", isOn.ToString() }
        }
            };

            PlayFabClientAPI.UpdateUserData(request, OnDataVibrationSaved, OnDataVibrationSaveError);
        }
        private void OnDataVibrationSaved(UpdateUserDataResult result)
        {
            // Data saved successfully
            Debug.Log("vibration Option Save saved successfully!");
        }

        private void OnDataVibrationSaveError(PlayFabError error)
        {
            // Handle the error
            Debug.LogError("Failed to save vibration option: " + error.ErrorMessage);
        }

        public void GetOptionVibration()
        {
            var request = new GetUserDataRequest();

            PlayFabClientAPI.GetUserData(request, OnUserDataVibrationReceived, OnUserVibrationDataError);
        }

        private void OnUserDataVibrationReceived(GetUserDataResult result)
        {
            if (result.Data.TryGetValue("VibrationOption", out var vibrationOptionValue))
            {
                int ison = int.Parse(vibrationOptionValue.Value);
                Debug.Log("Vibration Option: " + ison);
                //getlatest stage and store to stage selection

                PlayerPrefs.SetInt("VibrationToggle", ison);
                _toggleButtonPrefabs.Start();
            }
            else
            {
                Debug.Log("vibration Option NotFound");
            }
        }

        private void OnUserVibrationDataError(PlayFabError error)
        {
            // Handle the error
            Debug.LogError("Failed to get user vibration option: " + error.ErrorMessage);
        }
    }

}
