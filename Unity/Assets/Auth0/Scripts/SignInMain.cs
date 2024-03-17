using Auth0;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SignInMain : MonoBehaviour
{
    private void OnEnable()
    {
        this.UpdateLoginStatus();
    }

    public void SignOutBtn()
    {
        AuthManager.Instance.Credentials.ClearCredentials();
        this.UpdateLoginStatus();
    }

    //async void SignIn(string email)
    //{
    //    var request = new PasswordlessEmailRequest()
    //    {
    //        ClientId = AuthManager.Instance.Settings.ClientId,
    //        ClientSecret = "sk_26c418dc3eb2acde23421cf5113763d995a52f4b5e49a3e3",
    //        Email = emailField.text,
    //        Type = PasswordlessEmailRequestType.Link,
    //    };

    //    PasswordlessEmailResponse response = null;
    //    ErrorApiException apiError = null;

    //    try
    //    {

    //        response = await AuthManager.Instance.Auth0.StartPasswordlessEmailFlowAsync(request);
    //    }
    //    catch (ErrorApiException ex)
    //    {
    //        apiError = ex;
    //    }

    //    if (apiError != null)
    //    {
    //        Debug.LogError(apiError.ApiError + " : " + apiError.Message);
    //        return;
    //    }
    //    Debug.Log($"{response.Email} : {response.EmailVerified} : {response.Id}");
    //}

    private void UpdateLoginStatus()
    {
        var loggedIn = AuthManager.Instance.Credentials.HasValidCredentials();

        if (loggedIn)
        {
            FindObject(gameObject, "SignInBtn").SetActive(false);
            FindObject(gameObject, "SignOutBtn").SetActive(true);
            FindObject(gameObject, "ContinueBtn").SetActive(true);
        }
        else
        {
            FindObject(gameObject, "SignInBtn").SetActive(true);
            FindObject(gameObject, "SignOutBtn").SetActive(false);
            FindObject(gameObject, "ContinueBtn").SetActive(false);
        }
    }

    public static GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs= parent.GetComponentsInChildren<Transform>(true);

        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }

        return null;
    }
}
