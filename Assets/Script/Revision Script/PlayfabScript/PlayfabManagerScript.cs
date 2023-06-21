
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using Network.LeaderBoard;

namespace Network.Manager
{
    [DefaultExecutionOrder(-200)]
    public class PlayfabManagerScript : MonoBehaviour
    {
        [SerializeField]
        PlayfabLeaderBoardManagerScript LeaderBoard;
        //Registration
        [SerializeField]
        TextMeshProUGUI RegistrationMessageText;
        [SerializeField]
        TMP_InputField RegEmailFieldInput;
        [SerializeField]
        TMP_InputField RegPasswordFieldInput;
        [SerializeField]
        TMP_InputField RegUserFieldInput;

        [SerializeField]
        GameObject RegistrationPage;

        //Login
        [SerializeField]
        TextMeshProUGUI LoginMessageText;
        [SerializeField]
        TMP_InputField LoginEmailFieldInput;
        [SerializeField]
        TMP_InputField LoginPasswordFieldInput;

        //Success Login!
        [SerializeField]
        GameObject[] DisplayObject;
        [SerializeField]
        GameObject HideLoginPage;

        public
        TextMeshProUGUI UserNameText;

        //Reset Password
        [SerializeField]
        string ServerID;
        [SerializeField]
        TMP_InputField ResetPasswordFieldInput;

        //Player Name
        [SerializeField]
        string PlayerOfficialName;
        [SerializeField]
        string PlayerOfficialPassword;
        [SerializeField]
        string PlayerPlayfabID;

        //Control
        [SerializeField]
        bool MainMenu;
		private string playerId = "1F3C8F9253F2C5EB";
        private string leaderboardName = "Rescue Blue Score";
        [Header("GetPlayerData")]
        //[SerializeField] string _UserName;
        public int _UserScore;

        [SerializeField] string PlayerOfficialRankTitle;
        public TextMeshProUGUI PlayerRankText;
        [SerializeField] string PlayerOfficialScore;
        public TextMeshProUGUI PlayerScoreText;
        [SerializeField] string PlayerOfficialRankNumber;
        public TextMeshProUGUI PlayerRankNumberText;
        [SerializeField] PlayfabLeaderBoardManagerScript _playfabLeaderBoardManagerScript;
        [SerializeField] PlayfabOnlineDetector _playfabOnlineDetector;
        [SerializeField] NewPlayer _newPlayer;
        public Transform ResultPosRank;
        [SerializeField] PlayfabLatestStage _latestStage;
        [SerializeField] PlayFabSaveVolume _volume;
        [SerializeField] PlayfabSaveCharacter _character;

        [Header("LogOUT Stuff")]
        [SerializeField] GameObject MyAccount;
        [SerializeField] GameObject LoginCollection;
        [SerializeField] TextMeshProUGUI LogoutResultTitle;

        public void Start()
		{
            PlayerOfficialName = PlayerPrefs.GetString("Player Name");
            PlayerOfficialPassword = PlayerPrefs.GetString("Player Password");
            
        }


		public void ShowPanel(GameObject ObjID)
        {
            ObjID.gameObject.SetActive(true);
        }
        public void HidePanel(GameObject ObjID)
        {
            ObjID.gameObject.SetActive(false);
        }
        public void RegisterButton()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                RegistrationMessageText.text = "No Internet!";
                StartCoroutine(DisableRegistrationResult());
            }
            else 
            {
                var requestRegistration = new RegisterPlayFabUserRequest
                {
                    Email = RegEmailFieldInput.text,
                    Password = RegPasswordFieldInput.text,
                    Username = RegUserFieldInput.text,
                    RequireBothUsernameAndEmail = true

                    



            };
                PlayFabClientAPI.RegisterPlayFabUser(requestRegistration, OnRegisterSuccess, OnRegisterError);
            }

           
        }

        void OnRegisterSuccess(RegisterPlayFabUserResult result)
        {
            //delete playerprefs
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("Deleted All");

            //addnewscript for new player 

            //call stage selection lock all 
            //call continue hide

            PlayerPrefs.SetString("Player Name", RegUserFieldInput.text);
            //PlayerOfficialPassword = LoginPasswordFieldInput.text;
            PlayerPrefs.SetString("Player Password", RegPasswordFieldInput.text);
            PlayerPrefs.SetInt("PlayerHasLogIn", 1);
            PlayerOfficialName = PlayerPrefs.GetString("Player Name");
            PlayerOfficialPassword = PlayerPrefs.GetString("Player Password");

            Debug.Log(PlayerOfficialName);
            //set name
            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = PlayerOfficialName

            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnUpdateDisplayNameSuccess, OnUpdateDisplayNameFailure);
            // autologin
            PlayerPrefs.SetInt("PlayerHasLogIn", 1);
            LoginButton();
            RegistrationMessageText.text = "Registration Complete.";
            StartCoroutine(RegistrationCompleteResult());

            //Add player to leaderboard 0
            LeaderBoard.SendLeaderboard(PlayerPrefs.GetInt("MainTotalScore_ALLSTAGES"));

            //set latest stage
            _latestStage.SaveLatestStage(PlayerPrefs.GetInt("StageSelection"));
            PlayerPrefs.SetInt("VibrationToggle", 1);
            PlayerPrefs.SetInt("AnimatedTextToggle", 1);
            PlayerPrefs.SetFloat("Music Volume", 0.75f);
            PlayerPrefs.SetFloat("Sound Volume", 0.75f);
            PlayerPrefs.SetInt("MuteBGM", 0);
            PlayerPrefs.SetInt("MuteSFX", 0);
            _latestStage.SaveOptionAnimated(PlayerPrefs.GetInt("AnimatedTextToggle"));
            _latestStage.SaveOptionVibration(PlayerPrefs.GetInt("VibrationToggle"));
            _volume.SaveBGMVolume(PlayerPrefs.GetFloat("Music Volume"));
            _volume.SaveSFXVolume(PlayerPrefs.GetFloat("Sound Volume"));
            _volume.SaveMuteSettings(PlayerPrefs.GetInt("MuteBGM"), PlayerPrefs.GetInt("MuteSFX"));
            _character.SavePlayerSettings(
            PlayerPrefs.GetInt("Torso"),
            PlayerPrefs.GetInt("Pelvis"),
            PlayerPrefs.GetInt("L U Arm"),
            PlayerPrefs.GetInt("L L Arm"),
            PlayerPrefs.GetInt("L U Leg"),
            PlayerPrefs.GetInt("L L Leg"),
            PlayerPrefs.GetInt("R U Arm"),
            PlayerPrefs.GetInt("R L Arm"),
            PlayerPrefs.GetInt("R U Leg"),
            PlayerPrefs.GetInt("R L Leg"));
            _character.SavePlayerSettings1(PlayerPrefs.GetInt("Head"));
            _playfabOnlineDetector.PlayerLogin = true;

        }

        private void OnUpdateDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
        {
            // Display name updated successfully
            Debug.Log("success");
        }

        private void OnUpdateDisplayNameFailure(PlayFabError error)
        {
            // Handle the error
            Debug.LogError("Update display name error: " + error.GenerateErrorReport());
        }



        void OnRegisterError(PlayFabError error)
        {
            
            //RegistrationMessageText.text = "Registration Error.";
            switch (error.Error)
            {
                case PlayFabErrorCode.EmailAddressNotAvailable:
                    RegistrationMessageText.text = "The email address is already in use.Please choose a different email.";
                    break;

                case PlayFabErrorCode.InvalidParams:
                    RegistrationMessageText.text = "Invalid Input. Please check your input and try again.";
                    break;

                default:
                    RegistrationMessageText.text = "An error occurred. Please try again later or contact support.";
                    break;
            }
            StartCoroutine(DisableRegistrationResult());
        }

        IEnumerator DisableRegistrationResult()
        {
            yield return new WaitForSeconds(2f);
            RegistrationMessageText.text = "";
        }

        IEnumerator RegistrationCompleteResult()
        {


            RegEmailFieldInput.text = "";
            RegPasswordFieldInput.text = "";
            RegUserFieldInput.text = "";

            yield return new WaitForSeconds(2f);
            RegistrationPage.gameObject.SetActive(false);
            // new player
            

            RegistrationMessageText.text = "";
            // new player Delete PlayerPrefs
            //score
            PlayerPrefs.SetInt("Continue", 0);
            PlayerPrefs.SetInt("StageSelection", 0);
            PlayerPrefs.SetInt("Reply", 0);
            PlayerPrefs.SetInt("MainTotalScore_ALLSTAGES", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_1", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_2", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_3", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_4", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_5", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_6", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_7", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_8", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_9", 0);
            PlayerPrefs.SetInt("MainTotalScore_Stage_10", 0);
            PlayerPrefs.SetInt("IntPlayerScore", 0);
            //autologin
            PlayerPrefs.SetInt("PlayerHasLogIn", 1);
            //new player
            PlayerPrefs.SetInt("NewPlayer", 0);
            _newPlayer.Start();
            
            _playfabOnlineDetector.Start();
            //stages
            PlayerPrefs.SetInt("StageSelection", 0);
            //PlayerPrefs.DeleteAll(); // Reset all player preferences
        }

        public void LoginButton()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                LoginMessageText.text = "No Internet!";
                StartCoroutine(LoginErrorRemoveDisplay());
            }
            else
            {
                if (PlayerPrefs.GetInt("PlayerHasLogIn") == 0) // login not 
                {
                    var requestLoginEmail = new LoginWithEmailAddressRequest
                    {
                        Email = LoginEmailFieldInput.text,
                        Password = LoginPasswordFieldInput.text
                    };
                    PlayFabClientAPI.LoginWithEmailAddress(requestLoginEmail, OnEmailLoginSuccess, OnLoginUserName);
                    Debug.Log("PlayerLogin");
                    _playfabOnlineDetector.PlayerLogin = true;
                }
                
                else if (PlayerPrefs.GetInt("PlayerHasLogIn") == 1) // auto login
				{
                    var requestLoginEmail = new LoginWithEmailAddressRequest
                    {
                        Email = PlayerPrefs.GetString("Player Name"),
                        Password = PlayerPrefs.GetString("Player Password")
                    };
                    PlayFabClientAPI.LoginWithEmailAddress(requestLoginEmail, OnEmailLoginSuccess, OnLoginUserName);
                    Debug.Log("AutoLogin");
                    _playfabOnlineDetector.PlayerLogin = true;
                }
                _latestStage.GetLatestStage();
                _latestStage.GetOptionAnimated();
                _latestStage.GetOptionVibration();
                _volume.LoadBGMVolume();
                _volume.LoadSFXVolume();
                _volume.LoadMuteSettings();
                _character.LoadPlayerSettings();

            }
           

        }

        void OnEmailLoginSuccess(LoginResult EmailNameDisplayresult)
        {
            var requestFetchUsername = new LoginWithEmailAddressRequest
            {
                Email = LoginEmailFieldInput.text,
                Password = LoginPasswordFieldInput.text,
                InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                {
                    GetPlayerProfile = true,
                    ProfileConstraints = new PlayerProfileViewConstraints
                    {
                        ShowDisplayName = true
                    }
                }

            };

            PlayFabClientAPI.LoginWithEmailAddress(requestFetchUsername, OnEmailDisplayNameSuccess, OnUserNameDisplayError);


            LoginMessageText.text = "Login Success!";
            //_playfabLeaderBoardManagerScript.GetLeaderBoard();
            //GetPlayerRank();

            StartCoroutine(LoginPageProceed());
            _latestStage.GetLatestStage();
            _latestStage.GetOptionAnimated();
            _latestStage.GetOptionVibration();
            _playfabOnlineDetector.PlayerLogin = true;
        }

        void OnEmailDisplayNameSuccess(LoginResult EmailNameDisplayresult)
        {
            UserNameText.text = EmailNameDisplayresult.InfoResultPayload.PlayerProfile.DisplayName;
            //PlayerOfficialName = EmailNameDisplayresult.InfoResultPayload.PlayerProfile.DisplayName;
            //PlayerPrefs.SetString("Player Name", UserNameText.text);
            //PlayerOfficialPassword = LoginPasswordFieldInput.text;
            //PlayerPrefs.SetString("Player Password", LoginPasswordFieldInput.text);

            //PlayerOfficialName = EmailNameDisplayresult.InfoResultPayload.PlayerProfile.DisplayName;
            PlayerPrefs.SetString("Player Name", UserNameText.text);
            //PlayerOfficialPassword = LoginPasswordFieldInput.text;
            PlayerPrefs.SetString("Player Password", LoginPasswordFieldInput.text);
            PlayerPrefs.SetInt("PlayerHasLogIn", 1);
            PlayerOfficialName = PlayerPrefs.GetString("Player Name");
            PlayerOfficialPassword = PlayerPrefs.GetString("Player Password");

            GetPlayfabID();

        }

        void OnLoginUserName(PlayFabError errorEmail)
        {

            var requestLoginUserName = new LoginWithPlayFabRequest
            {
                Username = LoginEmailFieldInput.text,
                Password = LoginPasswordFieldInput.text
            };
            PlayFabClientAPI.LoginWithPlayFab(requestLoginUserName, OnUserNameLoginSuccess, OnLoginError);
        }

        void OnUserNameLoginSuccess(LoginResult result)
        {
            var requestFetchUsername = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = LoginEmailFieldInput.text
            };

            PlayFabClientAPI.UpdateUserTitleDisplayName(requestFetchUsername, OnUserNameDisplaySuccess, OnUserNameDisplayError);

            PlayerPrefs.SetString("Player Name", LoginEmailFieldInput.text) ;
            //PlayerOfficialPassword = LoginPasswordFieldInput.text;
            PlayerPrefs.SetString("Player Password", LoginPasswordFieldInput.text);
            PlayerPrefs.SetInt("PlayerHasLogIn", 1);
            
            PlayerOfficialName = PlayerPrefs.GetString("Player Name");
            PlayerOfficialPassword = PlayerPrefs.GetString("Player Password");
            GetPlayfabID();
           
            //var requestFetchUsername = new LoginWithEmailAddressRequest
            //{
            //    Email = LoginEmailFieldInput.text,
            //    Password = LoginPasswordFieldInput.text,
            //    InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            //    {
            //        GetPlayerProfile = true
            //    }
            //};

            //PlayFabClientAPI.LoginWithEmailAddress(requestFetchUsername, OnUserNameDisplaySuccess, OnUserNameDisplayError);

            LoginMessageText.text = "Login Success!";

            //_playfabLeaderBoardManagerScript.GetLeaderBoard();
            GetPlayerInfo();
            
            //_playfabLeaderBoardManagerScript.GetRank();
            StartCoroutine(LoginPageProceed());
            _latestStage.GetLatestStage();
            _latestStage.GetOptionAnimated();
            _latestStage.GetOptionVibration();
            _volume.LoadBGMVolume();
            _volume.LoadSFXVolume();
            _volume.LoadMuteSettings();
            _character.LoadPlayerSettings();
        }


         void OnUserNameDisplaySuccess(UpdateUserTitleDisplayNameResult result)
        // void OnUserNameDisplaySuccess(LoginResult result)
        {
            UserNameText.text = result.DisplayName;
            Debug.Log("Success");
        }

        void OnUserNameDisplayError(PlayFabError error)
        {
            Debug.Log(error.GenerateErrorReport());
            Debug.Log("Error");
        }


        IEnumerator LoginPageProceed()
        {
            yield return new WaitForSeconds(1f);
            LoginMessageText.text = "";
            HideLoginPage.gameObject.SetActive(false);
            foreach (GameObject obj in DisplayObject)
            {
                obj.gameObject.SetActive(true);
            }
        }

        void OnLoginError(PlayFabError error)
        {
            LoginPasswordFieldInput.text = "";
            LoginEmailFieldInput.text = "";
            //different kind of error
            switch (error.Error)
            {
                case PlayFabErrorCode.InvalidParams:
                    LoginMessageText.text = "Invalid email or password. Please try again.";
                    break;

                case PlayFabErrorCode.AccountNotFound:
                    LoginMessageText.text = "Account not found. Please create an account.";
                    break;

                case PlayFabErrorCode.AccountBanned:
                    LoginMessageText.text = "Your account has been banned. Please contact support for assistance.";
                    break;

               /* case PlayFabErrorCode.RequestTimeout:
                    LoginMessageText.text = "The server timed out. Please try again later.";
                    break;*/

                default:
                    LoginMessageText.text = "An error occurred. Please try again later or contact support.";
                    break;
            }

            
                    //LoginMessageText.text = "Login Error!";

            StartCoroutine(LoginErrorRemoveDisplay());
        }
        IEnumerator LoginErrorRemoveDisplay()
        {
            yield return new WaitForSeconds(2f);
            LoginMessageText.text = "";
        }
        public void ResetPasswordButton()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                LoginMessageText.text = "No Internet!";
                StartCoroutine(LoginErrorRemoveDisplay());
            }
            var requestEmailRecovery = new SendAccountRecoveryEmailRequest
            {
                Email = ResetPasswordFieldInput.text,
                TitleId = ServerID
            };


            PlayFabClientAPI.SendAccountRecoveryEmail(requestEmailRecovery, OnPasswordReset, OnPasswordRecoveryError);
        }

        void OnPasswordReset(SendAccountRecoveryEmailResult result)
        {
            
            LoginMessageText.text = "Password Reset Email Sent!";
            ResetPasswordFieldInput.text = "";
            LoginPasswordFieldInput.text = "";
            StartCoroutine(ResetPasswordRemoveDisplay());
        }

        void OnPasswordRecoveryError(PlayFabError error)
        {
            LoginMessageText.text = "Email Not Found.";
            ResetPasswordFieldInput.text = "";
            LoginPasswordFieldInput.text = "";
            StartCoroutine(ResetPasswordRemoveDisplay());
        }

        IEnumerator ResetPasswordRemoveDisplay()
        {
            yield return new WaitForSeconds(2f);
            LoginMessageText.text = "";
        }

        void GetPlayfabID()
        {
            var RequestID = new GetAccountInfoRequest
            {
               
            };

            PlayFabClientAPI.GetAccountInfo(RequestID, OnGetPlayfabID, OnErrorPlayfabID);

        }

        void OnGetPlayfabID(GetAccountInfoResult result)
        {
            PlayerPlayfabID = result.AccountInfo.PlayFabId;
            PlayerPrefs.SetString("Player ID", PlayerPlayfabID);
            if (MainMenu == true)
            {
                LeaderBoard.MainMenuLoginData();
                
            }
        }

        void OnErrorPlayfabID(PlayFabError error)
        {
            Debug.Log(error.GenerateErrorReport());
        }

        public void Logout() // reset info
        {
            if (_playfabOnlineDetector.PlayerLogin)
			{
                bool x = false;
                if (x == false)
				{
                    //DestroyAllChildren();
                    PlayerPrefs.DeleteAll();
                    PlayerPrefs.Save();
                    Debug.Log("Deleted All");

                    //callscript
                    _newPlayer.Start();

                    LoginPasswordFieldInput.text = "";
                    LoginEmailFieldInput.text = "";
                    _UserScore = 0;
                    PlayerOfficialName = "";
                    PlayerOfficialPassword = "";
                    PlayerPlayfabID = "";
                    PlayerOfficialRankTitle = "";
                    //PlayerRankText.text = "1234";
                    PlayerOfficialScore = "";
                    //PlayerScoreText.text = "1234";
                    PlayerOfficialRankNumber = "";
                    //PlayerRankNumberText.text = "";


                    PlayerPrefs.SetString("Player Name", "Guest");
                    PlayerPrefs.SetString("Player Password", "");
                    PlayerPrefs.SetInt("PlayerHasLogIn", 0);
                    PlayerPrefs.SetString("PlayerRank", "TRAINEE");
                    PlayerPrefs.SetString("PlayerRankNumber", "n/a");
                    PlayerPrefs.SetString("PlayerScore", "0");
                    PlayerPrefs.SetInt("IntPlayerScore", 0);
                    PlayerPrefs.SetInt("VibrationToggle", 1);
                    PlayerPrefs.SetInt("AnimatedTextToggle", 1);
                    PlayerPrefs.SetFloat("Music Volume", 0.75f);
                    PlayerPrefs.SetFloat("Sound Volume", 0.75f);

                    PlayFabClientAPI.ForgetAllCredentials();
                    Debug.Log("Log Out");
                    MyAccount.SetActive(false);
                    LoginCollection.SetActive(true);
                    x = true;
                    _character._characterScript.Start();
                    _playfabOnlineDetector.PlayerLogin = false;
                }
            }
			else
			{
                LogoutResultTitle.text = "Logout failed. Please connect to the internet to perform a logout.";
                StartCoroutine(LogoutText());
            }
        }

        IEnumerator LogoutText()
		{
            yield return new WaitForSeconds(2f);
            LogoutResultTitle.text = "";
        }
        // Get Player Information 
        public void GetPlayerInfo()
        {
            GetPlayerScore(PlayerPlayfabID);

        }
        public void GetPlayerRank()
		{
            if (_UserScore >= _playfabLeaderBoardManagerScript.MinScore_1)//2196
            {
                GameObject F = Instantiate(_playfabLeaderBoardManagerScript.Rank01ImageObj) as GameObject;
                F.transform.SetParent(ResultPosRank.transform, false);
                PlayerOfficialRankTitle = "MASTER";  
            }

            if (_UserScore >= _playfabLeaderBoardManagerScript.MinScore_2 && _UserScore <= _playfabLeaderBoardManagerScript.MaxScore_2) //
            {
                GameObject F = Instantiate(_playfabLeaderBoardManagerScript.Rank02ImageObj) as GameObject;
                F.transform.SetParent(ResultPosRank.transform, false);
                PlayerOfficialRankTitle = "INTERMEDIATE";
            }

            if (_UserScore >= _playfabLeaderBoardManagerScript.MinScore_3 && _UserScore <= _playfabLeaderBoardManagerScript.MaxScore_3)//if (result.Leaderboard[i].StatValue >= 2180 && result.Leaderboard[i].StatValue <= 2189) 
            {
                GameObject F = Instantiate(_playfabLeaderBoardManagerScript.Rank03ImageObj) as GameObject;
                F.transform.SetParent(ResultPosRank.transform, false);
                PlayerOfficialRankTitle = "TRAINEE";
            }
            
            PlayerRankText.text = PlayerOfficialRankTitle;
            PlayerPrefs.SetString("PlayerRank", PlayerOfficialRankTitle);
            PlayerOfficialScore = _UserScore.ToString();
            PlayerScoreText.text = PlayerOfficialScore;
            PlayerPrefs.SetString("PlayerScore", PlayerOfficialScore);
            GetOfficialPlayerRank();
        }

        public void GetPlayerScore(string leaderboardName, string playerId)
        {
            var request = new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = leaderboardName,
                MaxResultsCount = 1,
                PlayFabId = playerId
            };

            PlayFabClientAPI.GetLeaderboardAroundPlayer(request, result =>
            {
                if (result.Leaderboard.Count > 0)
                {
                    var playerScore = result.Leaderboard[0].StatValue;
                    // Do something with the player's score, like display it on screen
                    //playerScoreFromData = playerScore;
                    Debug.Log("playerScoreFromData");
                }
                else
                {
                    // The specified player ID was not found on the leaderboard
                    Debug.Log("Errorsdasd");
                }
            }, error => Debug.LogError(error.GenerateErrorReport()));
        }

        public void GetPlayerScore(string playfabId)
        {
            var request = new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = "Rescue Blue Score",
                PlayFabId = playfabId,
                MaxResultsCount = 1
            };
            PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetPlayerScoreSuccess, OnGetPlayerScoreFailure);
        }

        private void OnGetPlayerScoreSuccess(GetLeaderboardAroundPlayerResult result)
        {
            DestroyAllChildren();
            if (result.Leaderboard.Count > 0)
            {
                int playerScore = result.Leaderboard[0].StatValue;
                _UserScore = playerScore;
                PlayerPrefs.SetInt("IntPlayerScore", _UserScore);
                PlayerPrefs.SetInt("MainTotalScore_ALLSTAGES", _UserScore);
                
                GetPlayerRank();
                
                // Do something with the player score
            }
        }

        private void OnGetPlayerScoreFailure(PlayFabError error)
        {
            Debug.LogError("Failed to get player score: " + error.ErrorMessage);
        }

        public void GetOfficialPlayerRank()
        {
            var request = new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = leaderboardName,
                PlayFabId = PlayerPlayfabID,
                MaxResultsCount = 10 // Increase this number to retrieve a larger range
            };

            PlayFabClientAPI.GetLeaderboardAroundPlayer(request, result =>
            {
                int playerRank = -1; // -1
                for (int i = 0; i < result.Leaderboard.Count; i++)
                {
                    if (result.Leaderboard[i].PlayFabId == PlayerPlayfabID)
                    {
                        playerRank = result.Leaderboard[i].Position;
                        break;
                    }
                }

                if (playerRank >= 0)
                {
                    Debug.LogFormat("Player {0} is ranked {1} on the {2} leaderboard.", PlayerPlayfabID, playerRank, leaderboardName);
                    int PlayerOfficialRank = playerRank + 1;
                    PlayerOfficialRankNumber = PlayerOfficialRank.ToString();
                    PlayerRankNumberText.text = PlayerOfficialRankNumber;
                    PlayerPrefs.SetString("PlayerRankNumber" , PlayerOfficialRankNumber);

                }
                else
                {
                    Debug.LogError("Failed to find player on leaderboard.");





                }
            }, error =>
            {
                Debug.LogError("Failed to get leaderboard: " + error.ErrorMessage);
            });
        }



        public void DestroyAllChildren()
        {
            int childCount = ResultPosRank.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                Destroy(ResultPosRank.GetChild(i).gameObject);
            }
        }

    }
}

//Debug.Log(error.GenerateErrorReport());

