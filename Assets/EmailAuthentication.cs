/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using Network.LeaderBoard;

public class EmailAuthentication : MonoBehaviour
{
    [SerializeField]
    TMP_InputField UserNameInput;
    [SerializeField]
    TMP_InputField emailInput;
    [SerializeField]
    TMP_InputField passwordInput;
    public void SignUpButton()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Username = UserNameInput.text,
            Email = emailInput.text,
            Password = passwordInput.text,
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSignUpSuccess, OnRegisterError);
    }

	private void OnRegisterError(PlayFabError obj)
	{
		throw new System.NotImplementedException();
	}

	private void OnSignUpSuccess(RegisterPlayFabUserResult result)
    {
        RegistrationMessageText.text = "Registration Complete.";
        StartCoroutine(RegistrationCompleteResult());
    }

    void AddContactEmailToPlayer(string userName, string emailId)
    {
        var loginReq = new LoginWithCustomIDRequest
        {
            CustomId = userName, // replace with your own Custom ID
            CreateAccount = true // otherwise this will create an account with that ID
        };
        var emailAddress = emailId; // Set this to your own email
        PlayFabClientAPI.LoginWithCustomID(loginReq, loginRes =>
        {
            Debug.Log("Successfully logged in player with PlayFabId: " + loginRes.PlayFabId);
            AddOrUpdateContactEmail(emailAddress);
        }, FailureCallback);
    }
    void AddOrUpdateContactEmail(string emailAddress)
    {
        var request = new AddOrUpdateContactEmailRequest
        {
            EmailAddress = emailAddress
        };
        PlayFabClientAPI.AddOrUpdateContactEmail(request, result =>
        {
            Debug.Log("The player's account has been updated with a contact email");
        }, FailureCallback);
    }
    void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        MessageFormatter(error.ErrorMessage);
    }
} 

*//*


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using Network.LeaderBoard;
using System;

public class EmailAuthentication : MonoBehaviour
{

    *//*[SerializeField]
    TMP_InputField emailInput;
    [SerializeField]
    TMP_Text messageText;*/
    /*
        public void OnRegisterButtonClicked()
        {
            var request = new RegisterPlayFabUserRequest
            {
                Email = emailInput.text,
                Password = "somepassword", // Replace with player's chosen password
                Username = "someusername" // Replace with player's chosen username
            };
            OnVerifyButtonClicked();
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterError);
        }

        private void OnRegisterSuccess(RegisterPlayFabUserResult result)
        {
            messageText.text = "Check your email for a verification link";
        }

        private void OnRegisterError(PlayFabError error)
        {
            messageText.text = "Registration failed: " + error.ErrorMessage;
        }

        public void OnVerifyButtonClicked()
        {
            // Open the default email application to allow the player to click the verification link
            Application.OpenURL("mailto:" + emailInput.text);
        }*//*


    public void SendVerificationEmail(string email)
    {
        var titleId = PlayFabSettings.TitleId;
        Debug.Log("Title ID: " + titleId);
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = email,
            TitleId = titleId , // replace with your actual title ID
            EmailTemplateId = "dsadsad" // replace with your actual verification email template ID
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnSendVerificationEmailSuccess, OnSendVerificationEmailError);
    }

    private void OnSendVerificationEmailSuccess(SendAccountRecoveryEmailResult result)
    {
        Debug.Log("Verification email sent successfully!");
    }

    private void OnSendVerificationEmailError(PlayFabError error)
    {
        Debug.LogError("Failed to send verification email: " + error.ErrorMessage);
    }

    public void SetPlayerVerificationToken(string playerId)
    {
        var request = new SetPlayerSecretRequest
        {
            PlayerSecret = Guid.NewGuid().ToString() // generate a new unique token
        };
        PlayFabClientAPI.SetPlayerSecret(request, OnSetPlayerVerificationTokenSuccess, OnSetPlayerVerificationTokenError);

        void OnSetPlayerVerificationTokenSuccess(SetPlayerSecretResult result)
        {
            Debug.Log("Player verification token set successfully!");
        }

        void OnSetPlayerVerificationTokenError(PlayFabError error)
        {
            Debug.LogError("Failed to set player verification token: " + error.ErrorMessage);
        }

        
    }

}

*/