using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;

public class PlayFabLogin : MonoBehaviour
{

    private string userEmail;
    private string userPassword;
    private string userName;
    public InputField nameField;
    public InputField emailField;
    public InputField passwordField;
    JSONController json;

    void Start()
    {
        json = new JSONController();
        json.LoadField();
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId)) 
        {
            PlayFabSettings.TitleId = "321";
        }

       
        if (json.item.loggedIn == "true") {
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");
            var requst = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(requst, OnLoginSuccess, OnLoginFailureStart);
        }

    }

    private void OnLoginFailureStart(PlayFabError obj)
    {
        Debug.Log(userPassword + "  -  " +userEmail);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayerPrefs.SetString("USERNAME", userName);
        json.item.loggedIn = "true";
        json.item.Name = userName;
        json.SaveField();
        Debug.Log("Success login");
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result) 
    {
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayerPrefs.SetString("USERNAME", userName);
        json.item.loggedIn = "true";
        json.item.Name = userName;
        json.SaveField();
        Debug.Log("Success register");  
    }
    private void OnLoginFailure(PlayFabError error) 
    {
        var requst = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPassword, Username = userName };
        PlayFabClientAPI.RegisterPlayFabUser(requst, OnRegisterSuccess, OnRegisterFailure);
    }
     private void OnRegisterFailure(PlayFabError error) 
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    public void OnClickLogin() {
        userName = nameField.text;
        userEmail = emailField.text;
        userPassword = passwordField.text;
        UIManager ma = new UIManager();
        if (userEmail != "" && userPassword != "" && userName != "") {
            var requst = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(requst, OnLoginSuccess, OnLoginFailure);
            ma.LoadScene(3);
        }
    }

}
