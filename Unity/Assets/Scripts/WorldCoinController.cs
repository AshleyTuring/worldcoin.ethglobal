using System.Collections;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Rendering.PostProcessing;

public class WorldCoinController : MonoBehaviour
{

    // This script is a template to guide your implementation. You'll need to fill in specific details like clientId, clientSecret, and redirectUri

    private string clientId = "app_staging_990f4273ffc1e467bd9112ddf472eb46";
    private string clientSecret = "sk_26c418dc3eb2acde23421cf5113763d995a52f4b5e49a3e3"; // Ensure this is kept secure
    private string redirectUri = "https://3ns.localhost.com";
    private string authorizationEndpoint = "https://worldcoin.org/oauth/authorize";
    private string tokenEndpoint = "https://worldcoin.org/oauth/token";
    private string userInfoEndpoint = "https://worldcoin.org/oauth/userinfo";


    public void Start()
    {
        StartLoginProcess();
    }

    // Start the login process
    public void StartLoginProcess()
    {
        StartCoroutine(AuthorizeWithWorldID());
    }


//    For a direct and concise implementation of OAuth2 flows in Unity using C# for integrating World ID, you'd follow these general steps:



//2. * *Capture Redirect: **Implement a way to capture the redirect URI which will contain the authorization code. This step typically requires a web server or a custom scheme handler within your application.

//3. **Exchange Code for Token:**Once you have the authorization code, make a POST request to the token endpoint to exchange it for an access token.

//4. **Fetch User Info:**Use the access token to make a GET request to the userinfo endpoint to retrieve the user's information.

//Each of these steps requires constructing HTTP requests and handling responses within your Unity project, making use of `UnityWebRequest` for networking. This direct method gives you complete control over the authentication process, allowing for a customized integration with World ID.

//Due to restrictions, I can't repeat the previous example code, but the process involves:
//- Constructing URLs for OAuth2 endpoints.
//- Handling HTTP requests and responses.
//- Parsing JSON responses to extract tokens and user info.

//This approach requires understanding of Unity's networking APIs, async programming in C#, and handling JSON data. Always ensure you're securely handling and storing sensitive information, like tokens and user credentials.


    private IEnumerator AuthorizeWithWorldID()
{
    // Construct the authorization request URI
    // 1. **Implement OAuth2 Flow:** Start by creating the URL for the authorization request according to World ID's documentation. 
    var authorizationRequest = $"{authorizationEndpoint}?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&scope=openid";

    // Redirect user to authorizationRequest URL for login
    // Open this URL in a browser for the user to log in.
    Application.OpenURL(authorizationRequest);

    // Here, you would need to intercept the redirect to the redirectUri to get the authorization code.
    // This part is highly dependent on your application's architecture.

    // Assume we have the code in a variable called `authCode`
    string authCode = "AUTHORIZATION_CODE";

    // Exchange the authorization code for an access token
    WWWForm form = new WWWForm();
    form.AddField("grant_type", "authorization_code");
    form.AddField("code", authCode);
    form.AddField("redirect_uri", redirectUri);
    form.AddField("client_id", clientId);
    form.AddField("client_secret", clientSecret);

    UnityWebRequest webRequest = UnityWebRequest.Post(tokenEndpoint, form);
    yield return webRequest.SendWebRequest();

    if (webRequest.isNetworkError || webRequest.isHttpError)
    {
        Debug.LogError(webRequest.error);
        yield break;
    }

    // Extract access token from webRequest.downloadHandler.text

    // Use the access token to request user info
    // Headers need to include the Authorization: Bearer YOUR_ACCESS_TOKEN
}

private IEnumerator ExchangeCodeForToken(string authCode)
{
    WWWForm form = new WWWForm();
    form.AddField("grant_type", "authorization_code");
    form.AddField("code", authCode);
    form.AddField("redirect_uri", redirectUri);
    form.AddField("client_id", clientId);
    form.AddField("client_secret", clientSecret);

    UnityWebRequest webRequest = UnityWebRequest.Post(tokenEndpoint, form);
    yield return webRequest.SendWebRequest();

    if (webRequest.isNetworkError || webRequest.isHttpError)
    {
        Debug.LogError(webRequest.error);
        yield break;
    }

    //JSONNode tokenResponse = JSON.Parse(webRequest.downloadHandler.text);
    //string accessToken = tokenResponse["access_token"];

    //StartCoroutine(GetUserInfo(accessToken));
}

private IEnumerator GetUserInfo(string accessToken)
{
    UnityWebRequest webRequest = UnityWebRequest.Get(userInfoEndpoint);
    webRequest.SetRequestHeader("Authorization", $"Bearer {accessToken}");
    yield return webRequest.SendWebRequest();

    if (webRequest.isNetworkError || webRequest.isHttpError)
    {
        Debug.LogError(webRequest.error);
        yield break;
    }

    //JSONNode userInfo = JSON.Parse(webRequest.downloadHandler.text);
    //Debug.Log("User Info: " + userInfo.ToString());
    // Here you can handle the user info JSON object, such as displaying user data in your game.
}
}
