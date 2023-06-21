using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Character.Editor;

namespace Network.Manager
{
    public class PlayfabSaveCharacter : MonoBehaviour
    {
        /*   PlayerPrefs.SetInt("Head", HeadCount);
             PlayerPrefs.SetInt("Torso", TorsoCount);
             PlayerPrefs.SetInt("Pelvis", PelvisCount);
             PlayerPrefs.SetInt("L U Arm", LeftUpperArmCount);
             PlayerPrefs.SetInt("L L Arm", LeftLowerArmCount);
             PlayerPrefs.SetInt("L U Leg", LeftUpperLegCount);
             PlayerPrefs.SetInt("L L Leg", LeftLowerLegCount);
             PlayerPrefs.SetInt("R U Arm", RightUpperArmCount);
             PlayerPrefs.SetInt("R L Arm", RightLowerArmCount);
             PlayerPrefs.SetInt("R U Leg", RightUpperLegCount);
             PlayerPrefs.SetInt("R L Leg", RightLowerLegCount);*/
        public CharacterCustomizationManagerScript _characterScript;
        [SerializeField] PlayfabOnlineDetector _playfabAccessLogin;

        public void Start()
        {
            OnlineLogin();

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
                    int HeadCount = PlayerPrefs.GetInt("Head");
                    int TorsoCount = PlayerPrefs.GetInt("Torso");
                    int PelvisCount = PlayerPrefs.GetInt("Pelvis");
                    int LeftUpperArmCount = PlayerPrefs.GetInt("L U Arm");
                    int LeftLowerArmCount = PlayerPrefs.GetInt("L L Arm");
                    int LeftUpperLegCount = PlayerPrefs.GetInt("L U Leg");
                    int LeftLowerLegCount = PlayerPrefs.GetInt("L L Leg");
                    int RightUpperArmCount = PlayerPrefs.GetInt("R U Arm");
                    int RightLowerArmCount = PlayerPrefs.GetInt("R L Arm");
                    int RightUpperLegCount = PlayerPrefs.GetInt("R U Leg");
                    int RightLowerLegCount = PlayerPrefs.GetInt("R L Leg");


                    SavePlayerSettings(TorsoCount, PelvisCount, LeftUpperArmCount, LeftLowerArmCount, LeftUpperLegCount, LeftLowerLegCount, RightUpperArmCount, RightLowerArmCount, RightUpperLegCount, RightLowerLegCount);
                    SavePlayerSettings1(HeadCount);
                    LoadPlayerSettings();
                }
            }

        }

        public void SavePlayerSettings( int torsoCount, int pelvisCount, int leftUpperArmCount, int leftLowerArmCount, int leftUpperLegCount, int leftLowerLegCount, int rightUpperArmCount, int rightLowerArmCount, int rightUpperLegCount, int rightLowerLegCount)
        {
            // Create a request to update the player's custom data
            UpdateUserDataRequest request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
        {
            //{ "HeadCount", headCount.ToString() },
            { "TorsoCount", torsoCount.ToString() },
            { "PelvisCount", pelvisCount.ToString() },
            { "LeftUpperArmCount", leftUpperArmCount.ToString() },
            { "LeftLowerArmCount", leftLowerArmCount.ToString() },
            { "LeftUpperLegCount", leftUpperLegCount.ToString() },
            { "LeftLowerLegCount", leftLowerLegCount.ToString() },
            { "RightUpperArmCount", rightUpperArmCount.ToString() },
            { "RightLowerArmCount", rightLowerArmCount.ToString() },
            { "RightUpperLegCount", rightUpperLegCount.ToString() },
            { "RightLowerLegCount", rightLowerLegCount.ToString() }
        }
            };

            // Call the API to update the player's data
            PlayFabClientAPI.UpdateUserData(request, OnSavePlayerSettingsSuccess, OnSavePlayerSettingsFailure);
        }
        public void SavePlayerSettings1(int headCount)
        {
            // Create a request to update the player's custom data
            UpdateUserDataRequest request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>()
        {
            //{ "HeadCount", headCount.ToString() },
             { "HeadCount", headCount.ToString() }
            
        }
            };

            // Call the API to update the player's data
            PlayFabClientAPI.UpdateUserData(request, OnSavePlayerSettingsSuccess, OnSavePlayerSettingsFailure);
        }
        private void OnSavePlayerSettingsSuccess(UpdateUserDataResult result)
        {
            Debug.Log("Player Settings Sent");
            //successfully saving player settings
        }

        private void OnSavePlayerSettingsFailure(PlayFabError error)
        {
            Debug.Log("Error Sending Player Settings: " + error.ErrorMessage);
            Debug.Log("Error Details: " + error.GenerateErrorReport());
        }

        public void LoadPlayerSettings()
        {
            // Create a request to get the player's custom data
            GetUserDataRequest request = new GetUserDataRequest();

            // Call the API to retrieve the player's data
            PlayFabClientAPI.GetUserData(request, OnLoadPlayerSettingsSuccess, OnLoadPlayerSettingsFailure);
        }
        private void OnLoadPlayerSettingsSuccess(GetUserDataResult result)
        {
            // Check if the custom data keys exist in the result
            if (
                result.Data.ContainsKey("TorsoCount") &&
                result.Data.ContainsKey("PelvisCount") &&
                result.Data.ContainsKey("LeftUpperArmCount") &&
                result.Data.ContainsKey("LeftLowerArmCount") &&
                result.Data.ContainsKey("LeftUpperLegCount") &&
                result.Data.ContainsKey("LeftLowerLegCount") &&
                result.Data.ContainsKey("RightUpperArmCount") &&
                result.Data.ContainsKey("RightLowerArmCount") &&
                result.Data.ContainsKey("RightUpperLegCount") &&
                result.Data.ContainsKey("RightLowerLegCount"))
            {
                // Retrieve the player settings from the custom data
               
                int torsoCount = int.Parse(result.Data["TorsoCount"].Value);
                int pelvisCount = int.Parse(result.Data["PelvisCount"].Value);
                int leftUpperArmCount = int.Parse(result.Data["LeftUpperArmCount"].Value);
                int leftLowerArmCount = int.Parse(result.Data["LeftLowerArmCount"].Value);
                int leftUpperLegCount = int.Parse(result.Data["LeftUpperLegCount"].Value);
                int leftLowerLegCount = int.Parse(result.Data["LeftLowerLegCount"].Value);
                int rightUpperArmCount = int.Parse(result.Data["RightUpperArmCount"].Value);
                int rightLowerArmCount = int.Parse(result.Data["RightLowerArmCount"].Value);
                int rightUpperLegCount = int.Parse(result.Data["RightUpperLegCount"].Value);
                int rightLowerLegCount = int.Parse(result.Data["RightLowerLegCount"].Value);

                // Set the player settings in the PlayerPrefs game's data manager
                
                PlayerPrefs.SetInt("Torso", torsoCount);
                PlayerPrefs.SetInt("Pelvis", pelvisCount);
                PlayerPrefs.SetInt("L U Arm", leftUpperArmCount);
                PlayerPrefs.SetInt("L L Arm", leftLowerArmCount);
                PlayerPrefs.SetInt("L U Leg", leftUpperLegCount);
                PlayerPrefs.SetInt("L L Leg", leftLowerLegCount);
                PlayerPrefs.SetInt("R U Arm", rightUpperArmCount);
                PlayerPrefs.SetInt("R L Arm", rightLowerArmCount);
                PlayerPrefs.SetInt("R U Leg", rightUpperLegCount);
                PlayerPrefs.SetInt("R L Leg", rightLowerLegCount);

               /* PlayerPrefs.SetInt("TorsoCount", torsoCount);
                PlayerPrefs.SetInt("PelvisCount", pelvisCount);
                PlayerPrefs.SetInt("LeftUpperArmCount", leftUpperArmCount);
                PlayerPrefs.SetInt("LeftLowerArmCount", leftLowerArmCount);
                PlayerPrefs.SetInt("LeftUpperLegCount", leftUpperLegCount);
                PlayerPrefs.SetInt("LeftLowerLegCount", leftLowerLegCount);
                PlayerPrefs.SetInt("RightUpperArmCount", rightUpperArmCount);
                PlayerPrefs.SetInt("RightLowerArmCount", rightLowerArmCount);
                PlayerPrefs.SetInt("RightUpperLegCount", rightUpperLegCount);
                PlayerPrefs.SetInt("RightLowerLegCount", rightLowerLegCount);*/
                Debug.Log("torsoCount Get" + torsoCount);
                Debug.Log("PelvisCount Get" + pelvisCount);
                Debug.Log("Player Settings Loaded");
            }
			else
			{
                Debug.Log("Char Error");
            }

            if (result.Data.ContainsKey("HeadCount"))
			{
                int headCount = int.Parse(result.Data["HeadCount"].Value);
                PlayerPrefs.SetInt("Head", headCount);
                Debug.Log("headCount Get" + headCount);
                Debug.Log("Head Player Settings Loaded");
            }
			else
			{
                Debug.Log("Head Error");
			}
            _characterScript.Start();

        }

        private void OnLoadPlayerSettingsFailure(PlayFabError error)
        {
            Debug.Log("Error Loading Player Settings");
           
        }


    }
} 

