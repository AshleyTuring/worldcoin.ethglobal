
Firstly you put this in your index.html
It reads from the browser
function getAuthorizationCode() {
    var queryString = window.location.search.substring(1);
    var params = queryString.split('&');
    for (var i = 0; i < params.length; i++) {
        var pair = params[i].split('=');
        if (pair[0] == 'authorization_code') {
            var code = decodeURIComponent(pair[1]);
            unityInstance.SendMessage('AuthManager', 'ReceiveCode', code);
            return;
        }
    }
}


You then pass in the variable to Unity

You put this inside of unity then you can call Javascript

using System.Runtime.InteropServices;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void getAuthorizationCode();

    // Call this method to initiate the code retrieval process
    public void RetrieveAuthorizationCode()
    {
        getAuthorizationCode();
    }

    // This method is called from JavaScript
    public void ReceiveCode(string code)
    {
        Debug.Log("Authorization Code: " + code);
        // Continue with your authorization process
    }
}
